using System.ComponentModel.DataAnnotations;

namespace InvoicingSystemMVC.Models.ViewModels;

public class RegisterContribuyenteViewModel
{
    [Display(Name = "RFC")]
    [Required(ErrorMessage = "El RFC es requerido")]
    public string RFC { get; set; }
    
    [Display(Name = "Razon Social")]
    [Required(ErrorMessage = "La Razon Social es requerida")]
    public string RazonSocial { get; set; }
    
    [Display(Name = "Regimen Fiscal")]
    [Required(ErrorMessage = "El Regimen Fiscal es requerido")]
    public string RegimenFiscal { get; set; }
    
    [Display(Name = "CP")]
    [Required(ErrorMessage = "El CP es requerido")]
    public string CP { get; set; }
    
    [Display(Name = "Contraseña")]
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
}