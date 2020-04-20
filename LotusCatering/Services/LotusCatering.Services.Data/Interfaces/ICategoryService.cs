namespace LotusCatering.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        T GetById<T>(string id);

        IEnumerable<T> GetAll<T>();

        string GetNameById(string id);

        bool IsValidId(string id);

        Task<string> AddAsync(string name, string description, string imageUrl);

        Task<bool> UpdateAsync(string id, string name, string description);

        Task<bool> DeleteAsync(string id);
    }
}
