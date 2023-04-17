using InvoicingSystemMVC.Models.Entities;


namespace InvoicingSystemMVC.Models.ViewModels.Facturas;

public class CrearFacturaViewModel
{
    

    public Contribuyente Contribuyente { get; set; }
    public List<Cliente> Clientes { get; set; }
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
    
    public CrearFacturaViewModel()
    {
        Contribuyente = new Contribuyente();
        Clientes = new List<Cliente>();
        Cliente = new Cliente();
        TipoDeFactura=String.Empty;
        UsoDeFactura=String.Empty;
        FechaYHoraDeExpedicion = new DateTime();
        Moneda=String.Empty;
        FormaDePago=String.Empty;
        MetodoDePago = String.Empty;
        Serie=String.Empty;
        Folio=String.Empty;
        CondicionesDePago = String.Empty;
        ConceptosViewModel = new List<ConceptoViewModel>();
        SubtotalFactura = 0;
        DescuentoFactura = 0;
        TotalFactura=0;
    }
}