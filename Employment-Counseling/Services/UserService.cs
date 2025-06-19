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
                return LoginResult.Fail("המשתמש לא נמצא");
            if (!user.Password.Equals(password))
                return LoginResult.Fail("הססמה שגויה");
            object userDto = user switch
            {
                Costumer c => _mapper.Map<CostumerDto>(c),
                Counselor c => _mapper.Map<CounselorDto>(c),
                _ => _mapper.Map<UserDto>(user)
            };
            return LoginResult.Ok(userDto, user.IsCostumer);
        }
       
    }
}
