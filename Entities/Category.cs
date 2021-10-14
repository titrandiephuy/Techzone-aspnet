using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechZone.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [StringLength(500)]
        public string Picture { get; set; }
        public ICollection<Product> Products { get; set; }
        public bool Status { get; set; }
    }
}
