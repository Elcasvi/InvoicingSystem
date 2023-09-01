using InvoicingSystemBlazor.Models.Entities;
using InvoicingSystemBlazor.Models.Enums;


namespace InvoicingSystemBlazor.Models.ViewModels.Facturas;

public class CrearFacturaViewModel
{
    

    public Contribuyente Contribuyente { get; set; }
    public List<Cliente> Clientes { get; set; }
    public Cliente Cliente{ get; set; }
    
    public string TipoDeFactura { get; set; }
    public string UsoDeFactura { get; set; }
    public DateTime FechaYHoraDeExpedicion { get; set; }
    public Moneda Moneda { get; set; }//lISTA DE MONEDAS
    public FormaDePago FormaDePago { get; set; }//LISTA DE FORMAS
    public MetodoDePago MetodoDePago { get; set; }//LISTA DE PAGOS
    public string? Serie { get; set; }
    public string? Folio { get; set; }
    public string? CondicionesDePago { get; set; }
    //public string? FacturaRelacionada { get; set; }
    public List<ConceptoViewModel> ConceptosViewModel { get; set; }
    public float SubtotalFactura { get; set; }
    public float? DescuentoFactura { get; set; }
    public float TotalIVA { get; set; }
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
        Moneda = Moneda.MXN;
        FormaDePago= FormaDePago.Efectivo;
        MetodoDePago = MetodoDePago.PPD;
        Serie=String.Empty;
        Folio=String.Empty;
        CondicionesDePago = String.Empty;
        ConceptosViewModel = new List<ConceptoViewModel>();
        SubtotalFactura = 0;
        DescuentoFactura = 0;
        TotalIVA = 0;
        TotalFactura=0;
    }

    public override string ToString()
    {
        return $"{nameof(Contribuyente)}: {Contribuyente.RFC} {Contribuyente.RazonSocial}, {nameof(Clientes)}: {Clientes}, {nameof(Cliente)}: {Cliente.RFC} {Cliente.RazonSocial}, {nameof(TipoDeFactura)}: {TipoDeFactura}, {nameof(UsoDeFactura)}: {UsoDeFactura}, {nameof(FechaYHoraDeExpedicion)}: {FechaYHoraDeExpedicion}, {nameof(Moneda)}: {Moneda}, {nameof(FormaDePago)}: {FormaDePago}, {nameof(MetodoDePago)}: {MetodoDePago}, {nameof(Serie)}: {Serie}, {nameof(Folio)}: {Folio}, {nameof(CondicionesDePago)}: {CondicionesDePago}, {nameof(ConceptosViewModel)}: {ConceptosViewModel}, {nameof(SubtotalFactura)}: {SubtotalFactura}, {nameof(DescuentoFactura)}: {DescuentoFactura}, {nameof(TotalIVA)}: {TotalIVA}, {nameof(TotalFactura)}: {TotalFactura}";
    }
}