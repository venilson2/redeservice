using Microsoft.AspNetCore.Mvc;
using redeservice.Interfaces;
using redeservice.Services;

namespace redeservice.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<bool> DownloadImage()
        {
            var savePath = Path.Combine("Files", "redeservice.png");

            bool success = await _fileService.DownloadImageAsync(savePath);

            if (success)
            {
                return success;
            }
            else
            {
                return false;
            }
        }

        public IActionResult GetImageBase64()
        {
            var path = Path.Combine("Files", "redeservice.png");

            string base64Image = _fileService.GetImageBase64(path);

            if (!string.IsNullOrEmpty(base64Image))
            {
                return Content(base64Image);
            }
            else
            {
                return Content("Falha ao obter a representação Base64 da imagem.");
            }
        }
    }
}
