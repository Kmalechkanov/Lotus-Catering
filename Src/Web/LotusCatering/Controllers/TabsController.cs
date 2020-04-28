namespace LotusCatering.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.ViewModels.Items;
    using LotusCatering.Web.ViewModels.Tabs;
    using Microsoft.AspNetCore.Mvc;

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
                Name = this.tabService.GetNameById(id),
                Items = this.itemService.GetAllByTabId<ItemBasicViewModel>(id),
            };

            return this.View(model);
        }
    }
}
