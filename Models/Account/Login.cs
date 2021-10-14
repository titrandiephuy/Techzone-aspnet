using System;
using System.ComponentModel.DataAnnotations;

namespace TechZone.Models.Account
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RemenberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
