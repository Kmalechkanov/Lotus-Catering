namespace AnisMasterpieces.Web.ViewModels.Category
{
    using AnisMasterpieces.Web.ViewModels.Tabs;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoryNameAndTabNameViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<TabIdNameViewModel> Tabs { get; set; }
    }
}
