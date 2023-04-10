using InvoicingSystemMVC.Models.Entities;
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

    //GET: ApiFactura/GetContribuyente
    [HttpGet("{RFC}",Name = "GetContribuyente")]
    public async Task<IActionResult> GetContribuyente(string RFC)
    {
        Contribuyente contribuyente = await _contribuyenteRepository.GetContribuyenteByRFC(RFC);
        Console.WriteLine("Contribuyente: "+contribuyente);
        return Ok(contribuyente);
    }
    
}