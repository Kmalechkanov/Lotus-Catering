namespace LotusCatering.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;
    using LotusCatering.Web.ViewModels.Tabs;

    public class CategoryNameAndTabNameViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<TabBasicViewModel> Tabs { get; set; }
    }
}
