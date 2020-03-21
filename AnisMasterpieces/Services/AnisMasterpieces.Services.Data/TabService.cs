namespace AnisMasterpieces.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AnisMasterpieces.Data.Common.Repositories;
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Data.Interfaces;
    using AnisMasterpieces.Services.Mapping;

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
