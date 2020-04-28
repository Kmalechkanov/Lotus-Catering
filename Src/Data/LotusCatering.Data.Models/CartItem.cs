namespace LotusCatering.Data.Models
{
    public class CartItem
    {
        public string CartId { get; set; }

        public Cart Cart { get; set; }

        public string ItemId { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
}
