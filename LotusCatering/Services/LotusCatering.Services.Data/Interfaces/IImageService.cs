namespace LotusCatering.Services.Data.Interfaces
{
    using System.Collections.Generic;

    public interface IImageService
    {
        IEnumerable<T> GetAll<T>(string galleryId);
    }
}
