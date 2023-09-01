using InvoicingSystemBlazor.Models.Entities;

namespace InvoicingSystemBlazor.Models.Interfaces;
public interface IContribuyenteRepository
{
    public bool Add(Contribuyente contribuyente);
    public Task<Contribuyente> GetContribuyenteByRFC(string RFC);
    public Task<Contribuyente> GetContribuyenteByRFCAndPassword(string RFC,string Password);
    public bool Delete();
    public bool Update();
    public bool Save();
}