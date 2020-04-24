namespace LotusCatering.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Common.Repositories;
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Services.Mapping;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<T> GetAll<T>()
           => this.categoriesRepository.All().To<T>();

        public bool IsValidId(string id)
            => this.categoriesRepository.All().Any(c => c.Id == id);

        public string GetNameById(string id)
            => this.categoriesRepository.All().FirstOrDefault(c => c.Id == id).Name;

        public async Task<string> AddAsync(string name, string description, string imageUrl)
        {
            var category = new Category
            {
                Name = name,
                ImageUrl = imageUrl,
                Description = description,
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();
            return category.Id;
        }

        public async Task<bool> UpdateAsync(string id, string name, string description)
        {
            var category = this.categoriesRepository.All().FirstOrDefault(i => i.Id == id);
            if (category == null)
            {
                return false;
            }

            category.Name = name;
            category.Description = description;

            var response = await this.categoriesRepository.SaveChangesAsync();
            return response == 1;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var category = this.categoriesRepository.All().FirstOrDefault(i => i.Id == id);

            this.categoriesRepository.Delete(category);
            var response = await this.categoriesRepository.SaveChangesAsync();
            return response == 1;
        }

        public T GetById<T>(string id)
            => this.categoriesRepository.All().FirstOrDefault(i => i.Id == id).То<T>();

        public async Task<bool> UpdateImageAsync(string id, string imageUrl)
        {
            var item = this.categoriesRepository.All().FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return false;
            }

            item.ImageUrl = imageUrl;

            var response = await this.categoriesRepository.SaveChangesAsync();
            return response == 1;
        }
    }
}
