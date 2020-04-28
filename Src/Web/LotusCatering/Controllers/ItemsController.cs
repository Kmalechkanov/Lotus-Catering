namespace LotusCatering.Web.Controllers
{
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Mvc;

    public class ItemsController : BaseController
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        public IActionResult Id(string id)
        {
            if (!this.itemService.IsValidId(id))
            {
                return this.Redirect("/");
            }

            var item = this.itemService.GetById<ItemViewModel>(id);

            return this.View(item);
        }
    }
}
