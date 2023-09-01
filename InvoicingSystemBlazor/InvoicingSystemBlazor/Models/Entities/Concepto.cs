using System.ComponentModel.DataAnnotations;


namespace InvoicingSystemBlazor.Models.Entities;

public class Concepto
{
    [Key]
    public int Id { get; set; }
    public string ClaveDeProductoOServicio { get; set; }
    public string ClaveDeUnidad { get; set; }
    public int Cantidad{ get; set; }
    public string Unidad { get; set; }
    public string NumeroDeIdentificacion { get; set; }
    public string Descripcion { get; set; }
    public float ValorUnitario { get; set; }
    public bool TieneIVA { get; set; }
    public float TasaIVA { get; set; }
    public float TotalIVA { get; set; }
    public int FacturaId { get; set; }
}