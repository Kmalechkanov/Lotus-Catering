namespace LotusCatering.Web.ViewModels.Purchase
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PurchaseProceedInputModel
    {
        public double TotalPrice { get; set; }

        public int TotalItems { get; set; }

        public string AdditionalInformation { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }
    }
}
