namespace LotusCatering.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using LotusCatering.Web.ViewModels.Categories;
    using LotusCatering.Web.ViewModels.Galleries;

    public class HomeViewModel
    {
        public ICollection<CategoryDescriptionViewModel> Categories { get; set; }

        public ICollection<GalleryIdNameViewModel> Galleries { get; set; }
    }
}
