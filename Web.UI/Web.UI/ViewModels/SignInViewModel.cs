using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.ViewModels
{
    public class SignInViewModel
    {
        [Required, Display(Prompt = "Email Address")]
        public string Email { get; set; }

        [Required, Display(Prompt = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
