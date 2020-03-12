namespace AnisMasterpieces.Web.ViewModels.Tabs
{
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Mapping;

    public class TabBasicViewModel : IMapFrom<Tab>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
