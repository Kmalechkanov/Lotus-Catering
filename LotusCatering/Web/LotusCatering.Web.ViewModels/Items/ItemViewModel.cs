﻿namespace LotusCatering.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class ItemViewModel : IMapFrom<Item>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        // public string UserCartId { get; set; }
    }
}