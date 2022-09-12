using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Imagekit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace yoBulletIn.Services
{
    public static class ImageUploader
    {
        public static ImagekitResponse UploadImage(IFormFile Image)
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
