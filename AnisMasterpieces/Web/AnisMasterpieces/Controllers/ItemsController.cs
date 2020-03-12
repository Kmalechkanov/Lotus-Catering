namespace AnisMasterpieces.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Web.ViewModels.Items;
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
            var itemName = this.itemService.GetItemName(id);
            if (itemName == null)
            {
                return this.Redirect("/");
            }

            var model = new ItemBasicViewModel()
            {
                Id = id,
                Name = itemName,
            };

            return this.View(model);
        }
    }
}
