namespace AnisMasterpieces.Web.ViewComponents
{
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Web.ViewModels.Category;
    using AnisMasterpieces.Web.ViewModels.NavBar;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;

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
                Categories = this.categoriesService.GetAll()
            };

            return this.View(viewModel);
        }
    }
}
