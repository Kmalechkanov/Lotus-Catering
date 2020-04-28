namespace LotusCatering.Web.ViewModels.Orders
{
    using System;

    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class OrderInspectViewModel : IMapFrom<Order>
    {
        public string Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public double TotalPrice { get; set; }

        public string AdditionalInformation { get; set; }
    }
}
