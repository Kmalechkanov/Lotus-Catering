namespace LotusCatering.Data.Models
{
    using System;
    using System.Collections.Generic;

    using LotusCatering.Data.Common.Models;

    public class Cart : IAuditInfo
    {
        public Cart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CartItems = new HashSet<CartItem>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
