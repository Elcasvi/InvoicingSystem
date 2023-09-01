using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InvoicingSystemBlazor.Models.Entities;

public class Cliente
{
    [Key]
    public string RFC { get; set; }

    [Required]
    public string RazonSocial { get; set; }
    
    [Required]
    public string RegimenFiscal { get; set; }
    [Required]
    public string CP{ get; set; }
    public Contribuyente Contribuyente { get; set; }
    [ForeignKey("Contribuyente")]
    public string ContribuyenteRFC { get; set; }
}