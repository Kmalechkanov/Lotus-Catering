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
            this.CartItems = new HashSet<CartItems>();
        }

        public string Id { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<CartItems> CartItems { get; set; }
    }
}
