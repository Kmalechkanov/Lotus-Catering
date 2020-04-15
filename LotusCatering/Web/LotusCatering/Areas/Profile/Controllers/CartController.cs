namespace LotusCatering.Web.Areas.Profile.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.Controllers;
    using LotusCatering.Web.ViewModels.Cart;
    using LotusCatering.Web.ViewModels.CartItems;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
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

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var cartItems = this.cartService.GetCartItemsByUserId(user.Id);

            var viewModel = new CartWithItemsViewModel
            {
                Items = cartItems,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<JsonResult> AddItem(CartItemInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new { succeed = "false", inputModel });
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var cartId = this.cartService.GetId(user.Id);

            bool succeed;

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

            string itemId;
            int quantity;
            bool isRemoved;

            for (int i = 0; i < itemsId.Length; i++)
            {
                itemId = itemsId[i];
                quantity = quantities[i];
                isRemoved = areRemoved[i] == "true" ? true : false;

                if (isRemoved)
                {
                    await this.cartService.RemoveItemAsync(cartId, itemId);
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
