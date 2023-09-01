using Microsoft.EntityFrameworkCore;
using InvoicingSystemBlazor.Models.Entities;


namespace InvoicingSystemBlazor.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Contribuyente> Contribuyentes { get; set; }
    public DbSet<Concepto> Conceptos { get; set; }
    public DbSet<Factura> Facturas { get; set; }
}
