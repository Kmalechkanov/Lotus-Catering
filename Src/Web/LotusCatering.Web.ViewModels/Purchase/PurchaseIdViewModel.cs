namespace LotusCatering.Web.ViewModels.Purchase
{
    using System.Collections.Generic;

    using LotusCatering.Web.ViewModels.OrderItems;
    using LotusCatering.Web.ViewModels.Orders;

    public class PurchaseIdViewModel
    {
        public OrderInspectViewModel Order { get; set; }

        public IEnumerable<OrderItemViewModel> Items { get; set; }
    }
}
