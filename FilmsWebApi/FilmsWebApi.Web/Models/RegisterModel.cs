﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FilmsWebApi.Web.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}