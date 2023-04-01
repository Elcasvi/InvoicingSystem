using InvoicingSystemMVC.Controllers;
using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InvoicingSystemMVC.Models.Repositories;

public class ContribuyenteRepository:IContribuyenteRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ContribuyenteRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public bool Add(Contribuyente contribuyente)
    {
        _dbContext.Add(contribuyente);
        return Save();
    }

    public async Task<Contribuyente> GetContribuyenteByRFCAndPassword(string RFC,string password)
    {
        return await _dbContext.Contribuyentes.Where(c => c.RFC == RFC).Where(c => c.Password == password).FirstOrDefaultAsync();
    }
    
    public async Task<Contribuyente> GetContribuyenteByRFC(string RFC)
    {
        return await _dbContext.Contribuyentes.FindAsync(RFC);
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