namespace AnisMasterpieces.Web.ViewModels.Tabs
{
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Mapping;

    public class TabIdNameViewModel : IMapFrom<Tab>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
