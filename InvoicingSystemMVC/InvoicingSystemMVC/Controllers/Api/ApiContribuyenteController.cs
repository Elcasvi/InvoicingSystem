using InvoicingSystemMVC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers.Api;
[Route("[Controller]")]
[ApiController]
public class ApiContribuyenteController:ControllerBase
{
    private readonly IContribuyenteRepository _contribuyenteRepository;

    public ApiContribuyenteController(IContribuyenteRepository contribuyenteRepository)
    {
        _contribuyenteRepository = contribuyenteRepository;
    }

    //GET: ApiFactura/Clientes
    [HttpGet]
    public async Task<IActionResult> GetContribuyente()
    {
        string rfcContribuyente = Request.Cookies["RFC"];
        var contribuyente = await _contribuyenteRepository.GetContribuyenteByRFC(rfcContribuyente);
        return Ok(contribuyente);
    }
    
}