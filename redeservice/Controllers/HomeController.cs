using Microsoft.AspNetCore.Mvc;

namespace redeservice.Controllers
{
    public class HomeController : Controller
    {
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