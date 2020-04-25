namespace LotusCatering.Web.ViewModels.Galleries
{
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class GalleryIdNameViewModel : IMapFrom<Gallery>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
