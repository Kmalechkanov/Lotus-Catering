namespace LotusCatering.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IEnumerable<T> GetAll<T>();

        string GetNameById(string id);

        bool IsValidId(string id);
    }
}
