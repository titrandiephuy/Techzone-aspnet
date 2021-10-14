using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechZone.Entities;
using TechZone.Models.Product;
using TechZone.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechZone.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private static List<Product> products = new List<Product>();

        public ShopController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            products = productService.Gets();

            //return View(categoryService.Gets());
            return View(products);
        }
        [Route("Shop/ViewCategory/{categoryId}")]
        public IActionResult ViewCategory(int categoryId)
        {
            return View(productService.GetProductByCategoryId(categoryId));
        }

        [HttpGet]
        [Route("Shop/ProductDetail/{productId}")]
        public IActionResult ProductDetail(int productId)
        {
            var product = productService.Get(productId);
            var detailprod = new DetailProduct()
            {
                ProductId = product.ProductId,
                CategoryId = product.CategoryId,
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                PicturePath = product.Pictures

            };
            return View(detailprod);
        }
    }


}
