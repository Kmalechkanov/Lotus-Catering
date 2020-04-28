namespace LotusCatering.Web.ViewModels.Images
{
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class ImageBasicViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
