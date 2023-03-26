using InvoicingSystemMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoicingSystemMVC.Controllers;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Contribuyente> Contribuyentes { get; set; }
    public DbSet<Factura> Facturas { get; set; }
}