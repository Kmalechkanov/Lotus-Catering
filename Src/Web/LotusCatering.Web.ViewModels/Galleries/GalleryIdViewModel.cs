namespace LotusCatering.Web.ViewModels.Galleries
{
    using System.Collections.Generic;

    using LotusCatering.Web.ViewModels.Images;

    public class GalleryIdViewModel
    {
        public string Id { get; set; }

        public ICollection<ImageBasicViewModel> Images { get; set; }
    }
}
