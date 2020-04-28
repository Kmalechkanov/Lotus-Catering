namespace LotusCatering.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.Models;
    using LotusCatering.Web.ViewModels.Categories;
    using LotusCatering.Web.ViewModels.Galleries;
    using LotusCatering.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;
        private readonly ICategoryService categoryService;
        private readonly IGalleryService galleryService;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IGalleryService galleryService)
        {
            this.logger = logger;
            this.categoryService = categoryService;
            this.galleryService = galleryService;
        }

        public IActionResult Index()
        {
            var categories = this.categoryService.GetAll<CategoryDescriptionViewModel>().ToArray();
            var galleries = this.galleryService.GetAll<GalleryIdNameViewModel>().ToArray();

            var viewModel = new HomeViewModel
            {
                Categories = categories,
                Galleries = galleries,
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
