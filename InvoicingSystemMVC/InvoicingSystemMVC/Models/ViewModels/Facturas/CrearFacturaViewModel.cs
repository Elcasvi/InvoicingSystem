using InvoicingSystemMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InvoicingSystemMVC.Models.ViewModels.Facturas;

public class CrearFacturaViewModel
{
    public Contribuyente Contribuyente { get; set; }
    public List<SelectListItem> Clientes { get; set; }
    public Cliente Cliente{ get; set; }
    
    public string TipoDeFactura { get; set; }
    public string UsoDeFactura { get; set; }
    public DateTime FechaYHoraDeExpedicion { get; set; }
    public string Moneda { get; set; }
    public string FormaDePago { get; set; }
    public string MetodoDePago { get; set; }
    public string? Serie { get; set; }
    public string? Folio { get; set; }
    public string? CondicionesDePago { get; set; }
    //public string? FacturaRelacionada { get; set; }
    public List<ConceptoViewModel> ConceptosViewModel { get; set; }
    public float SubtotalFactura { get; set; }
    public float? DescuentoFactura { get; set; }
    public float TotalFactura { get; set; }
    //public string StatusDeFactura{ get; set; }
}