namespace LotusCatering.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LotusCatering.Data.Common.Repositories;
    using LotusCatering.Data.Models;
    using LotusCatering.Services;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Services.Mapping;
    using LotusCatering.Web.ViewModels.Categories;
    using LotusCatering.Web.ViewModels.Tabs;

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
    }
}
