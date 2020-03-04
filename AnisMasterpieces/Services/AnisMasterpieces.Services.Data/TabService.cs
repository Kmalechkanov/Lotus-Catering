namespace AnisMasterpieces.Services.Data
{
    using AnisMasterpieces.Data.Common.Repositories;
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Data.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TabService : ITabService
    {
        private readonly IDeletableEntityRepository<Tab> deletableEntityRepository;

        public TabService(IDeletableEntityRepository<Tab> deletableEntityRepository)
        {
            this.deletableEntityRepository = deletableEntityRepository;
        }

        public IEnumerable<string> GetAll()
            => this.deletableEntityRepository.All().Select(x => x.Name);
    }
}
