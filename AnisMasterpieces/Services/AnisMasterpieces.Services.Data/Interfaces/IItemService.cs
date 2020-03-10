namespace AnisMasterpieces.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AnisMasterpieces.Web.ViewModels.Items;

    public interface IItemService
    {
        IEnumerable<T> GetItemsByTabId<T>(string tabId);

        string GetItemName(string id); 
    }
}
