using InvoicingSystemBlazor.Data;
using InvoicingSystemBlazor.Models.Entities;
using InvoicingSystemBlazor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoicingSystemBlazor.Models.Repositories;

public class ClienteRepository :IClienteRepository
{
    private readonly ApplicationDbContext _DbContext;

    public ClienteRepository(ApplicationDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public async Task<Cliente> GetClienteByRFC(string RFC)
    {
        return await _DbContext.Clientes.FindAsync(RFC);
    }

    public async Task<IEnumerable<Cliente>> GetAllClientes()
    {
        return await _DbContext.Clientes.ToListAsync();
    }
    public bool Add(Cliente cliente)
    {
        _DbContext.Clientes.Add(cliente);
        return Save();
    }

    public bool Delete(Cliente cliente)
    {
        _DbContext.Clientes.Remove(cliente);
        return Save();
    }

    public bool Update(Cliente cliente)
    {
        _DbContext.Clientes.Update(cliente);
        return Save();
    }

    public bool Save()
    {
        var saved = _DbContext.SaveChanges();
        return saved >0 ? true : false;
    }
}