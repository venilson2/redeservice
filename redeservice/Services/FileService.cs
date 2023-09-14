using redeservice.Interfaces;

namespace redeservice.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public bool SaveFile(string fileName, string path, string content)
        {
            try
            {
                string rootPath = _hostingEnvironment.ContentRootPath;

                string folderPath = Path.Combine(rootPath, path);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string filePath = Path.Combine(folderPath, fileName);

                File.WriteAllText(filePath, content);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
