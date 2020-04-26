namespace LotusCatering.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using LotusCatering.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    [Area("Administration")]
    public class GalleriesController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Add()
        {
            return this.View();
        }
    }
}
