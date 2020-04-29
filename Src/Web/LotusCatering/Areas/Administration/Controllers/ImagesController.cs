namespace LotusCatering.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using LotusCatering.Services;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.Controllers;
    using LotusCatering.Web.ViewModels.Galleries;
    using LotusCatering.Web.ViewModels.Images;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    [Area("Administration")]
    public class ImagesController : BaseController
    {
        private readonly IGalleryService galleryService;
        private readonly IImageService imageService;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly Cloudinary cloudinary;

        public ImagesController(IGalleryService galleryService, IImageService imageService, IWebHostEnvironment hostEnvironment, Cloudinary cloudinary)
        {
            this.galleryService = galleryService;
            this.imageService = imageService;
            this.hostEnvironment = hostEnvironment;
            this.cloudinary = cloudinary;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Add(string id)
        {
            var galleries = this.galleryService.GetAll<GalleryIdNameViewModel>();

            var viewModel = new ImageAddInputModel
            {
                GalleryId = id,
                Galleries = galleries,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ImageAddInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var galleries = this.galleryService.GetAll<GalleryIdNameViewModel>();
                input.Galleries = galleries;

                return this.View(input);
            }

            string rootPath = this.hostEnvironment.WebRootPath;
            var imageArr = await ImageService.ConvertIFormFileToByteArray(input.Image);
            var imageName = await CloudinaryService.UploadAsync(this.cloudinary, imageArr, "Images", rootPath, false);

            await this.imageService.AddAsync(input.Name, imageName, input.GalleryId, input.Description);

            return this.RedirectToAction("Id", "Galleries", new { area = string.Empty, Id = input.GalleryId });
        }
    }
}
