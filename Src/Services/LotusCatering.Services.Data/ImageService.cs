namespace LotusCatering.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Common.Repositories;
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Services.Mapping;

    public class ImageService : IImageService
    {
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly IDeletableEntityRepository<Gallery> galleryRepository;

        public ImageService(IDeletableEntityRepository<Image> imageRepository, IDeletableEntityRepository<Gallery> galleryRepository)
        {
            this.imageRepository = imageRepository;
            this.galleryRepository = galleryRepository;
        }

        public async Task<string> AddAsync(string name, string imageUrl, string galleryId, string description)
        {
            var image = new Image
            {
                Name = name.Trim(),
                ImageUrl = imageUrl,
                GalleryId = galleryId,
                Description = description.Trim(),
            };

            await this.imageRepository.AddAsync(image);
            await this.imageRepository.SaveChangesAsync();
            return image.Id;
        }

        public IEnumerable<T> GetAll<T>(string galleryId)
            => this.imageRepository.All().Where(i => i.GalleryId == galleryId).To<T>();

        public async Task<bool> DeleteAsync(string id)
        {
            var image = this.imageRepository.All().FirstOrDefault(i => i.Id == id);
            if (image == null)
            {
                return false;
            }

            this.imageRepository.Delete(image);
            var response = await this.imageRepository.SaveChangesAsync();
            return response == 1;
        }
    }
}
