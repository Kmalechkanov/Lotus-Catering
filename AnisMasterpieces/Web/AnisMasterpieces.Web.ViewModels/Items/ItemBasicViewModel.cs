namespace AnisMasterpieces.Web.ViewModels.Items
{
    using AnisMasterpieces.Data.Models;
    using AnisMasterpieces.Services.Mapping;

    public class ItemBasicViewModel : IMapFrom<Item>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Price { get; set; }

        public int Quantity { get; set; }
    }
}
