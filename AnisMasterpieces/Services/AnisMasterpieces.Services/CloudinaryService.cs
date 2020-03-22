namespace AnisMasterpieces.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public class CloudinaryService
    {
        public static async Task<string> UploadAsync(Cloudinary cloudinary, IFormFile file, string folder)
        {
            byte[] destinationImage;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
            }

            using (var destinationStream = new MemoryStream(destinationImage))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription("nz", destinationStream),
                    Folder = folder,
                };

                var result = await cloudinary.UploadAsync(uploadParams);
                return result.PublicId;
            }
        }
    }
}
