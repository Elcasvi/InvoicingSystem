using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicingSystemMVC.Models.Entities;

public class Contribuyente
{
    [Key]
    [MaxLength(13), MinLength(13)]
    public string RFC { get; set; }

    [Required]
    public string RazonSocial { get; set; }

    [Required]
    public string Password { get; set; }
    [Required]
    public string RegimenFiscal { get; set; }
}