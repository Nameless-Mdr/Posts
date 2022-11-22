using Domain.Entity.MetaData;
using Microsoft.AspNetCore.Http;

namespace Common
{
    public static class FileHelper
    {
        public static async Task<MetaDataModel> UploadFile(IFormFile file)
        {
            var tempPath = Path.GetTempPath();

            var meta = new MetaDataModel
            {
                TempId = Guid.NewGuid(),
                Name = file.FileName,
                MimeType = file.ContentType,
                Size = file.Length,
            };

            var newPath = Path.Combine(tempPath, meta.TempId.ToString());

            var fileInfo = new FileInfo(newPath);

            if (fileInfo.Exists)
            {
                throw new Exception("file exist");
            }

            using (var stream = System.IO.File.Create(newPath))
            {
                await file.CopyToAsync(stream);
            }

            return meta;
        }
    }
}
