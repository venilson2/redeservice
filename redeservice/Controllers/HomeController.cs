using Microsoft.AspNetCore.Mvc;
using redeservice.Models;
using System.Diagnostics;
using redeservice.Interfaces;
using System.Text.Json;

namespace redeservice.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileService _fileService;

        public HomeController(IFileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NumberOrdering()
        {
            return View();
        }

        public IActionResult DataJson()
        {
            return View();
        }

        public IActionResult FindCep()
        {
            return View();
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


        public ActionResult GenerateDataJson()
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

        public ActionResult GetDataJson()
        {
            List<ClsTeste> data = _fileService.getDataJson("data.json", "Files");

            if (data == null || data.Count == 0)
            {
                return NotFound("O arquivo JSON não foi encontrado ou está vazio.");
            }

            return Ok(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}