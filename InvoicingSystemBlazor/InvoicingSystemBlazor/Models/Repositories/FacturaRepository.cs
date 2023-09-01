using InvoicingSystemBlazor.Data;
using InvoicingSystemBlazor.Models.Entities;
using InvoicingSystemBlazor.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvoicingSystemBlazor.Models.Repositories;

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
    public Task<Factura> GetFactura(int Id)
    {
        return _dbContext.Facturas.Where(f => f.Id == Id).AsNoTracking().FirstOrDefaultAsync();
    }
    public async Task<Factura> GetFactura(string RFCEmsior,string RFCReceptor,string FechaYHora)
    {
        return await _dbContext.Facturas.Where(f => f.RFCEmsior == RFCEmsior).Where(f => f.RFCReceptor == RFCReceptor).Where(f => f.FechaHoraDeExpedicion == FechaYHora).AsNoTracking().FirstOrDefaultAsync();
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