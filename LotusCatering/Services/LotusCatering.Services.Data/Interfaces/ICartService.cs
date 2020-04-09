namespace LotusCatering.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using LotusCatering.Web.ViewModels.Items;

    public interface ICartService
    {
        IEnumerable<ItemBasicViewModel> GetCartItemsByUserId(string userId);

        string GetId(string userId);

        bool IsItemInCart(string cartId, string itemId);

        int GetQuantity(string cartId, string itemId);

        Task<bool> AddItemAsync(string cartId, string itemId, int quantity);

        Task<bool> AddItemQuantityAsync(string cartId, string itemId, int quantity);

        Task<bool> EditItemAsync(string cartId, string itemId, int quantity);

        Task<bool> RemoveItemAsync(string cartId, string itemId);
    }
}
