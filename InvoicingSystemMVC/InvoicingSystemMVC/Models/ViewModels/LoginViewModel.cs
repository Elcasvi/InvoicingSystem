using System.ComponentModel.DataAnnotations;

namespace InvoicingSystemMVC.Models.ViewModels;

public class LoginViewModel
{
    [Display(Name = "RFC")]
    [Required(ErrorMessage = "El RFC es requerido")]
    public string RFC { get; set; }
        
    [Display(Name = "Contraseña")]
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}