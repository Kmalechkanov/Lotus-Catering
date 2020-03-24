namespace AnisMasterpieces.Web.Areas.Profile.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Web.Controllers;
    using AnisMasterpieces.Web.ViewModels.Cart;
    using AnisMasterpieces.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Area("Profile")]
    public class CartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly UserManager<ApplicationUser> userManager;

        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            this.cartService = cartService;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var cartItems = this.cartService.GetCartItemsByUserId<ItemBasicViewModel>(user.Id);

            var viewModel = new CartWithItemsViewModel
            {
                Items = cartItems,
            };

            return this.View(viewModel);
        }
    }
}
