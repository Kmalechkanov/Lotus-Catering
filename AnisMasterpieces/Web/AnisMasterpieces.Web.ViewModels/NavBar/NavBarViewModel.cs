namespace AnisMasterpieces.Web.ViewModels.NavBar
{
    using AnisMasterpieces.Web.ViewModels.Categories;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NavBarViewModel
    {
        public IEnumerable<CategoryIdAndNameViewModel> Categories { get; set; }
    }
}
