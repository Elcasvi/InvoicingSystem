using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.Interfaces;
using InvoicingSystemMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers;

public class ClienteController:Controller
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IContribuyenteRepository _contribuyenteRepository;

    public ClienteController(IClienteRepository clienteRepository,IContribuyenteRepository contribuyenteRepository)
    {
        _clienteRepository = clienteRepository;
        _contribuyenteRepository = contribuyenteRepository;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Cliente> clientes =await _clienteRepository.GetAllClientes();
        return View(clientes);
    }

    public IActionResult CrearCliente()
    {
        RegisterClienteViewModel clienteVM = new RegisterClienteViewModel();
        return View(clienteVM);
    }

    [HttpPost]
    public async Task<IActionResult> CrearCliente(RegisterClienteViewModel clienteVM)
    {
        if (!ModelState.IsValid)
        {
            
            return View(clienteVM);
        }

        Cliente cliente =await _clienteRepository.GetClienteByRFC(clienteVM.RFC);
        if (cliente != null)
        {
            TempData["Error!"] = "Este cliente ya existe";
            return View(clienteVM);
        }
        var contribuyenteRFC = Request.Cookies["RFC"];
        Contribuyente contribuyente = await _contribuyenteRepository.GetContribuyenteByRFC(contribuyenteRFC);
        Cliente nuevoCliente = new Cliente()
        {
            RFC=clienteVM.RFC,
            RazonSocial= clienteVM.RazonSocial,
            RegimenFiscal = clienteVM.RegimenFiscal,
            Contribuyente = contribuyente,
            ContribuyenteRFC =contribuyenteRFC,
            CP = clienteVM.CP
        };
        _clienteRepository.Add(nuevoCliente);
        return RedirectToAction("Index", "Cliente");
    }

    public async Task<IActionResult> EditarCliente(string RFC)
    {
        Cliente cliente = await _clienteRepository.GetClienteByRFC(RFC);
        if (cliente != null)
        {
            EditarClienteViewModel editarClienteVM = new EditarClienteViewModel()
            {
                RFC = cliente.RFC,
                RazonSocial = cliente.RazonSocial,
                RegimenFiscal = cliente.RegimenFiscal,
                CP = cliente.CP
            };
            return View(editarClienteVM);
        }
        return View("Error");
    }

    [HttpPost]
    public async Task<IActionResult> EditarCliente(EditarClienteViewModel editarClienteVM)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("","No se pudo editar cliente");
            return RedirectToAction("Index", "Cliente");
        }

        string contribuyenteRFC=Request.Cookies["RFC"];
        Contribuyente contribuyente = await _contribuyenteRepository.GetContribuyenteByRFC(contribuyenteRFC);
        
        Cliente cliente = new Cliente()
        {
            RFC = editarClienteVM.RFC,
            RazonSocial = editarClienteVM.RazonSocial,
            RegimenFiscal = editarClienteVM.RegimenFiscal,
            CP=editarClienteVM.CP,
            Contribuyente = contribuyente,
            ContribuyenteRFC = contribuyenteRFC
        };
        _clienteRepository.Update(cliente);
        return RedirectToAction("Index", "Cliente");
    }

    public async Task<IActionResult> Eliminar(string RFC)
    {
        Cliente cliente = await _clienteRepository.GetClienteByRFC(RFC);
        EditarClienteViewModel editarClienteVM = new EditarClienteViewModel()
        {
            RFC =cliente.RFC,
            RazonSocial = cliente.RazonSocial,
            RegimenFiscal = cliente.RegimenFiscal,
            CP=cliente.CP
        };
        return View(editarClienteVM);
    }
    
    [HttpPost,ActionName("Delete")]
    public async Task<IActionResult> EliminarCliente(string RFC)
    {
        Cliente cliente = await _clienteRepository.GetClienteByRFC(RFC);
        if (cliente == null)
        {
            return View("Error");
        }

        _clienteRepository.Delete(cliente);
        return RedirectToAction("Index", "Cliente");
    }
}