namespace AnisMasterpieces.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ICartService
    {
        IEnumerable<T> GetAll<T>();
    }
}
