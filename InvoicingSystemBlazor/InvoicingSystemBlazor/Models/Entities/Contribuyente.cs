using System.ComponentModel.DataAnnotations;

namespace InvoicingSystemBlazor.Models.Entities;

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
    [Required]
    public string CP { get; set; }

}