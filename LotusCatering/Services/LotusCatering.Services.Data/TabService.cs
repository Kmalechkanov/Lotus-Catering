namespace LotusCatering.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LotusCatering.Data.Common.Repositories;
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Services.Mapping;

    public class TabService : ITabService
    {
        private readonly IDeletableEntityRepository<Tab> deletableEntityRepository;

        public TabService(IDeletableEntityRepository<Tab> deletableEntityRepository)
        {
            this.deletableEntityRepository = deletableEntityRepository;
        }

        public IEnumerable<T> GetAll<T>()
            => this.deletableEntityRepository.All().To<T>();

        public IEnumerable<T> GetAll<T>(string categoryId)
            => this.deletableEntityRepository.All().Where(t => t.CategoryId == categoryId).To<T>();

        public string GetNameById(string id)
            => this.deletableEntityRepository.All().FirstOrDefault(t => t.Id == id).Name;
    }
}
