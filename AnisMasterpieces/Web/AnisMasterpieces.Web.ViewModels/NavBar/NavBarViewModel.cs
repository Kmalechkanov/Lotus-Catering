namespace AnisMasterpieces.Web.ViewModels.NavBar
{
    using System.Collections.Generic;

    using AnisMasterpieces.Web.ViewModels.Categories;

    public class NavBarViewModel
    {
        public IEnumerable<CategoryIdNameViewModel> Categories { get; set; }
    }
}
