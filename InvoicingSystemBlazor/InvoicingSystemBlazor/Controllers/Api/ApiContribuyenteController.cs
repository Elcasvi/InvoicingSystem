using InvoicingSystemBlazor.Models.Entities;
using InvoicingSystemBlazor.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemBlazor.Controllers.Api;
[Route("[Controller]")]
[ApiController]
public class ApiContribuyenteController:ControllerBase
{
    private readonly IContribuyenteRepository _contribuyenteRepository;

    public ApiContribuyenteController(IContribuyenteRepository contribuyenteRepository)
    {
        _contribuyenteRepository = contribuyenteRepository;
    }

    //GET: ApiContribuyente/RFC
    [HttpGet("{RFC}",Name = "GetContribuyente")]
    public async Task<IActionResult> GetContribuyente(string RFC)
    {
        Contribuyente contribuyente = await _contribuyenteRepository.GetContribuyenteByRFC(RFC);
        Console.WriteLine("Contribuyente: "+contribuyente.RFC);
        return Ok(contribuyente);
    }
    
}