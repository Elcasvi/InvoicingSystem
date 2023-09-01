using InvoicingSystemBlazor.Models.Entities;
using InvoicingSystemBlazor.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace InvoicingSystemBlazor.Controllers.Api;

[Route("[Controller]")]
[ApiController]
public class ApiFacturaController:ControllerBase
{
    private readonly IFacturaRepository _facturaRepository;

    public ApiFacturaController(IFacturaRepository facturaRepository)
    {
        _facturaRepository = facturaRepository;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetFactura(int Id)
    {
        var facturaRecuperada = await _facturaRepository.GetFactura(Id);
        return Ok(facturaRecuperada);
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