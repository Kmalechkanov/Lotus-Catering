namespace LotusCatering.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LotusCatering.Data.Common.Models;

    public class Tab : IAuditInfo, IDeletableEntity
    {
        public Tab()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        [Required]
        [MaxLength(150)]
        public string ImageUrl { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Item> Items { get; set; }
            = new HashSet<Item>();
    }
}
