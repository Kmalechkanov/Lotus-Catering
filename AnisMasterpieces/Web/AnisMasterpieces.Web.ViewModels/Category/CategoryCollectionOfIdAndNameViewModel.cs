namespace AnisMasterpieces.Web.ViewModels.Category
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoryCollectionOfIdAndNameViewModel
    {
        public ICollection<CategoryIdAndNameViewModel> Categories { get; set; }
    }
}
