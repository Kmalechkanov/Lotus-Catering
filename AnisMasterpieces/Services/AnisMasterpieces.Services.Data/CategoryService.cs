namespace AnisMasterpieces.Services.Data
{
    using AnisMasterpieces.Data.Common.Repositories;
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Services.Mapping;
    using System.Collections.Generic;
    using System.Linq;
    using AnisMasterpieces.Services;
    using AnisMasterpieces.Web.ViewModels.Category;
    using AnisMasterpieces.Web.ViewModels.Tabs;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<CategoryIdAndNameViewModel> GetAll()
            => this.categoriesRepository.All().Select(c => new CategoryIdAndNameViewModel() { 
                Id = c.Id,
                Name = c.Name
            });

        public bool IsValidId(string id)
            => this.categoriesRepository.All().Any(c => c.Id == id);

        public string GetNameById(string id)
            => this.categoriesRepository.All().FirstOrDefault(c => c.Id == id).Name;

    }
}
