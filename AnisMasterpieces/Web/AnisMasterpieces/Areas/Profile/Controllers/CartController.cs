namespace AnisMasterpieces.Web.Areas.Profile.Controllers
{
    using System.Threading.Tasks;

    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Web.Controllers;
    using AnisMasterpieces.Web.ViewModels.Cart;
    using AnisMasterpieces.Web.ViewModels.CartItems;
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
            var cartItems = this.cartService.GetCartItemsByUserId(user.Id);
            var cartId = this.cartService.GetId(user.Id);

            var viewModel = new CartWithItemsViewModel
            {
                Items = cartItems,
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> AddItem(CartItemInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new { succeed = "false", inputModel });
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var cartId = this.cartService.GetId(user.Id);

            bool succeed = false;

            if (this.cartService.IsItemInCart(cartId, inputModel.ItemId))
            {
                succeed = await this.cartService.EditItemAsync(cartId, inputModel.ItemId, inputModel.Quantity);
            }
            else
            {
                succeed = await this.cartService.AddItemAsync(cartId, inputModel.ItemId, inputModel.Quantity);
            }

            return this.Json(new { succeed, inputModel });
        }
    }
}
