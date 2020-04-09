namespace LotusCatering.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Common.Repositories;
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Services.Mapping;

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

        public async Task<bool> UpdateAsync(string id, string name, decimal price, string tabId, string description)
        {
            var item = this.itemRepository.All().FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return false;
            }

            item.Name = name;
            item.Price = price;
            item.TabId = tabId;
            item.Description = description;

            var response = await this.itemRepository.SaveChangesAsync();
            return response == 1;
        }

        public IEnumerable<T> GetAll<T>()
            => this.itemRepository.All().To<T>();
    }
}
