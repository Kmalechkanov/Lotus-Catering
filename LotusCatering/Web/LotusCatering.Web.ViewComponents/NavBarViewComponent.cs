namespace LotusCatering.Web.ViewComponents
{
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.ViewModels.Categories;
    using LotusCatering.Web.ViewModels.NavBar;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "NavBar")]
    public class NavBarViewComponent : ViewComponent
    {
        private readonly ICategoryService categoriesService;

        public NavBarViewComponent(ICategoryService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new NavBarViewModel()
            {
                Categories = this.categoriesService.GetAll<CategoryIdNameViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
