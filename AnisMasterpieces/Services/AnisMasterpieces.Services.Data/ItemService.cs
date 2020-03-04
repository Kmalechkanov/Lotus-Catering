namespace AnisMasterpieces.Services.Data
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
        public ICollection<ItemNameViewModel> GetItemsByTabId(string tabId)
            => this.deletableEntityRepository.All().Where(t => t.TabId == tabId).Select(t => new ItemNameViewModel()
            {
                Id = t.Id,
                Name = t.Name
            }).ToArray();
    }
}
