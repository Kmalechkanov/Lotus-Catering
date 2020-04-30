namespace LotusCatering.Web.ViewModels.OrderItems
{
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Mapping;

    public class OrderItemViewModel : IMapFrom<OrderItem>
    {
        public string ItemId { get; set; }

        public int Quantity { get; set; }
    }
}
