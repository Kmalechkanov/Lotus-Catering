namespace AnisMasterpieces.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AnisMasterpieces.Data.Common.Repositories;
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Services.Mapping;
    using AnisMasterpieces.Web.ViewModels.Items;
    using Microsoft.EntityFrameworkCore;

    public class CartService : ICartService
    {
        private readonly IApplicationDbContext context;

        public CartService(IApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> GetCartItemsByUserId<T>(string userId)
        {
            var cartItems = this.context.CartItems.Where(ci => ci.Cart.User.Id == userId).Select(ci => ci.Item).To<T>();
            /*
            var cartItems = this.context.Items
            .FromSqlRaw("SELECT * FROM Items i " +
            "FULL JOIN CartItems ci ON ci.ItemId = i.id " +
            $"WHERE ci.CartId = (SELECT TOP(1) c.Id FROM Carts c WHERE c.UserId = '{userId}')")
            .Select(ci => new ItemBasicViewModel
            {
                Id = ci.Id,
                ImageUrl = ci.ImageUrl,
                Name = ci.Name,
                Price = ci.Price.ToString(),
            }).ToArray(); */

            return cartItems;
        }
    }
}
