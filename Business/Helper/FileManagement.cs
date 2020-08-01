using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Helper
{
    public class FileManagement
    {
        
        public static string GetContainerFolder(string Type)
        {
            if (Type == "Project")
                return "/images/proje.jpg";
            else
                return string.Empty;
        }
        public static string CreateUniquName(string imagename)
        {
            var uniqueImageName = Path.GetFileNameWithoutExtension(imagename)
                                  + "_"
                                  + Guid.NewGuid().ToString().Substring(0, 4)
                                  + Path.GetExtension(imagename);
            return uniqueImageName;
        }

        public static string AddFile(IFormFile image, IHostingEnvironment environment, string containerFolder)
        {
            if (image == null)
                return GetContainerFolder(containerFolder);
            var uploads = Path.Combine(environment.WebRootPath, $"images\\{containerFolder}");
            var imagename = Path.GetFileName(image.FileName);

            var uniqueImageName = CreateUniquName(imagename);

            //var uniqueImageName = FileManagement.GetUniqueFileName(photo.FileName);
            var imagePath = Path.Combine(uploads, uniqueImageName);
            var imgStream = new FileStream(imagePath, FileMode.Create);
            image.CopyTo(imgStream);
            imgStream.Close();

            return $"/images/{containerFolder}/" + uniqueImageName;
        }
    }

}
