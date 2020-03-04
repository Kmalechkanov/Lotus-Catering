namespace AnisMasterpieces.Web.ViewModels.NavBar
{
    using AnisMasterpieces.Web.ViewModels.Category;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NavBarViewModel
    {
        public IEnumerable<CategoryIdAndNameViewModel> Categories { get; set; }
    }
}
