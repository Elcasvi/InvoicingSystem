using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicingSystemMVC.Models.Entities;

public class ContribuyenteReceptor
{
    [Key]
    [Required]
    [MaxLength(13), MinLength(13)]
    public string RFC { get; set; }
    [Required]
    public string RazonSocial { get; set; }
    [Required]
    public string RegimenFiscal { get; set; }
    public string CP { get; set; }
}