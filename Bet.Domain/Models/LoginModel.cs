﻿using System.ComponentModel.DataAnnotations;

namespace Bet.Domain.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}