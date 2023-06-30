using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace InvoicingSystemMVC.Controllers.Api;

[Route("[Controller]")]
[ApiController]
public class ApiFacturaController:ControllerBase
{
    private readonly IFacturaRepository _facturaRepository;

    public ApiFacturaController(IFacturaRepository facturaRepository)
    {
        _facturaRepository = facturaRepository;
    }

    //GET: ApiFactura/GetClientes
    [HttpGet("{RFCEmsior}/{RFCReceptor}/{FechaYHoraDeExpedicion}")]
    public async Task<IActionResult> GetFactura(string RFCEmsior,string RFCReceptor,string FechaYHoraDeExpedicion)
    {
        var facturaRecuperada =await _facturaRepository.GetFactura(RFCEmsior,RFCReceptor, FechaYHoraDeExpedicion);
        return Ok(facturaRecuperada);
    }
    
    //POST: ApiFactura
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]Factura factura)
    {
        bool res=_facturaRepository.Add(factura);
        Console.WriteLine("res:"+res);
        Console.WriteLine("---------------------------------------------");
        return Ok(res);
    }
    
}