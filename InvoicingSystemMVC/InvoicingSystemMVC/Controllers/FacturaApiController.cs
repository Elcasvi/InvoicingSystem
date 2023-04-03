using InvoicingSystemMVC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers;


[Route("/{Controller}")]
public class FacturaApiController:ControllerBase
{
    private readonly IClienteRepository _clienteRepository;

    public FacturaApiController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var clientes=await _clienteRepository.GetAllClientes();
        return Ok(clientes);
    }
}