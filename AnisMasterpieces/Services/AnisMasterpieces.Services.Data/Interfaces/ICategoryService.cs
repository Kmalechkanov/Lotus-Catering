namespace AnisMasterpieces.Services.Data.Interfaces
{
    using AnisMasterpieces.Web.ViewModels.Category;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();

        IEnumerable<string> CategoryTabs();

        bool IsValidId(string id);
    }
}
