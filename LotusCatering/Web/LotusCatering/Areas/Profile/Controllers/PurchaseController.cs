namespace LotusCatering.Web.Areas.Profile.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.Controllers;
    using LotusCatering.Web.ViewModels.Purchase;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Profile")]
    public class PurchaseController : BaseController
    {
        private readonly ICartService cartService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IOrderService orderService;

        public PurchaseController(ICartService cartService, UserManager<ApplicationUser> userManager, IOrderService orderService)
        {
            this.cartService = cartService;
            this.userManager = userManager;
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Proceed()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var cartId = this.cartService.GetId(user.Id);

            var totalPrice = this.cartService.GetTotalPrice(cartId);
            var totalQuantity = this.cartService.GetTotalQuantity(cartId);

            var viewMoodel = new PurchaseProceedViewModel
            {
                TotalPrice = totalPrice,
                TotalItems = totalQuantity,
                DeliveryDate = DateTime.Now,
            };

            return this.View(viewMoodel);
        }

        [HttpPost]
        public async Task<IActionResult> Proceed(PurchaseProceedInputModel inputModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var cartId = this.cartService.GetId(user.Id);

            var totalPrice = this.cartService.GetTotalPrice(cartId);
            var totalQuantity = this.cartService.GetTotalQuantity(cartId);

            var currentDate = DateTime.Now;
            if (DateTime.Compare(inputModel.DeliveryDate, currentDate.AddDays(3)) == -1
                || DateTime.Compare(inputModel.DeliveryDate, currentDate.AddDays(30)) == 1)
            {
                this.ModelState.AddModelError(string.Empty, $"Датата трябва да бъде между {currentDate.AddDays(3).ToString("MM/dd/yyyy")} и {currentDate.AddDays(30).ToString("MM/dd/yyyy")}.");
            }

            if (totalQuantity < 50)
            {
                this.ModelState.AddModelError(string.Empty, $"Не можете да направите покупка с по-малко от {50} хапки.");
            }

            if (totalQuantity > 1000)
            {
                this.ModelState.AddModelError(string.Empty, $"Не можете да направите покупка с повече от {1000} хапки.");
            }

            if (!this.ModelState.IsValid)
            {
                var viewModel = new PurchaseProceedViewModel
                {
                    AdditionalInformation = inputModel.AdditionalInformation,
                    DeliveryDate = inputModel.DeliveryDate,
                    TotalItems = totalQuantity,
                    TotalPrice = totalPrice,
                };
                return this.View(viewModel);
            }

            var orderId = await this.orderService.AddAsync(currentDate, inputModel.DeliveryDate, cartId, user.Id, inputModel.AdditionalInformation);
            await this.cartService.RemoveAllItemsAsync(cartId);

            return this.View();
        }
    }
}
