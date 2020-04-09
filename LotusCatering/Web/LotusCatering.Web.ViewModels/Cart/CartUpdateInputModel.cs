namespace LotusCatering.Web.ViewModels.Cart
{
    using System.Collections.Generic;

    public class CartUpdateInputModel
    {
        public ICollection<int> Quantity { get; set; }

        public ICollection<string> ItemId { get; set; }

        public ICollection<string> IsRemoved { get; set; }
    }
}
