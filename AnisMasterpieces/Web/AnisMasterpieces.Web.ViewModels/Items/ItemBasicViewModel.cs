namespace AnisMasterpieces.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Mapping;

    public class ItemBasicViewModel : IMapFrom<Item>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }
    }
}
