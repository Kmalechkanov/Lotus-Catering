namespace LotusCatering.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGalleryService
    {
        T GetById<T>(string id);

        IEnumerable<T> GetAll<T>();

        bool IsValidId(string id);

        Task<string> AddAsync(string name);

        Task<bool> UpdateAsync(string id, string name);

        Task<bool> DeleteAsync(string id);
    }
}
