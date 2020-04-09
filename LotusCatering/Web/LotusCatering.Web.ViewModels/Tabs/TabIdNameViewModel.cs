namespace LotusCatering.Web.ViewModels.Tabs
{
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class TabIdNameViewModel : IMapFrom<Tab>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
