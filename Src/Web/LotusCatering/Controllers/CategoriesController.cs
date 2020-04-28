namespace LotusCatering.Web.Controllers
{
    using System.Linq;

    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.ViewModels.Categories;
    using LotusCatering.Web.ViewModels.Tabs;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly ITabService tabService;

        public CategoriesController(ICategoryService categoryService, ITabService tabService)
        {
            this.categoryService = categoryService;
            this.tabService = tabService;
        }

        public IActionResult Index()
        {
            var categories = new CategoryCollectionOfIdAndNameViewModel()
            {
                Categories = this.categoryService.GetAll<CategoryIdNameViewModel>().ToArray(),
            };

            return this.View(categories);
        }

        public IActionResult Id(string id)
        {
            if (!this.categoryService.IsValidId(id))
            {
                return this.Redirect("/");
            }

            var tabs = new CategoryNameAndTabNameViewModel()
            {
                Id = id,
                Name = this.categoryService.GetNameById(id),
                Tabs = this.tabService.GetAll<TabBasicViewModel>(id).ToArray(),
            };

            return this.View(tabs);
        }
    }
}
