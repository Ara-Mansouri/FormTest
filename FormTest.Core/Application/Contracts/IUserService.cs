using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormTest.Core.Application.DTOs;
using FormTest.Core.Domain.Entities;

namespace FormTest.Core.Application.Contracts
{
    public interface IUserService
    {
        void Register(RegisterUserDto dto);
        bool IsEmailTaken(string email);
        User? Login(LoginUserDto dto);


    }
}
