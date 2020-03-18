﻿namespace AnisMasterpieces.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AnisMasterpieces.Data.Common.Repositories;
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Services.Mapping;
    using AnisMasterpieces.Web.ViewModels.Items;

    public class ItemService : IItemService
    {
        private readonly IDeletableEntityRepository<Item> deletableEntityRepository;

        public ItemService(IDeletableEntityRepository<Item> deletableEntityRepository)
        {
            this.deletableEntityRepository = deletableEntityRepository;
        }

        public T GetById<T>(string id)
            => this.deletableEntityRepository.All().FirstOrDefault(i => i.Id == id).То<T>();

        public string GetName(string id)
            => this.deletableEntityRepository.All().FirstOrDefault(i => i.Id == id).Name;

        public IEnumerable<T> GetAllByTabId<T>(string tabId)
            => this.deletableEntityRepository.All().Where(i => i.TabId == tabId).To<T>();
    }
}