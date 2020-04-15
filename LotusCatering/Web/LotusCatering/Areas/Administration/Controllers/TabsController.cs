namespace LotusCatering.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using LotusCatering.Services;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.Controllers;
    using LotusCatering.Web.ViewModels.Categories;
    using LotusCatering.Web.ViewModels.Tabs;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    [Area("Administration")]
    public class TabsController : BaseController
    {
        private readonly ITabService tabService;
        private readonly ICategoryService categoryService;
        private readonly Cloudinary cloudinary;
        private readonly IWebHostEnvironment hostEnvironment;

        public TabsController(ITabService tabService, ICategoryService categoryService, Cloudinary cloudinary, IWebHostEnvironment hostEnvironment)
        {
            this.tabService = tabService;
            this.categoryService = categoryService;
            this.cloudinary = cloudinary;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Add(string id)
        {
            var categories = this.categoryService.GetAll<CategoryIdNameViewModel>();
            var viewModel = new TabAddInputModel
            {
                CategoryId = id,
                Categories = categories,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TabAddInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var categories = this.categoryService.GetAll<CategoryIdNameViewModel>();
                input.Categories = categories;
                return this.View(input);
            }

            string rootPath = this.hostEnvironment.WebRootPath;
            var imageArr = await ImageService.ConvertIFormFileToByteArray(input.Image);
            var imageName = await CloudinaryService.UploadAsync(this.cloudinary, imageArr, "Tabs", rootPath, true);

            var tabId = await this.tabService.AddAsync(input.Name, imageName, input.CategoryId, input.Description);
            return this.RedirectToAction("Id", "Tabs", new { area = string.Empty, Id = tabId });
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Select", "Tabs", new { id, returnUrl = "Edit" });
            }

            var categories = this.categoryService.GetAll<CategoryIdNameViewModel>();
            var viewModel = this.tabService.GetById<TabEditInputModel>(id);

            viewModel.Id = id;
            viewModel.Categories = categories;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TabEditInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var categories = this.categoryService.GetAll<CategoryIdNameViewModel>();
                input.Categories = categories;
                return this.View(input);
            }

            await this.tabService.UpdateAsync(input.Id, input.Name, input.CategoryId, input.Description);
            return this.RedirectToAction("Id", "Tabs", new { area = string.Empty, input.Id });
        }

        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Select", "Tabs", new { id, returnUrl = "Delete" });
            }

            var viewModel = this.tabService.GetById<TabDeleteViewModel>(id);
            viewModel.Category = this.categoryService.GetNameById(viewModel.CategoryId);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TabDeleteInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.NotFound();
            }

            var succeed = await this.tabService.DeleteAsync(input.Id);

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

            var tabs = this.tabService.GetAll<TabIdNameViewModel>().ToArray();
            var viewModel = new TabSelectViewModel()
            {
                Tabs = tabs,
                ReturnUrl = returnUrl,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Select(TabSelectInputModel input)
        {
            return this.RedirectToAction(input.ReturnUrl, new { input.Id });
        }
    }
}
