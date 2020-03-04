namespace AnisMasterpieces.Services.Data
{
    using AnisMasterpieces.Data.Common.Repositories;
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Data.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AnisMasterpieces.Web.ViewModels.Tabs;
    public class TabService : ITabService
    {
        private readonly IDeletableEntityRepository<Tab> deletableEntityRepository;

        public TabService(IDeletableEntityRepository<Tab> deletableEntityRepository)
        {
            this.deletableEntityRepository = deletableEntityRepository;
        }

        public IEnumerable<string> GetAll()
            => this.deletableEntityRepository.All().Select(t => t.Id).ToArray();

        public IEnumerable<TabIdNameViewModel> GetAllNamesByCategoryId(string categoryId)
            =>this.deletableEntityRepository.All().Where(t=>t.CategoryId == categoryId).Select(t => new TabIdNameViewModel()
            {
                Id = t.Id,
                Name = t.Name
            }).ToArray();
    }
}
