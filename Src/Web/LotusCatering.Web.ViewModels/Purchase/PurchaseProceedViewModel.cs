namespace LotusCatering.Web.ViewModels.Purchase
{
    using System;

    public class PurchaseProceedViewModel
    {
        public double TotalPrice { get; set; }

        public int TotalItems { get; set; }

        public string AdditionalInformation { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
