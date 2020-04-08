namespace AnisMasterpieces.Web.Areas.Profile.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Helpers;
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Web.Controllers;
    using AnisMasterpieces.Web.ViewModels.Cart;
    using AnisMasterpieces.Web.ViewModels.CartItems;
    using AnisMasterpieces.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

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
                succeed = await this.cartService.AddItemQuantityAsync(cartId, inputModel.ItemId, inputModel.Quantity);
            }
            else
            {
                succeed = await this.cartService.AddItemAsync(cartId, inputModel.ItemId, inputModel.Quantity);
            }

            return this.Json(new { succeed, inputModel });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(CartUpdateInputModel inputModel)
        {
            if (inputModel.ItemId == null)
            {
                return this.RedirectToAction("Index", "Cart", new { area = "Profile" });
            }

            var itemsId = inputModel.ItemId.ToArray();
            var quantities = inputModel.Quantity.ToArray();
            var areRemoved = inputModel.IsRemoved.ToArray();

            var user = await this.userManager.GetUserAsync(this.User);
            var cartId = this.cartService.GetId(user.Id);

            var itemId = string.Empty;
            var quantity = 0;
            var isRemoved = false;

            for (int i = 0; i < itemsId.Length; i++)
            {
                itemId = itemsId[i];
                quantity = quantities[i];
                isRemoved = areRemoved[i] == "true" ? true : false;

                if (isRemoved)
                {
                    var response = await this.cartService.RemoveItemAsync(cartId, itemId);
                    Console.WriteLine(response);
                }
                else
                {
                    await this.cartService.EditItemAsync(cartId, itemId, quantity);
                }
            }

            return this.RedirectToAction("Index", "Cart", new { area = "Profile" });
        }
    }
}
