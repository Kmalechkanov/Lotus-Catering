namespace LotusCatering.Web.ViewModels.Orders
{
    using System;

    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class OrderBasicViewModel : IMapFrom<Order>
    {
        public string Id { get; set; }

        public DateTime PaymentDate { get; set; }

        public double TotalPrice { get; set; }
    }
}
