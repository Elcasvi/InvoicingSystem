using InvoicingSystemMVC.Controllers;
using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace InvoicingSystemMVC.Models.Repositories;

public class ConceptoRepository:IConceptoRepository
{
    private readonly ApplicationDbContext _DbContext;

    public ConceptoRepository(ApplicationDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public bool Add(Concepto concepto)
    {
        _DbContext.Conceptos.Add(concepto);
        return Save();
    }

    public async Task<IEnumerable<Concepto>> GetConceptosByRFC(string RFC)
    {
        //return await _DbContext.Conceptos.Where(c => c.RFC == RFC).ToListAsync();
        return await _DbContext.Conceptos.ToListAsync();
    }
    

    public bool Save()
    {
        var saved = _DbContext.SaveChanges();
        return saved >0 ? true : false;
    }
}