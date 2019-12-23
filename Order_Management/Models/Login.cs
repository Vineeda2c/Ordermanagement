using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Order_Management.Models
{
    public class Login
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username Required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required.")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string UserType { get; set; }
        public string NewPassword { get; set; }
    }
}