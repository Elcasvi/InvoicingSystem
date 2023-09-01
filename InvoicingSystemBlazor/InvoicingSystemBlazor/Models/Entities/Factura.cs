using System.ComponentModel.DataAnnotations;

namespace InvoicingSystemBlazor.Models.Entities;

public class Factura
{
    [Key]
    public int Id { get; set; }
    
    public string RFCEmsior { get; set; }
    
    public string RFCReceptor { get; set; }
    
    public string TipoDeFactura { get; set; }
    public string UsoDeFactura { get; set; }
    public string FechaHoraDeExpedicion { get; set; }
    public string Moneda { get; set; }
    public string FormaDePago { get; set; }
    public string MetodoDePago { get; set; }
    public string? Serie { get; set; }
    public string? Folio { get; set; }
    public string? CondicionesDePago { get; set; }
    //public string? FacturaRelacionada { get; set; }
    public float SubtotalFactura { get; set; }
    public float? DescuentoFactura { get; set; }
    public float TotalIVA { get; set; }
    public float TotalFactura { get; set; }
    //public string StatusDeFactura{ get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(RFCEmsior)}: {RFCEmsior}, {nameof(RFCReceptor)}: {RFCReceptor}, {nameof(TipoDeFactura)}: {TipoDeFactura}, {nameof(UsoDeFactura)}: {UsoDeFactura}, {nameof(FechaHoraDeExpedicion)}: {FechaHoraDeExpedicion}, {nameof(Moneda)}: {Moneda}, {nameof(FormaDePago)}: {FormaDePago}, {nameof(MetodoDePago)}: {MetodoDePago}, {nameof(Serie)}: {Serie}, {nameof(Folio)}: {Folio}, {nameof(CondicionesDePago)}: {CondicionesDePago}, {nameof(SubtotalFactura)}: {SubtotalFactura}, {nameof(DescuentoFactura)}: {DescuentoFactura}, {nameof(TotalIVA)}: {TotalIVA}, {nameof(TotalFactura)}: {TotalFactura}";
    } 
}