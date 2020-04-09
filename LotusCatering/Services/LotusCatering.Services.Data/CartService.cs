namespace LotusCatering.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Common.Repositories;
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Web.ViewModels.Items;

    public class CartService : ICartService
    {
        private readonly IApplicationDbContext context;
        private readonly IRepository<Cart> cartRepository;

        public CartService(IApplicationDbContext context, IRepository<Cart> cartRepository)
        {
            this.context = context;
            this.cartRepository = cartRepository;
        }

        public async Task<bool> AddItemAsync(string cartId, string itemId, int quantity)
        {
            var cartItem = new CartItem
            {
                CartId = cartId,
                ItemId = itemId,
                Quantity = quantity,
            };

            await this.context.CartItems.AddAsync(cartItem);
            var success = await this.context.SaveChangesAsync(default);

            return success == 1;
        }

        public async Task<bool> AddItemQuantityAsync(string cartId, string itemId, int quantity)
        {
            var cartItem = this.context.CartItems.FirstOrDefault(ci => ci.CartId == cartId && ci.ItemId == itemId);
            var sum = cartItem.Quantity + quantity;

            if (sum < 10 || sum > 300)
            {
                return false;
            }

            cartItem.Quantity = sum;
            var success = await this.context.SaveChangesAsync(default);

            return success == 1;
        }

        public async Task<bool> EditItemAsync(string cartId, string itemId, int quantity)
        {
            var cartItem = this.context.CartItems.FirstOrDefault(ci => ci.CartId == cartId && ci.ItemId == itemId);

            if (quantity < 10 || quantity > 300)
            {
                return false;
            }

            cartItem.Quantity = quantity;
            var success = await this.context.SaveChangesAsync(default);

            return success == 1;
        }

        public IEnumerable<ItemBasicViewModel> GetCartItemsByUserId(string userid)
            => this.context.CartItems.Where(ci => ci.CartId == this.GetId(userid)).Select(ci => new ItemBasicViewModel
            {
                Id = ci.Item.Id,
                Name = ci.Item.Name,
                ImageUrl = ci.Item.ImageUrl,
                Price = ci.Item.Price.ToString(),
                Quantity = ci.Quantity,
            }).ToArray();

        public string GetId(string userId)
            => this.cartRepository.All().FirstOrDefault(c => c.UserId == userId).Id;

        public int GetQuantity(string cartId, string itemId)
            => this.context.CartItems.FirstOrDefault(ci => ci.CartId == cartId && ci.ItemId == itemId).Quantity;

        public bool IsItemInCart(string cartId, string itemId)
            => this.context.CartItems.Any(ci => ci.CartId == cartId && ci.ItemId == itemId);

        public async Task<bool> RemoveItemAsync(string cartId, string itemId)
        {
            var cartItem = new CartItem
            {
                CartId = cartId,
                ItemId = itemId,
            };

            this.context.CartItems.Remove(cartItem);
            var success = await this.context.SaveChangesAsync(default);

            return success == 1;
        }
    }
}
