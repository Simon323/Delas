﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Delas.Site.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength = 3)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}