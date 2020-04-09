namespace AnisMasterpieces.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AnisMasterpieces.Services;
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Web.Controllers;
    using AnisMasterpieces.Web.ViewModels.Items;
    using AnisMasterpieces.Web.ViewModels.Tabs;
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    [Area("Administration")]
    public class ItemsController : BaseController
    {
        private readonly IItemService itemService;
        private readonly ITabService tabService;
        private readonly Cloudinary cloudinary;

        public ItemsController(IItemService itemService, ITabService tabService, Cloudinary cloudinary)
        {
            this.itemService = itemService;
            this.tabService = tabService;
            this.cloudinary = cloudinary;
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

            var imageName = await CloudinaryService.UploadAsync(this.cloudinary, input.Image, "Items");

            var itemId = await this.itemService.AddAsync(input.Name, imageName, input.Price, input.TabId, input.Description);
            return this.RedirectToAction("Id", "Items", new { area = string.Empty, Id = itemId });
        }

        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Select", "Items", new { id });
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
            return this.RedirectToAction("Id", "Items", new { area = string.Empty, Id = input.Id });
        }

        public IActionResult Select(string id)
        {
            if (id != null)
            {
                return this.RedirectToAction("Edit", "Items", new { id });
            }

            var items = this.itemService.GetAll<ItemIdNameViewModel>().ToArray();
            var viewModel = new ItemSelectViewModel()
            {
                Items = items,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Select(ItemSelectViewModel input)
        {
            return this.RedirectToAction("Edit", "Items", new { input.Id });
        }
    }
}
