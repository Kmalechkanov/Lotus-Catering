namespace AnisMasterpieces.Services.Data.Interfaces
{
    using System.Collections.Generic;

    using AnisMasterpieces.Web.ViewModels.Items;

    public interface ICartService
    {
        IEnumerable<T> GetCartItemsByUserId<T>(string userId);
    }
}
