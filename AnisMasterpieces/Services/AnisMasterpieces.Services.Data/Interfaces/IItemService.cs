namespace AnisMasterpieces.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AnisMasterpieces.Web.ViewModels.Items;

    public interface IItemService
    {
        IEnumerable<T> GetAllByTabId<T>(string tabId);

        string GetName(string id);

        T GetById<T>(string itemId);
    }
}
