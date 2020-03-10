namespace AnisMasterpieces.Web.ViewModels.Tabs
{
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Mapping;

    public class TabNameViewModel : IMapFrom<Tab>
    {
        public string Name { get; set; }
    }
}
