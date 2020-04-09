namespace LotusCatering.Data.Models
{
    public class OrderItem
    {
        public string OrderId { get; set; }

        public virtual Order Order { get; set; }

        public string ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
