using AutoMapper;
using Employment_Counseling.DTOs;
using Employment_Counseling.Entities;
using Employment_Counseling.Repositories;
using Employment_Counseling.Repositories.Interfaces;
using Employment_Counseling.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Employment_Counseling.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
            return LoginResult.Ok(userDto, user.IsCostumer);
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
    }
}
