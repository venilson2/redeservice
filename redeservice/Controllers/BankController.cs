using Microsoft.AspNetCore.Mvc;
using redeservice.Interfaces;

namespace redeservice.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankInfoService _bankInfoService;

        public BankController(IBankInfoService bankInfoService)
        {
            _bankInfoService = bankInfoService;
        }

        public async Task<JsonResult> Index()
        {
            try
            {
                var bankInfoList = await _bankInfoService.GetBankInfo();
                return Json(bankInfoList);

            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}
