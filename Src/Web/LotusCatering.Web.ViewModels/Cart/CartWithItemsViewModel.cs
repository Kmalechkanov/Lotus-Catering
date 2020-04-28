namespace LotusCatering.Web.ViewModels.Cart
{
    using System.Collections.Generic;

    using LotusCatering.Web.ViewModels.Items;

    public class CartWithItemsViewModel
    {
        public IEnumerable<ItemBasicViewModel> Items { get; set; }
    }
}
