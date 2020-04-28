namespace LotusCatering.Web.ViewModels.Items
{
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class ItemIdNameViewModel : IMapFrom<Item>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
