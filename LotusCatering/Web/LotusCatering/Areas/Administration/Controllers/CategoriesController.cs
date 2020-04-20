namespace LotusCatering.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using LotusCatering.Services;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.Controllers;
    using LotusCatering.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    [Area("Administration")]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly ITabService tabService;
        private readonly Cloudinary cloudinary;
        private readonly IWebHostEnvironment hostEnvironment;

        public CategoriesController(ICategoryService categoryService, ITabService tabService, Cloudinary cloudinary, IWebHostEnvironment hostEnvironment)
        {
            this.categoryService = categoryService;
            this.tabService = tabService;
            this.cloudinary = cloudinary;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string rootPath = this.hostEnvironment.WebRootPath;
            var imageArr = await ImageService.ConvertIFormFileToByteArray(input.Image);
            var imageName = await CloudinaryService.UploadAsync(this.cloudinary, imageArr, "Categories", rootPath, true);

            var categoryId = await this.categoryService.AddAsync(input.Name, input.Description, imageName);
            return this.RedirectToAction("Id", "Categories", new { area = string.Empty, Id = categoryId });
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Select", "Categories", new { id, returnUrl = "Edit" });
            }

            var viewModel = this.categoryService.GetById<CategoryEditInputModel>(id);

            viewModel.Id = id;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.categoryService.UpdateAsync(input.Id, input.Name, input.Description);
            return this.RedirectToAction("Id", "Categories", new { area = string.Empty, input.Id });
        }

        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Select", "Categories", new { id, returnUrl = "Delete" });
            }

            var viewModel = this.categoryService.GetById<CategoryDeleteViewModel>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDeleteInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.NotFound();
            }

            var succeed = await this.categoryService.DeleteAsync(input.Id);

            if (!succeed)
            {
                return this.NotFound();
            }

            return this.RedirectToAction("Index", "Home", new { area = string.Empty });
        }

        public IActionResult Select(string id, string returnUrl)
        {
            if (id != null)
            {
                return this.RedirectToAction(returnUrl, new { id });
            }

            var categories = this.categoryService.GetAll<CategoryIdNameViewModel>().ToArray();
            var viewModel = new CategorySelectViewModel()
            {
                Categories = categories,
                ReturnUrl = returnUrl,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Select(CategorySelectInputModel input)
        {
            return this.RedirectToAction(input.ReturnUrl, new { input.Id });
        }
    }
}
