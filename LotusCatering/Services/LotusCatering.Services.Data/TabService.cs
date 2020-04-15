namespace LotusCatering.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Common.Repositories;
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Services.Mapping;

    public class TabService : ITabService
    {
        private readonly IDeletableEntityRepository<Tab> tabRepository;

        public TabService(IDeletableEntityRepository<Tab> tabRepository)
        {
            this.tabRepository = tabRepository;
        }

        public async Task<string> AddAsync(string name, string imageUrl, string categoryId, string description)
        {
            var tab = new Tab
            {
                Name = name,
                ImageUrl = imageUrl,
                CategoryId = categoryId,
                Description = description,
            };

            await this.tabRepository.AddAsync(tab);
            await this.tabRepository.SaveChangesAsync();
            return tab.Id;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var tab = this.tabRepository.All().FirstOrDefault(i => i.Id == id);

            this.tabRepository.Delete(tab);
            var response = await this.tabRepository.SaveChangesAsync();
            return response == 1;
        }

        public IEnumerable<T> GetAll<T>()
            => this.tabRepository.All().To<T>();

        public IEnumerable<T> GetAll<T>(string categoryId)
            => this.tabRepository.All().Where(t => t.CategoryId == categoryId).To<T>();

        public T GetById<T>(string id)
            => this.tabRepository.All().FirstOrDefault(i => i.Id == id).То<T>();

        public string GetNameById(string id)
            => this.tabRepository.All().FirstOrDefault(t => t.Id == id).Name;

        public async Task<bool> UpdateAsync(string id, string name, string categoryId, string description)
        {
            var tab = this.tabRepository.All().FirstOrDefault(i => i.Id == id);
            if (tab == null)
            {
                return false;
            }

            tab.Name = name;
            tab.CategoryId = categoryId;
            tab.Description = description;

            var response = await this.tabRepository.SaveChangesAsync();
            return response == 1;
        }
    }
}
