namespace AnisMasterpieces.Web.ViewModels.Tabs
{
    using AnisMasterpieces.Web.ViewModels.Items;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TabInfoWithItemsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<ItemNameViewModel> Items { get; set; }
    }
}
