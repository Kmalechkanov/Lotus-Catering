namespace AnisMasterpieces.Web.ViewModels.Cart
{
    using System.Collections.Generic;

    using AnisMasterpieces.Web.ViewModels.Items;

    public class CartWithItemsViewModel
    {
        public IEnumerable<ItemBasicViewModel> Items { get; set; }
    }
}
