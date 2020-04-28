namespace LotusCatering.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IImageService
    {
        IEnumerable<T> GetAll<T>(string galleryId);

        Task<string> AddAsync(string name, string imageUrl, string galleryId, string description);
    }
}
