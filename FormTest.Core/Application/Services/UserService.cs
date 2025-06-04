using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormTest.Core.Application.DTOs;
using FormTest.Core.Domain.Entities;
using FormTest.Core.Domain.Interfaces;
using FormTest.Core.Application.Contracts;
using FormTest.Core.Domain.Enums;
using System.Data;
namespace FormTest.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Register(RegisterUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                Role  = UserRole.pending,
                IsApproved = false
            };

            _userRepository.Add(user);
        }
       public bool IsEmailTaken(string email)
        {
            return _userRepository.GetByEmail(email) != null;
        }

       public  User? Login(LoginUserDto dto)
        {
            return _userRepository.GetByEmailAndPassword(dto.Email,dto.Password);
        }

    }

}
