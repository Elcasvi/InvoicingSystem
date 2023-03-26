using System.ComponentModel.DataAnnotations;

namespace InvoicingSystemMVC.Models.Entities;

public class Contribuyente
{ 
    [Key] 
    [Required]
    [MaxLength(16),MinLength(16)]
    public string RFC { get; set; }
    
    [Required]
    public string RazonSocial { get; set; }
    
}