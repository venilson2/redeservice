using Microsoft.AspNetCore.Mvc;
using redeservice.Interfaces;

public class CorreiosController : Controller
{
    private readonly ICorreiosService _correiosService;

    public CorreiosController(ICorreiosService correiosService)
    {
        _correiosService = correiosService;
    }

    [HttpPost]
    public async Task<JsonResult> ConsultaCEP(string cep)
    {
        try
        {
            var result = await _correiosService.ConsultaCEPAsync(cep);
            return Json(result);
        }
        catch (Exception ex)
        {
            return Json(new { error = ex.Message });
        }
    }
}
