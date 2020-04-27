namespace LotusCatering.Web.ViewModels.Items
{
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class ItemBasicViewModel : IMapFrom<Item>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
