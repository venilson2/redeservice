using redeservice.Interfaces;
using redeservice.Models;
using System.Net.Http;
using System.Text.Json;

namespace redeservice.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly HttpClient _httpClient;
        private readonly string _imageUrl = "https://redeservice.com.br/wp-content/uploads/2020/07/redeservice-logo.png";


        public FileService(IWebHostEnvironment hostingEnvironment, HttpClient httpClient)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpClient = httpClient;
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
            }
            catch (Exception ex)
            {
                return new List<ClsTeste>();
            }
        }

        public async Task<bool> DownloadImageAsync(string path)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_imageUrl);

                if (response.IsSuccessStatusCode)
                {
                    byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();

                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        string folderPath = Path.GetDirectoryName(path);

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        File.WriteAllBytes(path, imageBytes);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string GetImageBase64(string path)
        {
            try
            {
                byte[] imageBytes = File.ReadAllBytes(path);
                return Convert.ToBase64String(imageBytes);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
