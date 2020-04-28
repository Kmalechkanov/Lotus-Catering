namespace LotusCatering.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LotusCatering.Data.Common.Models;

    public class Item : IAuditInfo, IDeletableEntity
    {
        public Item()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OrderItems = new HashSet<OrderItem>();
            this.CartItems = new HashSet<CartItem>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string ImageUrl { get; set; }

        [Range(0, 10000)]
        public double Price { get; set; }

        [Required]
        public string TabId { get; set; }

        public virtual Tab Tab { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
