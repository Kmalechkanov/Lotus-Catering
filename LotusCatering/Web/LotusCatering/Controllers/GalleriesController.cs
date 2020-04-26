namespace LotusCatering.Web.Controllers
{
    using System.Linq;

    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.ViewModels.Galleries;
    using LotusCatering.Web.ViewModels.Images;
    using Microsoft.AspNetCore.Mvc;

    public class GalleriesController : BaseController
    {
        private readonly IGalleryService galleryService;
        private readonly IImageService imageService;

        public GalleriesController(IGalleryService galleryService, IImageService imageService)
        {
            this.galleryService = galleryService;
            this.imageService = imageService;
        }

        public IActionResult Index()
        {
            // var categories = this.galleryService.GetAll<CategoryIdNameViewModel>().ToArray();

            return this.View();
        }

        public IActionResult Id(string id)
        {
            var images = this.imageService.GetAll<ImageBasicViewModel>(id).ToArray();

            var viewModel = new GalleryIdViewModel
            {
                Id = id,
                Images = images,
            };

            return this.View(viewModel);
        }
    }
}
