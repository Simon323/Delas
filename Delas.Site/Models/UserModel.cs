using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Delas.Site.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Email")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength = 3)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class RegistrationModel : LoginModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
    }
}