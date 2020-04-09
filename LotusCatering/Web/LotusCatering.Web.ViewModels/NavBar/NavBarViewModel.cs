namespace LotusCatering.Web.ViewModels.NavBar
{
    using System.Collections.Generic;

    using LotusCatering.Web.ViewModels.Categories;

    public class NavBarViewModel
    {
        public IEnumerable<CategoryIdNameViewModel> Categories { get; set; }
    }
}
