namespace AnisMasterpieces.Web.ViewModels.Tabs
{
    using System.Collections.Generic;

    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Mapping;
    using AnisMasterpieces.Web.ViewModels.Items;

    public class TabInfoWithItemsViewModel : IMapFrom<Tab>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ItemNameViewModel> Items { get; set; }
    }
}
