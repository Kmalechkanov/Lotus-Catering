﻿namespace LotusCatering.Services
{
    using System.IO;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    public class CloudinaryService
    {
        public static async Task<string> UploadAsync(Cloudinary cloudinary, byte[] image, string folder, string rootPath, bool watermark = false)
        {
            using var destinationStream = new MemoryStream(image);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("nz", destinationStream),
                Folder = folder,
            };

            var result = await cloudinary.UploadAsync(uploadParams);
            var resultId = result.PublicId;

            if (watermark)
            {
                var imageWithWatherMark = ImageService.AddWaterMark(image, rootPath);
                resultId = await UploadAsync(cloudinary, imageWithWatherMark, folder, rootPath);
            }

            return resultId;
        }
    }
}
