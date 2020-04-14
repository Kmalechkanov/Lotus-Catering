namespace LotusCatering.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITabService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAll<T>(string categoryId);

        T GetById<T>(string id);

        string GetNameById(string id);

        Task<string> AddAsync(string name, string imageUrl, string categoryId, string description);

        Task<bool> UpdateAsync(string id, string name, string categoryId, string description);

        Task<bool> DeleteAsync(string id);
    }
}
