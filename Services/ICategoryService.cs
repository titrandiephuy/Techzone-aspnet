using System;
using System.Collections.Generic;
using TechZone.Entities;
using TechZone.Models.Category;

namespace TechZone.Services
{
    public interface ICategoryService
    {
        List<Category> Gets();
        Category Get(int categoryId);
        bool Create(Create create);
        bool Edit(Edit edit);
        bool ChangeStatus(int categoryId);
    }
}
