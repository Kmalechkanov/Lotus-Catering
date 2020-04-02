namespace AnisMasterpieces.Web.Controllers
{
    using System.Security.Claims;

    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Mvc;

    public class ItemsController : BaseController
    {
        private readonly IItemService itemService;
        private readonly ICartService cartService;

        public ItemsController(IItemService itemService, ICartService cartService)
        {
            this.itemService = itemService;
            this.cartService = cartService;
        }

        public IActionResult Id(string id)
        {
            if (!this.itemService.IsValidId(id))
            {
                return this.Redirect("/");
            }

            var item = this.itemService.GetById<ItemViewModel>(id);

            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //if (userId != null)
            //{
            //    item.UserCartId = this.cartService.GetId(userId);
            //}

            return this.View(item);
        }
    }
}
