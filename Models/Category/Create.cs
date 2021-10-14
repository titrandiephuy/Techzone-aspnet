using System;
using System.ComponentModel.DataAnnotations;

namespace TechZone.Models.Category
{
    public class Create
    {
        [Required]
        [StringLength(200)]
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [StringLength(500)]
        public string Picture { get; set; }
        public bool Status { get; set; }
    }
}
