namespace AnisMasterpieces.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CartItem
    {
        public string CartId { get; set; }

        public Cart Cart { get; set; }

        public string ItemId { get; set; }

        public Item Item { get; set; }
    }
}
