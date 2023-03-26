using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicingSystemMVC.Models.Entities;

public class Cliente
{
    [Key] 
    [Required]
    [MaxLength(16),MinLength(16)]
    public string RFC { get; set; }
    [Required]
    public string RazonSocial { get; set; }
}