using InvoicingSystemMVC.Models.Entities;

namespace InvoicingSystemMVC.Models.Interfaces;

public interface IFacturaRepository
{
    public bool Add(Factura factura);
    public bool Delete();
    public bool Update();
    public bool Save();
}