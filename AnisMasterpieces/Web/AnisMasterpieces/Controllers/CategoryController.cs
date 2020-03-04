namespace AnisMasterpieces.Web.Controllers
{
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Web.ViewModels.Category;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = new CategoryCollectionOfIdAndNameViewModel()
            {
                Categories = categoryService.GetAll().ToArray()
            };

            return this.View(categories);
        }

        public IActionResult Specific(string id)
        {
            if (!categoryService.IsValidId(id))
            {
                return this.Redirect("/");
            }

            return this.View(model: id);
        }
    }
}
