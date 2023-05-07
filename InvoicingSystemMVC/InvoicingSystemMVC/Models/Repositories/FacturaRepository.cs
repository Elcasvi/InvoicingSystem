using InvoicingSystemMVC.Controllers;
using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

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
    public async Task<Factura> GetFactura(string RFCEmsior,string RFCReceptor,string FechaYHora)
    {
        return await _dbContext.Facturas.Where(f => f.RFCEmsior == RFCEmsior).Where(f => f.RFCReceptor == RFCReceptor).Where(f => f.FechaHoraDeExpedicion == FechaYHora).FirstOrDefaultAsync();
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