using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicingSystemMVC.Models.Entities;

public class Cliente
{
    [Key]
    public string RFC { get; set; }

    [Required]
    public string RazonSocial { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string RegimenFiscal { get; set; }
    
    public Contribuyente Contribuyente { get; set; }
    [ForeignKey("Contribuyente")]
    public string ContribuyenteRFC { get; set; }
}