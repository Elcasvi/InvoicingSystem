using InvoicingSystemBlazor.Models.Entities;

namespace InvoicingSystemBlazor.Models.Interfaces;

public interface IClienteRepository
{
    public Task<Cliente> GetClienteByRFC(string RFC);
    public Task<IEnumerable<Cliente>> GetAllClientes();
    public bool Add(Cliente cliente);
    public bool Delete(Cliente cliente);
    public bool Update(Cliente cliente);
    public bool Save();
}