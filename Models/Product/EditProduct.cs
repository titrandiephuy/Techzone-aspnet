using System;
namespace TechZone.Models.Product
{
    public class EditProduct: CreateProduct
    {
        public int ProductId { get; set; }
        public string ExistPicture { get; set; }
    }
}
