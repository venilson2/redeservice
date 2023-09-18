using Microsoft.AspNetCore.Mvc;
using redeservice.Interfaces;
using redeservice.Models;
using System.Text.Json;

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

        [HttpPost]
        public IActionResult SaveNumbersFile(List<int> numbers)
        {
            try
            {
                string numbersText = string.Join(Environment.NewLine, numbers);

                if (_fileService.SaveFile("numeros_ordenar.txt", "Files", numbersText))
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, error = "Falha ao salvar o arquivo." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        public IActionResult GenerateDataJson()
        {
            List<ClsTeste> clsTestes = new();

            for (int i = 1; i <= 100; i++)
            {
                clsTestes.Add(new ClsTeste
                {
                    codigo = i,
                    descricao = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff")
                });
            }

            string jsonData = JsonSerializer.Serialize(clsTestes);

            if (_fileService.SaveFile("data.json", "Files", jsonData))
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, error = "Falha ao gerar arquivo JSON." });
            }
        }
        public IActionResult GetDataJson()
        {
            List<ClsTeste> data = _fileService.getDataJson("data.json", "Files");

            if (data == null || data.Count == 0)
            {
                return NotFound("O arquivo JSON não foi encontrado ou está vazio.");
            }

            return Ok(data);
        }
    }
}
