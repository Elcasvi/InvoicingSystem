using InvoicingSystemBlazor.Models.Entities;

namespace InvoicingSystemBlazor.Models.Interfaces;
public interface IFacturaRepository
{
    public bool Add(Factura factura);
    public Task<Factura> GetFactura(int Id);
    public Task<Factura> GetFactura(string RFCEmsior, string RFCReceptor, string FechaYHora);
    public bool Delete();
    public bool Update();
    public bool Save();
}