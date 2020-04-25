namespace LotusCatering.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LotusCatering.Data.Common.Models;

    public class Gallery : IAuditInfo, IDeletableEntity
    {
        public Gallery()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<GalleryImage> GalleryImages { get; set; }
            = new HashSet<GalleryImage>();
    }
}
