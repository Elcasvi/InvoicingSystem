using InvoicingSystemMVC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace InvoicingSystemMVC.Controllers.Api;

[Route("[Controller]")]
[ApiController]
public class ApiFacturaController:ControllerBase
{
    private readonly IClienteRepository _clienteRepository;

    public ApiFacturaController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    //GET: ApiFactura/Clientes
    [HttpGet]
    public async Task<IActionResult> GetClientes()
    {
        return Ok();
    }
    //POST: ApiFactura
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        return Ok();
    }
}