using InvoicingSystemMVC.Controllers;
using InvoicingSystemMVC.Models.Interfaces;

namespace InvoicingSystemMVC.Models.Repositories;

public class ClienteRepository :IClienteRepository
{
    public readonly IClienteRepository _clienteRepository;
    public readonly ApplicationDbContext _DbContext;

    public ClienteRepository(IClienteRepository clienteRepository, ApplicationDbContext dbContext)
    {
        _clienteRepository = clienteRepository;
        _DbContext = dbContext;
    }

    public bool Add()
    {
        throw new NotImplementedException();
    }

    public bool Delete()
    {
        throw new NotImplementedException();
    }

    public bool Update()
    {
        throw new NotImplementedException();
    }

    public bool Save()
    {
        throw new NotImplementedException();
    }
}