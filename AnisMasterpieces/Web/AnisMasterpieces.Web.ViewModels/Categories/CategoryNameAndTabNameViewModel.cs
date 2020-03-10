namespace AnisMasterpieces.Web.ViewModels.Categories
{
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Mapping;
    using AnisMasterpieces.Web.ViewModels.Tabs;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoryNameAndTabNameViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<TabIdNameViewModel> Tabs { get; set; }
    }
}
