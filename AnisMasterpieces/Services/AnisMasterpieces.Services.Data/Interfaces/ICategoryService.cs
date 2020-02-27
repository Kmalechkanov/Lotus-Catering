namespace AnisMasterpieces.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IEnumerable<string> GetAll();
    }
}
