namespace AnisMasterpieces.Web.Areas.Profile.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AnisMasterpieces.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CartController : BaseController
    {
        [Authorize]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
