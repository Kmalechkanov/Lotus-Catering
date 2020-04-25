namespace LotusCatering.Web.Controllers
{
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GalleriesController : BaseController
    {
        private readonly IGalleryService galleryService;

        public GalleriesController(IGalleryService galleryService)
        {
            this.galleryService = galleryService;
        }

        public IActionResult Index()
        {
            var categories = this.galleryService.GetAll<CategoryIdNameViewModel>().ToArray();

            return this.View();
        }

        public IActionResult Id(string id)
        {

            var categories = this.galleryService.GetAll<CategoryIdNameViewModel>().ToArray();

            return this.View();
        }
    }
}
