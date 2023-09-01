using System.ComponentModel.DataAnnotations;

namespace InvoicingSystemMVC.Models.ViewModels;

public class EditarClienteViewModel
{
    [Display(Name = "RFC")]
    [Required(ErrorMessage = "El RFC es requerido")]
    public string RFC { get; set; }
    
    [Display(Name = "Razon Social")]
    [Required(ErrorMessage = "La Razon Social es requerida")]
    public string RazonSocial { get; set; }
    
    [Display(Name = "Regimen Fiscal")]
    [Required(ErrorMessage = "El Regime Fiscal es requerido")]
    public string RegimenFiscal { get; set; }

    [Display(Name = "Código postal")]
    [Required(ErrorMessage = "El Código postal es requerido")]
    public string CP { get; set; }
}