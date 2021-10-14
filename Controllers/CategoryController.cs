using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechZone.Models.Category;
using TechZone.Services;


namespace TechZone.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(categoryService.Gets());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Create model)
        {
            if(ModelState.IsValid)
            {
                if(categoryService.Create(model))
                {
                    return RedirectToAction("index");
                }
            }
            return View(model);
        }

        [HttpGet]
        [Route("/Category/Edit/{catId}")]
        public IActionResult Edit(int catId)
        {
            var category = categoryService.Get(catId);
            var editView = new Edit()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture,
                Status = category.Status
            };
            return View(editView);
        }

        [HttpPost]
        public IActionResult Edit(Edit edit)
        {
            if (ModelState.IsValid)
            {
                if (categoryService.Edit(edit))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(edit);
        }

        [HttpGet]
        [Route("/Category/ChangeStatus/{catId}")]
        public IActionResult ChangeStatus(int catId)
        {
            if (categoryService.ChangeStatus(catId))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
