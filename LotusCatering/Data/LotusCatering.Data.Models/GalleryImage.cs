namespace LotusCatering.Data.Models
{
    public class GalleryImage
    {
        public string GalleryId { get; set; }

        public virtual Gallery Gallery { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
