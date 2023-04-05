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
            };
        });
            
        CrearFacturaViewModel facturaVM = new CrearFacturaViewModel()
        {
            Contribuyente = contribuyente,
            Clientes = clientesItems
        };
        
        return View(facturaVM);
    }

    [HttpPost]
    public async  Task<IActionResult> CrearFactura(CrearFacturaViewModel facturaVM)
    {
     
     
     Contribuyente contribuyente = await _contribuyenteRepository.GetContribuyenteByRFC(facturaVM.Contribuyente.RFC);
     Cliente cliente = await _clienteRepository.GetClienteByRFC(facturaVM.Cliente.RFC);
     ContribuyenteEmisor contribuyenteEmisor = new ContribuyenteEmisor()
     {
         RFC=contribuyente.RFC,
         RazonSocial =contribuyente.RazonSocial,
         RegimenFiscal = contribuyente.RegimenFiscal,
         CP = contribuyente.CP
     };
     ContribuyenteReceptor contribuyenteReceptor = new ContribuyenteReceptor()
     {
         RFC=cliente.RFC,
         RazonSocial =cliente.RazonSocial,
         RegimenFiscal = cliente.RegimenFiscal
     };
     
     Factura factura = new Factura()
     {
         ContribuyenteEmisor = contribuyenteEmisor,
         RFCEmsior = contribuyenteEmisor.RFC,
         ContribuyenteReceptor = contribuyenteReceptor,
         RFCReceptor = contribuyenteReceptor.RFC,
         TipoDeFactura = facturaVM.TipoDeFactura,
         UsoDeFactura = facturaVM.UsoDeFactura,
         FechaHoraDeExpedicion = DateTime.Now,
         Moneda = facturaVM.Moneda,
         FormaDePago = facturaVM.FormaDePago,
         MetodoDePago = facturaVM.MetodoDePago,
         Serie = facturaVM.Serie,
         Folio = facturaVM.Folio,
         CondicionesDePago= facturaVM.CondicionesDePago,
         ClaveDeProductoOServicio= facturaVM.ClaveDeProductoOServicio,
         ClaveDeUnidad = facturaVM.ClaveDeUnidad,
         Cantidad= facturaVM.Cantidad,
         Unidad = facturaVM.Unidad,
         NumeroDeIdentificacion = facturaVM.NumeroDeIdentificacion,
         Descripcion = facturaVM.Descripcion,
         ValorUnitario = facturaVM.ValorUnitario,
         TieneIVA = facturaVM.TieneIVA,
         TasaIVA = facturaVM.TasaIVA,
         TotalIVA =facturaVM.TotalIVA,
         SubtotalFactura = facturaVM.SubtotalFactura,
         DescuentoFactura = facturaVM.DescuentoFactura,
         TotalFactura = facturaVM.TotalFactura,
     };
     
     return RedirectToAction("Index", "Factura");
    }
}