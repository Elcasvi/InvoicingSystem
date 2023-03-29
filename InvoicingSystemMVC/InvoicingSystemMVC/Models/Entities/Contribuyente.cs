using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InvoicingSystemMVC.Models.Entities;

public class Contribuyente
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(13), MinLength(13)]
    public string RFC { get; set; }

    [Required]
    public string RazonSocial { get; set; }

    [Required]
    public string Password { get; set; }
    [Required]
    public string RegimenFiscal { get; set; }
}