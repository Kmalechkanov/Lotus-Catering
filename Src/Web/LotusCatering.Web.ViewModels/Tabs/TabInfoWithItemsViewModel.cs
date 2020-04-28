namespace LotusCatering.Web.ViewModels.Tabs
{
    using System.Collections.Generic;

    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;
    using LotusCatering.Web.ViewModels.Items;

    public class TabInfoWithItemsViewModel : IMapFrom<Tab>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ItemBasicViewModel> Items { get; set; }
    }
}
