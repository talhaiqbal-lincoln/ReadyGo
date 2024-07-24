using Microsoft.AspNetCore.Http;
using ReadyGo.Domain.Entities;
using ReadyGo.Service.Interfaces;
using System;
using System.IO;

namespace ReadyGo.Service.Services
{
    public class ImageService : IFileService
    {
        public ResourceFile SaveReshape(IFormFile file, string userId = "defaultPic", int width = 150, int height = 150, int quality = 75)
        {
            try
            {
                string mimeType = file.ContentType;
                string ext = Path.GetExtension(file.FileName);
                string fileName = "pp_" + userId + ext;

                ResourceFile image;

                byte[] result = null;

                // filestream
                using (var fileStream = file.OpenReadStream())

                // memory stream
                using (var memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    memoryStream.Position = 0; // The position needs to be reset.

                    // convert to byte[]
                    result = memoryStream.ToArray();
                    image = new ResourceFile
                    {
                        File = result,
                        Name = fileName,
                        MimeType = mimeType
                    };
                }
                return image;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
