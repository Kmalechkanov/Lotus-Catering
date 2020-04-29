namespace LotusCatering.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LotusCatering.Data.Common.Repositories;
    using LotusCatering.Data.Models;
    using LotusCatering.Services.Data.Interfaces;
    using LotusCatering.Services.Mapping;

    public class GalleryService : IGalleryService
    {
        private readonly IDeletableEntityRepository<Gallery> galleryRepository;

        public GalleryService(IDeletableEntityRepository<Gallery> galleryRepository)
        {
            this.galleryRepository = galleryRepository;
        }

        public async Task<string> AddAsync(string name)
        {
            var gallery = new Gallery
            {
                Name = name.Trim(),
            };

            await this.galleryRepository.AddAsync(gallery);
            await this.galleryRepository.SaveChangesAsync();
            return gallery.Id;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var gallery = this.galleryRepository.All().FirstOrDefault(g => g.Id == id);

            if (gallery == null)
            {
                return false;
            }

            this.galleryRepository.Delete(gallery);
            var response = await this.galleryRepository.SaveChangesAsync();
            return response == 1;
        }

        public IEnumerable<T> GetAll<T>()
            => this.galleryRepository.All().To<T>();

        public T GetById<T>(string id)
            => this.galleryRepository.All().FirstOrDefault(g => g.Id == id).То<T>();

        public bool IsValidId(string id)
            => this.galleryRepository.All().Any(g => g.Id == id);

        public async Task<bool> UpdateAsync(string id, string name)
        {
            var gallery = this.galleryRepository.All().FirstOrDefault(g => g.Id == id);
            if (gallery == null)
            {
                return false;
            }

            gallery.Name = name.Trim();

            var response = await this.galleryRepository.SaveChangesAsync();
            return response == 1;
        }
    }
}
