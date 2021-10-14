using System;
using System.ComponentModel.DataAnnotations;

namespace TechZone.Models.Account
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password not macth")]
        public string ConfirmPassword { get; set; }
    }
}
