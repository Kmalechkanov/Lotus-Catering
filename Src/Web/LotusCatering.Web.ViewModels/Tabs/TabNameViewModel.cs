namespace LotusCatering.Web.ViewModels.Tabs
{
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class TabNameViewModel : IMapFrom<Tab>
    {
        public string Name { get; set; }
    }
}
