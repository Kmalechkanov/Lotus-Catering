namespace AnisMasterpieces.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoryController : BaseController
    {
        public CategoryController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
