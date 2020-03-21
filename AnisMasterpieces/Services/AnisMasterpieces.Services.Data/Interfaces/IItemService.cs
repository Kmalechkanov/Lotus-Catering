namespace AnisMasterpieces.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using AnisMasterpieces.Web.ViewModels.Items;

    public interface IItemService
    {
        IEnumerable<T> GetAllByTabId<T>(string tabId);

        string GetName(string id);

        T GetById<T>(string itemId);

        Task<string> AddAsync(string name, string imageUrl, decimal price, string tabId, string description);
    }
}
