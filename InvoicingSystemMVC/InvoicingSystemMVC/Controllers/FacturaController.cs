using InvoicingSystemMVC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers;

[Route("api/[Controller]")]
public class FacturaController:ControllerBase
{
    private readonly IClienteRepository _clienteRepository;

    public FacturaController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var clientes=await _clienteRepository.GetAllClientes();
        return Ok(clientes);
    }
}