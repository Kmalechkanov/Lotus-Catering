namespace AnisMasterpieces.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ITabService
    {
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAll<T>(string categoryId);

        string GetNameById(string id);
    }
}
