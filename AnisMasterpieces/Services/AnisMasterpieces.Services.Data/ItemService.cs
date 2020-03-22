namespace AnisMasterpieces.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnisMasterpieces.Data.Common.Repositories;
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Services.Mapping;
    using AnisMasterpieces.Web.ViewModels.Items;

    public class ItemService : IItemService
    {
        private readonly IDeletableEntityRepository<Item> itemRepository;

        public ItemService(IDeletableEntityRepository<Item> itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public T GetById<T>(string id)
            => this.itemRepository.All().FirstOrDefault(i => i.Id == id).То<T>();

        public bool IsValidId(string id)
            => this.itemRepository.All().Any(i => i.Id == id);

        public string GetName(string id)
            => this.itemRepository.All().FirstOrDefault(i => i.Id == id).Name;

        public IEnumerable<T> GetAllByTabId<T>(string tabId)
            => this.itemRepository.All().Where(i => i.TabId == tabId).To<T>();

        public async Task<string> AddAsync(string name, string imageUrl, decimal price, string tabId, string description)
        {
            var item = new Item
            {
                Name = name,
                ImageUrl = imageUrl,
                Price = price,
                TabId = tabId,
                Description = description,
            };

            await this.itemRepository.AddAsync(item);
            await this.itemRepository.SaveChangesAsync();
            return item.Id;
        }
    }
}
