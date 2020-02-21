namespace AnisMasterpieces.Services.Data
{
    using AnisMasterpieces.Data.Common.Repositories;
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Mapping;
    using System.Collections.Generic;
    using System.Linq;

    public class SettingsService : ISettingsService
    {
        private readonly IDeletableEntityRepository<Setting> settingRepository;

        public SettingsService(IDeletableEntityRepository<Setting> settingRepository)
        {
            this.settingRepository = settingRepository;
        }
         
        public IEnumerable<T> GetAll<T>()
            => this.settingRepository.All().To<T>().ToList();

        public int GetCount()
            => this.settingRepository.All().Count();
    }
}
