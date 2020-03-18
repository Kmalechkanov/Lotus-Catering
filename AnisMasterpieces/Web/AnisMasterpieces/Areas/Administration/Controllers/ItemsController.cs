namespace AnisMasterpieces.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AnisMasterpieces.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class ItemsController : BaseController
    {
        [Authorize(Roles = "Administrator")]
        public IActionResult Add()
        {
            return this.View();
        }
    }
}
