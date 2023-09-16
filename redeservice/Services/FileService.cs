using redeservice.Interfaces;
using redeservice.Models;
using System.Text.Json;

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

        public List<ClsTeste> getDataJson(string fileName, string path)
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("O arquivo JSON não foi encontrado.", filePath);
                }

                string jsonContent = File.ReadAllText(filePath);

                List<ClsTeste> clsTestes = JsonSerializer.Deserialize<List<ClsTeste>>(jsonContent) ?? new List<ClsTeste>();

                return clsTestes;
            }catch (Exception ex)
            {
                return new List<ClsTeste>();
            }
        }
    }
}
