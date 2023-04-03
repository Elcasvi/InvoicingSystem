using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.Interfaces;
using InvoicingSystemMVC.Models.ViewModels.Facturas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InvoicingSystemMVC.Controllers;


public class FacturaController:Controller
{
    private readonly IContribuyenteRepository _contribuyenteRepository;
    private readonly IClienteRepository _clienteRepository;

    public FacturaController(IContribuyenteRepository contribuyenteRepository,IClienteRepository clienteRepository)
    {
        _contribuyenteRepository = contribuyenteRepository;
        _clienteRepository = clienteRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> CrearFactura()
    {
        string RFC=Request.Cookies["RFC"];
        Contribuyente contribuyente = await _contribuyenteRepository.GetContribuyenteByRFC(RFC);
        IEnumerable<Cliente> clientes = await _clienteRepository.GetAllClientes();
        List<Cliente>clientesLista =clientes.ToList();
        List<SelectListItem> clientesItems = clientesLista.ConvertAll(d =>
        {
            return new SelectListItem()
            {
                Text=d.RFC.ToString(),
                Value = d.RFC,
                Selected = false
            };
        });
            
        CrearFacturaViewModel facturaVM = new CrearFacturaViewModel()
        {
            Contribuyente = contribuyente,
            Clientes = clientesItems
        };
        
        return View(facturaVM);
    }
}