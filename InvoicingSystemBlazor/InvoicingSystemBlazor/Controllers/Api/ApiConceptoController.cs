using InvoicingSystemBlazor.Models.Entities;
using InvoicingSystemBlazor.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemBlazor.Controllers.Api;

[Route("[Controller]")]
[ApiController]

public class ApiConceptoController:ControllerBase
{
    private readonly IConceptoRepository _conceptoRepository;

    public ApiConceptoController(IConceptoRepository conceptoRepository)
    {
        _conceptoRepository = conceptoRepository;
    }
    
    //ApiConcepto
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]Concepto concepto)
    {
        Console.WriteLine("Dentro de la API");
        bool response= _conceptoRepository.Add(concepto);
        Console.WriteLine("res:"+response);
        Console.WriteLine("---------------------------------------------");
        return Ok(response);
    }
}