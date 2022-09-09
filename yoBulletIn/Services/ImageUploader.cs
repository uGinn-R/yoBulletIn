using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Imagekit;
using Microsoft.AspNetCore.Http;

namespace yoBulletIn.Services
{
    public static class ImageUploader
    {

        public static ImagekitResponse UploadImage(IFormFile Image)
        {
            ServerImagekit imagekit = new ServerImagekit(
            "public_Qenm/H4uTp0RTX8M+LjzrY+w9bU=",
            "private_/Ny5I7r2cfO3hgVDM8x3SkiEu6c=",
            "https://ik.imagekit.io/qghus62ew5",
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
