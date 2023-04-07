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
    private readonly IFacturaRepository _facturaRepository;

    public FacturaController(IContribuyenteRepository contribuyenteRepository, IClienteRepository clienteRepository, IFacturaRepository facturaRepository)
    {
        _contribuyenteRepository = contribuyenteRepository;
        _clienteRepository = clienteRepository;
        _facturaRepository = facturaRepository;
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
     
     
     DateTime fechaYHora=DateTime.Now;
     Factura factura = new Factura()
     {
         ContribuyenteEmisor = contribuyenteEmisor,
         RFCEmsior = contribuyenteEmisor.RFC,
         ContribuyenteReceptor = contribuyenteReceptor,
         RFCReceptor = contribuyenteReceptor.RFC,
         TipoDeFactura = facturaVM.TipoDeFactura,
         UsoDeFactura = facturaVM.UsoDeFactura,
         FechaHoraDeExpedicion = fechaYHora,
         Moneda = facturaVM.Moneda,
         FormaDePago = facturaVM.FormaDePago,
         MetodoDePago = facturaVM.MetodoDePago,
         Serie = facturaVM.Serie,
         Folio = facturaVM.Folio,
         CondicionesDePago= facturaVM.CondicionesDePago,
         SubtotalFactura = facturaVM.SubtotalFactura,
         DescuentoFactura = facturaVM.DescuentoFactura,
         TotalFactura = facturaVM.TotalFactura,
     };
     //_facturaRepository.Add();
     //_facturaRepository.Get();
     
     
     foreach (ConceptoViewModel conceptoVM in facturaVM.ConceptosViewModel)
     {
         Concepto nuevoConcepto = new Concepto()
         {
             //Factura =
             //FacturaId = 
             ClaveDeProductoOServicio = conceptoVM.ClaveDeProductoOServicio,
             ClaveDeUnidad = conceptoVM.ClaveDeUnidad,
             Cantidad = conceptoVM.Cantidad,
             Unidad = conceptoVM.Unidad,
             NumeroDeIdentificacion = conceptoVM.NumeroDeIdentificacion,
             Descripcion = conceptoVM.Descripcion,
             ValorUnitario = conceptoVM.ValorUnitario,
             TieneIVA = conceptoVM.TieneIVA,
             TasaIVA = conceptoVM.TasaIVA,
             TotalIVA = conceptoVM.TotalIVA,
         };
         //_conceptoRepository.Add
     }
     
     return RedirectToAction("Index", "Factura");
    }
}