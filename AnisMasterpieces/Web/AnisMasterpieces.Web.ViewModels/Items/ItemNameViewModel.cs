namespace AnisMasterpieces.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Mapping;

    public class ItemNameViewModel : IMapFrom<Item>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
