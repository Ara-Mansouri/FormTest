﻿using System.ComponentModel.DataAnnotations;

namespace FormTest.Core.Application.DTOs
{
    public class RegisterUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}


