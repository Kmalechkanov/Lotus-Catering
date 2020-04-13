namespace LotusCatering.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IItemService
    {
        IEnumerable<T> GetAllByTabId<T>(string tabId);

        IEnumerable<T> GetAll<T>();

        bool IsValidId(string id);

        string GetName(string id);

        T GetById<T>(string itemId);

        Task<string> AddAsync(string name, string imageUrl, double price, string tabId, string description);

        Task<bool> UpdateAsync(string id, string name, double price, string tabId, string description);
    }
}
