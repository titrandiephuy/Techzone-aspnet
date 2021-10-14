using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TechZone.Entities
{
    public class AppUser : IdentityUser
    {

        [MaxLength(100)]
        public string FullName { set; get; }

        [MaxLength(255)]
        public string Address { set; get; }

        public string Avatar { get; set; }

    }
}
