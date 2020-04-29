namespace LotusCatering.Web.Areas.Administration.Controllers
{
    using LotusCatering.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class HomeController : BaseController
    {
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
