namespace AnisMasterpieces.Services.Data.Interfaces
{
    using AnisMasterpieces.Web.ViewModels.Categories;
    using AnisMasterpieces.Web.ViewModels.Tabs;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();

        string GetNameById(string id);

        bool IsValidId(string id);
    }
}
