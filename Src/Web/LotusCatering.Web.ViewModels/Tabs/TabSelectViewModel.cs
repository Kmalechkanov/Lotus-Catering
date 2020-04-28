namespace LotusCatering.Web.ViewModels.Tabs
{
    using System.Collections.Generic;

    public class TabSelectViewModel
    {
        public string Id { get; set; }

        public ICollection<TabIdNameViewModel> Tabs { get; set; }

        public string ReturnUrl { get; set; }
    }
}
