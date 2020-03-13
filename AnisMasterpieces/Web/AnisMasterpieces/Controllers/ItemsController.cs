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
            if (this.itemService.GetName(id) == null)
            {
                return this.Redirect("/");
            }

            var item = this.itemService.GetById<ItemViewModel>(id);

            return this.View(item);
        }
    }
}
