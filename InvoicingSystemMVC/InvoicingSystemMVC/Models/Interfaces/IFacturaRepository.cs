namespace InvoicingSystemMVC.Models.Interfaces;

public interface IFacturaRepository
{
    public bool Add();
    public bool Delete();
    public bool Update();
    public bool Save();
}