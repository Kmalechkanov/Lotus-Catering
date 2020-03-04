﻿namespace AnisMasterpieces.Services.Data
{
    using AnisMasterpieces.Data.Common.Repositories;
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Web.ViewModels.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ItemService : IItemService
    {
        private readonly IDeletableEntityRepository<Item> deletableEntityRepository;

        public ItemService(IDeletableEntityRepository<Item> deletableEntityRepository)
        {
            this.deletableEntityRepository = deletableEntityRepository;
        }

        public string GetItemName(string id)
            => this.deletableEntityRepository.All().FirstOrDefault(i => i.Id == id).Name;

        public ICollection<ItemNameViewModel> GetItemsByTabId(string tabId)
            => this.deletableEntityRepository.All().Where(i => i.TabId == tabId).Select(i => new ItemNameViewModel()
            {
                Id = i.Id,
                Name = i.Name
            }).ToArray();
    }
}
