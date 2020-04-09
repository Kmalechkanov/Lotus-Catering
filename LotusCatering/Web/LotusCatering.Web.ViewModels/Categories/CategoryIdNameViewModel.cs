namespace LotusCatering.Web.ViewModels.Categories
{
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class CategoryIdNameViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
