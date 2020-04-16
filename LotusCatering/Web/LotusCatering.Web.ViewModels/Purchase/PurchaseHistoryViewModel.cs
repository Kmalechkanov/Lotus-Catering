namespace LotusCatering.Web.ViewModels.Purchase
{
    using System.Collections.Generic;

    using LotusCatering.Web.ViewModels.Orders;

    public class PurchaseHistoryViewModel
    {
        public ICollection<OrderBasicViewModel> Orders { get; set; }
    }
}
