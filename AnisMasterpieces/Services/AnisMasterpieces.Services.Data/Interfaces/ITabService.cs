namespace AnisMasterpieces.Services.Data.Interfaces
{
    using AnisMasterpieces.Web.ViewModels.Tabs;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITabService
    {
        IEnumerable<string> GetAll();
        
        IEnumerable<TabIdNameViewModel> GetAllNamesByCategoryId(string categoryId);
    }
}
