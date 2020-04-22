namespace LotusCatering.Web.ViewModels.Categories
{
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class CategoryDescriptionViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
