using InvoicingSystemMVC.Models.Entities;

namespace InvoicingSystemMVC.Models.Interfaces;

public interface IFacturaRepository
{
    public bool Add(Factura factura);
    public Task<Factura> GetFactura(string RFCEmsior, string RFCReceptor, string FechaYHora);
    public bool Delete();
    public bool Update();
    public bool Save();
}