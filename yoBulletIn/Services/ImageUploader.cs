using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Imagekit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using yoBulletIn.Entities;

namespace yoBulletIn.Services
{
    public static class ImageUploader
    {
        public static List<ImagekitResponse> UploadImage(List<IFormFile> Image)
        {
            ServerImagekit imagekit = new ServerImagekit(
               Startup.Configuration.GetValue<string>("ImageUploader:PublicKey"),
               Startup.Configuration.GetValue<string>("ImageUploader:PrivateKey"),
               Startup.Configuration.GetValue<string>("ImageUploader:Endpoint"),
            "path");

            List<ImagekitResponse> responses = new List<ImagekitResponse>();

            foreach (var image in Image)
            {
                using (var ms = new MemoryStream())
                {
                    image.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    var uploadResp = imagekit.FileName(image.FileName).Upload(fileBytes);

                    responses.Add(uploadResp);
                }
            }
            return responses;
        }

        public static ImagekitResponse UploadAvatarImage(IFormFile Image)
        {
            ServerImagekit imagekit = new ServerImagekit(
               Startup.Configuration.GetValue<string>("ImageUploader:PublicKey"),
               Startup.Configuration.GetValue<string>("ImageUploader:PrivateKey"),
               Startup.Configuration.GetValue<string>("ImageUploader:Endpoint"),
            "path");

            using (var ms = new MemoryStream())
            {
                Image.CopyTo(ms);
                var fileBytes = ms.ToArray();
                var uploadResp = imagekit.FileName(Image.FileName).Upload(fileBytes);
                return uploadResp;
            }
        }

    }
}
