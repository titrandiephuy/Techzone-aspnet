using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TechZone.Contexts;
using TechZone.Entities;

namespace TechZone.Services
{
    public class ProductService : IProductService
    {
        private readonly TechzoneDBContext context;

        public ProductService(TechzoneDBContext context)
        {
            this.context = context;
        }

        public bool Create(Product model)
        {
            try
            {
                context.Add(model);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(Product product)
        {
            try
            {
                context.Attach(product);
                context.Entry(product).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Product Get(int productId)
        {
            return context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == productId);
        }

        public List<Product> GetProductByCategoryId(int categoryId)
        {
            return context.Products.Include(p => p.Category).Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> Gets()
        {
            return context.Products.ToList();
        }

        public bool Remove(int productId)
        {
            try
            {
                var product = Get(productId);
                context.Remove(product);
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
