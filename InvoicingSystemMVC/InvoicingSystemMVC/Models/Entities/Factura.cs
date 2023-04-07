using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicingSystemMVC.Models.Entities;

public class Factura
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public ContribuyenteEmisor ContribuyenteEmisor { get; set; }
    [ForeignKey("ContribuyenteEmisor")]
    public string RFCEmsior { get; set; }

    public ContribuyenteReceptor ContribuyenteReceptor { get; set; }
    [ForeignKey("ContribuyenteReceptor")]
    public string RFCReceptor { get; set; }
    
    public string TipoDeFactura { get; set; }
    public string UsoDeFactura { get; set; }
    public DateTime FechaHoraDeExpedicion { get; set; }
    public string Moneda { get; set; }
    public string FormaDePago { get; set; }
    public string MetodoDePago { get; set; }
    public string? Serie { get; set; }
    public string? Folio { get; set; }
    public string? CondicionesDePago { get; set; }
    //public string? FacturaRelacionada { get; set; }
    public float SubtotalFactura { get; set; }
    public float? DescuentoFactura { get; set; }
    public float TotalFactura { get; set; }
    //public string StatusDeFactura{ get; set; }
}