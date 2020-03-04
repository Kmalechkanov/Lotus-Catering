namespace AnisMasterpieces.Web.Controllers
{
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Web.ViewModels.Tabs;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TabsController : BaseController
    {
        private readonly ITabService tabService;
        private readonly IItemService itemService;

        public TabsController(ITabService tabService, IItemService itemService)
        {
            this.tabService = tabService;
            this.itemService = itemService;
        }

        public IActionResult Id(string id)
        {
            var model = new TabInfoWithItemsViewModel()
            {
                Id = id,
                Name = tabService.GetNameById(id),
                Items = itemService.GetItemsByTabId(id)
            };

            return this.View(model);
        }
    }
}
