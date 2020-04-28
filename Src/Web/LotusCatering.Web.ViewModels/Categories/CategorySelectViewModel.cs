namespace LotusCatering.Web.ViewModels.Categories
{
    using System.Collections.Generic;

    public class CategorySelectViewModel
    {
        public string Id { get; set; }

        public ICollection<CategoryIdNameViewModel> Categories { get; set; }

        public string ReturnUrl { get; set; }
    }
}
