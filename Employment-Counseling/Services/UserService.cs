using AutoMapper;
using Employment_Counseling.Controllers;
using Employment_Counseling.DTOs;
using Employment_Counseling.Entities;
using Employment_Counseling.Repositories;
using Employment_Counseling.Repositories.Interfaces;
using Employment_Counseling.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Employment_Counseling.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenService _refreshTokenService;

        public UserService(IUserRepository userRepository, IMapper mapper, IJwtService jwtService, IRefreshTokenService refreshTokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
            _refreshTokenService = refreshTokenService;
        }
        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserById(Guid userId)
        {
            var user = await _userRepository.GetUserById(userId);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<LoginResult> Login(string email , string password)
        {
            var user = await _userRepository.GetUserByEmailAddress(email);
            if (user == null)
                return LoginResult.Fail("User Not Found");
            if (!user.Password.Equals(password))
                return LoginResult.Fail("Password Is Incorrect");
            object userDto = user switch
            {
                Costumer c => _mapper.Map<CostumerDto>(c),
                Counselor c => _mapper.Map<CounselorDto>(c),
                _ => _mapper.Map<UserDto>(user)
            };
            var token = _jwtService.GenerateToken(user);
            var refreshToken = await _refreshTokenService.GenerateRefreshToken(user.Id);

            return LoginResult.Ok(userDto, token, refreshToken, user.IsCostumer);
        }

        public async Task<bool> UpdateUserDetails(Guid id, UpdateUserDto dto)
        {
            var user = _userRepository.GetUserById(id).Result;
            if (user == null) return false;
            user.Name = dto.Name ?? user.Name;
            user.PhoneNumber = dto.PhoneNumber ?? user.PhoneNumber;
            user.EmailAddress = dto.EmailAddress ?? user.EmailAddress;
            return await _userRepository.UpdateUserDetails(user);
        }

        public async Task<(bool Success, string ErrorMessage)> ChangePassword(ChangePasswordDto dto)
        {
            var user = await _userRepository.GetUserById(dto.UserId);
            if (user == null)
                return (false, "User not found");

            //TODO: Add hash code
            if (user.Password != dto.CurrentPassword) 
                return (false, "Current password is incorrect");

            user.Password = dto.NewPassword;
            await _userRepository.UpdateUserDetails(user);
            return (true, null);
        }

        public async Task<RefreshResponseDto> RefreshToken(string refreshToken)
        {
            var existingToken = await _refreshTokenService.GetByTokenAsync(refreshToken);
            if (existingToken == null || existingToken.ExpiresAt < DateTime.UtcNow || existingToken.IsUsed)
            {
                return RefreshResponseDto.Fail("Invalid or expired refresh token");
            }
            var user = await _userRepository.GetUserById(existingToken.UserId);
            if (user == null)
            {
                return RefreshResponseDto.Fail("User not found");
            }
            var newAccessToken = _jwtService.GenerateToken(user);
            return RefreshResponseDto.Ok(newAccessToken, existingToken.Token);       

        }

    }
}
