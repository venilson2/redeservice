using Microsoft.AspNetCore.Mvc;
using redeservice.Models;
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

        public IActionResult FindBankInfo()
        {
            return View();
        }

        public IActionResult DownloadImage()
        {
            return View();
        }
    }
}