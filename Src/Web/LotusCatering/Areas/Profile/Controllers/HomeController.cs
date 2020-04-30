namespace LotusCatering.Web.Areas.Profile.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.Controllers;
    using LotusCatering.Web.ViewModels.Orders;
    using LotusCatering.Web.ViewModels.Profile;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Profile")]
    public class HomeController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IOrderService orderService;
        private readonly RoleManager<ApplicationRole> roleManager;

        public HomeController(UserManager<ApplicationUser> userManager, IOrderService orderService, RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.orderService = orderService;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var orders = this.orderService.GetAll<OrderBasicViewModel>(user.Id);

            var viewModel = new ProfileViewModel
            {
                Username = user.UserName,
                TotalPurchases = orders.Count(),
            };

            return this.View(viewModel);
        }
    }
}
