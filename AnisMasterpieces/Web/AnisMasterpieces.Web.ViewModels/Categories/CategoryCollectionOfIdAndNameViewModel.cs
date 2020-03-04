namespace AnisMasterpieces.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoryCollectionOfIdAndNameViewModel
    {
        public ICollection<CategoryIdAndNameViewModel> Categories { get; set; }
    }
}
