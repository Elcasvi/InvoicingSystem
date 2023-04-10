using InvoicingSystemMVC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers.Api;
[Route("[Controller]")]
[ApiController]
public class ApiClienteController:ControllerBase
{
    private readonly IClienteRepository _clienteRepository;

    public ApiClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    //GET: ApiFactura/GetClientes
    [HttpGet]
    public async Task<IActionResult> GetClientes()
    {
        var clientes=await _clienteRepository.GetAllClientes();
        return Ok(clientes);
    }
    
    //GET: ApiFactura/GetClientes/5
    [HttpGet("{RFC}",Name = "GetClientes")]
    public async Task<IActionResult> GetClientes(string RFC)
    {
        var cliente=await _clienteRepository.GetClienteByRFC(RFC);
        return Ok(cliente);
    }
}