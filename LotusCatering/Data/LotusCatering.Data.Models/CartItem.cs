namespace LotusCatering.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CartItem
    {
        public string CartId { get; set; }

        public Cart Cart { get; set; }

        public string ItemId { get; set; }

        public Item Item { get; set; }

        [Range(10, 200)]
        public int Quantity { get; set; }
    }
}
