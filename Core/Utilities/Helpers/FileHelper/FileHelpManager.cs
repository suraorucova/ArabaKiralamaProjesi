using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelpManager : IFileHelper
    {
        public string Add(IFormFile file, string root)
        {
            if (file.Length>0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string fileName=Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
                string filePath = fileName + extension;

                using(FileStream fileStream= File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }

            }
            return null;
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Add(file, root);
        }
    }
}
