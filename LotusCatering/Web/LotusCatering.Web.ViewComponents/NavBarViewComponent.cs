namespace LotusCatering.Web.ViewComponents
{
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.ViewModels.Categories;
    using LotusCatering.Web.ViewModels.Galleries;
    using LotusCatering.Web.ViewModels.NavBar;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "NavBar")]
    public class NavBarViewComponent : ViewComponent
    {
        private readonly ICategoryService categoriesService;
        private readonly IGalleryService galleryService;

        public NavBarViewComponent(ICategoryService categoriesService, IGalleryService galleryService)
        {
            this.categoriesService = categoriesService;
            this.galleryService = galleryService;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new NavBarViewModel()
            {
                Categories = this.categoriesService.GetAll<CategoryIdNameViewModel>(),
                Galleries = this.galleryService.GetAll<GalleryIdNameViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
