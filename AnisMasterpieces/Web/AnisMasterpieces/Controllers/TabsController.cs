namespace AnisMasterpieces.Web.Controllers
{
    using AnisMasterpieces.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TabsController : BaseController
    {
        private readonly ITabService tabService;

        public TabsController(ITabService tabService)
        {
            this.tabService = tabService;
        }

        public IActionResult Id(string id)
        {
            return this.View();
        }
    }
}
