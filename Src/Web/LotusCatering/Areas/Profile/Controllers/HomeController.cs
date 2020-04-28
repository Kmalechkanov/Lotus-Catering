namespace LotusCatering.Web.Areas.Profile.Controllers
{
    using System.Web.Mvc;

    using LotusCatering.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Profile")]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
