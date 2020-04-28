
namespace LotusCatering.Web.ViewModels.Items
{
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class ItemViewModel : IMapFrom<Item>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
    }
}
