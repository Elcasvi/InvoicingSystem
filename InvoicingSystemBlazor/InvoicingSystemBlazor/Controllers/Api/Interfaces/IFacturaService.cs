using InvoicingSystemBlazor.Models.Entities;
using InvoicingSystemBlazor.Models.ViewModels.Facturas;


namespace InvoicingSystemBlazor.Controllers.Api.Services.Interfaces;

public interface IFacturaService
{
    public Task<Factura> PostFactura(CrearFacturaViewModel factura);
    public Task<Factura>GetFactura(int Id);
}