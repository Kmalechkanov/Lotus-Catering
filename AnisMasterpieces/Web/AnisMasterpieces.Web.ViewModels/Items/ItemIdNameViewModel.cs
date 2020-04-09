namespace AnisMasterpieces.Web.ViewModels.Items
{
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Mapping;

    public class ItemIdNameViewModel : IMapFrom<Item>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
