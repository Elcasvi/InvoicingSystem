using InvoicingSystemMVC.Controllers;
using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.Interfaces;

namespace InvoicingSystemMVC.Models.Repositories;

public class FacturaRepository:IFacturaRepository
{
    
    private readonly ApplicationDbContext _dbContext;

    public FacturaRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool Add(Factura factura)
    {
        _dbContext.Facturas.Add(factura);
        return Save();
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
        var saved = _dbContext.SaveChanges();
        return saved >0 ? true : false;
    }
}