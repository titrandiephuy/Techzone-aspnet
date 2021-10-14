using System;
using System.Collections.Generic;
using TechZone.Entities;

namespace TechZone.Services
{
    public interface IProductService
    {
        List<Product> GetProductByCategoryId(int categoryId);
        bool Create(Product model);
        bool Edit(Product model);
        Product Get(int productId);
        bool Remove(int productId);
        public List<Product> Gets();
    }
}
