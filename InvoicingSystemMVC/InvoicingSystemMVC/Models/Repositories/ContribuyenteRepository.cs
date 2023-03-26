using InvoicingSystemMVC.Controllers;
using InvoicingSystemMVC.Models.Interfaces;

namespace InvoicingSystemMVC.Models.Repositories;

public class ContribuyenteRepository:IContribuyenteRepository
{
    private readonly IContribuyenteRepository _contribuyenteRepository;
    private readonly ApplicationDbContext _dbContext;

    public ContribuyenteRepository(IContribuyenteRepository contribuyenteRepository, ApplicationDbContext dbContext)
    {
        _contribuyenteRepository = contribuyenteRepository;
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