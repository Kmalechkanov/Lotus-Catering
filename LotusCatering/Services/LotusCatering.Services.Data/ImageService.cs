namespace LotusCatering.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LotusCatering.Data.Common.Repositories;
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Services.Mapping;

    public class ImageService : IImageService
    {
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly IApplicationDbContext dbRepository;

        public ImageService(IDeletableEntityRepository<Image> imageRepository, IApplicationDbContext dbRepository)
        {
            this.imageRepository = imageRepository;
            this.dbRepository = dbRepository;
        }

        public IEnumerable<T> GetAll<T>(string galleryId)
            => this.imageRepository.All().Where(i => i.GalleryId == galleryId).To<T>();
    }
}
