﻿using System.ComponentModel.DataAnnotations;

namespace admin.libraryweb.Models
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
