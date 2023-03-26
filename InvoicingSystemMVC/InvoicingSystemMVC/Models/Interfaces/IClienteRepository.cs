namespace InvoicingSystemMVC.Models.Interfaces;

public interface IClienteRepository
{
    public bool Add();
    public bool Delete();
    public bool Update();
    public bool Save();
}