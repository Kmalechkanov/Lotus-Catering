namespace AnisMasterpieces.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Cart
    {
        public Cart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CartItems = new HashSet<CartItem>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
