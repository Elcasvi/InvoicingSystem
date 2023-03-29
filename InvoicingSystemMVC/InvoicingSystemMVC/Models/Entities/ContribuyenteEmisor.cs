using System.ComponentModel.DataAnnotations;

namespace InvoicingSystemMVC.Models.Entities
{
    public class ContribuyenteEmisor
    {
        [Key]
        [Required]
        [MaxLength(13), MinLength(13)]
        public string RFC { get; set; }
        [Required]
        public string RazonSocial { get; set; }
        [Required]
        public string RegimenFiscal { get; set; }

    }
}
