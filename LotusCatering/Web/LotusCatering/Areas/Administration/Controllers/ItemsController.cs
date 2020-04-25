namespace LotusCatering.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using LotusCatering.Services;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.Controllers;
    using LotusCatering.Web.ViewModels.Items;
    using LotusCatering.Web.ViewModels.Tabs;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    [Area("Administration")]
    public class ItemsController : BaseController
    {
        private readonly IItemService itemService;
        private readonly ITabService tabService;
        private readonly Cloudinary cloudinary;
        private readonly IWebHostEnvironment hostEnvironment;

        public ItemsController(IItemService itemService, ITabService tabService, Cloudinary cloudinary, IWebHostEnvironment hostEnvironment)
        {
            this.itemService = itemService;
            this.tabService = tabService;
            this.cloudinary = cloudinary;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Add(string id)
        {
            var tabs = this.tabService.GetAll<TabIdNameViewModel>();

            var viewModel = new ItemAddInputModel
            {
                TabId = id,
                Tabs = tabs,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ItemAddInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var tabs = this.tabService.GetAll<TabIdNameViewModel>();
                input.Tabs = tabs;
                return this.View(input);
            }

            string rootPath = this.hostEnvironment.WebRootPath;
            var imageArr = await ImageService.ConvertIFormFileToByteArray(input.Image);
            var imageName = await CloudinaryService.UploadAsync(this.cloudinary, imageArr, "Items", rootPath, false);

            var itemId = await this.itemService.AddAsync(input.Name, imageName, input.Price, input.TabId, input.Description);
            return this.RedirectToAction("Id", "Items", new { area = string.Empty, Id = itemId });
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Select", "Items", new { id, returnUrl = "Edit" });
            }

            var tabs = this.tabService.GetAll<TabIdNameViewModel>();
            var viewModel = this.itemService.GetById<ItemEditInputModel>(id);

            viewModel.Id = id;
            viewModel.Tabs = tabs;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ItemEditInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var tabs = this.tabService.GetAll<TabIdNameViewModel>();
                input.Tabs = tabs;
                return this.View(input);
            }

            await this.itemService.UpdateAsync(input.Id, input.Name, input.Price, input.TabId, input.Description);
            return this.RedirectToAction("Id", "Items", new { area = string.Empty, input.Id });
        }

        public IActionResult EditImage(string id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Select", "Items", new { id, returnUrl = "EditImage" });
            }

            var viewModel = new ItemEditImageViewModel
            {
                Id = id,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditImage(ItemEditImageViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string rootPath = this.hostEnvironment.WebRootPath;
            var imageArr = await ImageService.ConvertIFormFileToByteArray(input.Image);
            var imageName = await CloudinaryService.UploadAsync(this.cloudinary, imageArr, "Items", rootPath, false);

            await this.itemService.UpdateImageAsync(input.Id, imageName);
            return this.RedirectToAction("Id", "Items", new { area = string.Empty, input.Id });
        }

        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Select", "Items", new { id, returnUrl = "Delete" });
            }

            var viewModel = this.itemService.GetById<ItemDeleteViewModel>(id);
            viewModel.Tab = this.tabService.GetNameById(viewModel.TabId);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ItemDeleteInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.NotFound();
            }

            var succeed = await this.itemService.DeleteAsync(input.Id);

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

            var items = this.itemService.GetAll<ItemIdNameViewModel>().ToArray();
            var viewModel = new ItemSelectViewModel()
            {
                Items = items,
                ReturnUrl = returnUrl,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Select(ItemSelectInputModel input)
        {
            return this.RedirectToAction(input.ReturnUrl, new { input.Id });
        }
    }
}
