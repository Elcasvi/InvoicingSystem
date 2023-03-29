using InvoicingSystemMVC.Controllers;
using InvoicingSystemMVC.Models.Interfaces;

namespace InvoicingSystemMVC.Models.Repositories;

public class FacturaRepository:IFacturaRepository
{
    
    private readonly ApplicationDbContext _dbContext;

    public FacturaRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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