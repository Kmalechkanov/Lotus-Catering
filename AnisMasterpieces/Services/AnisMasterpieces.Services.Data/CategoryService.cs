namespace AnisMasterpieces.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AnisMasterpieces.Data.Common.Repositories;
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services;
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Services.Mapping;
    using AnisMasterpieces.Web.ViewModels.Categories;
    using AnisMasterpieces.Web.ViewModels.Tabs;

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
