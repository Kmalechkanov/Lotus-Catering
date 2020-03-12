namespace AnisMasterpieces.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Mapping;
    using AnisMasterpieces.Web.ViewModels.Tabs;

    public class CategoryNameAndTabNameViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<TabBasicViewModel> Tabs { get; set; }
    }
}
