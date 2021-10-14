using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TechZone.Models.Product
{
    public class CreateProduct
    {
        [Required]
        [StringLength(300)]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public IFormFile Pictures { get; set; }
        public int CategoryId { get; set; }
    }
}
