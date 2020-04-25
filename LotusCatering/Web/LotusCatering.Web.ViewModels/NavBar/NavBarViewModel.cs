namespace LotusCatering.Web.ViewModels.NavBar
{
    using System.Collections.Generic;

    using LotusCatering.Web.ViewModels.Categories;
    using LotusCatering.Web.ViewModels.Galleries;

    public class NavBarViewModel
    {
        public IEnumerable<CategoryIdNameViewModel> Categories { get; set; }

        public IEnumerable<GalleryIdNameViewModel> Galleries { get; set; }
    }
}
