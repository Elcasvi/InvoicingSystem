using InvoicingSystemMVC.Controllers;
using InvoicingSystemMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Models.Interfaces;

public interface IContribuyenteRepository
{
    public bool Add(Contribuyente contribuyente);
    public Task<Contribuyente> GetContribuyenteByRFC(string RFC);
    public bool Delete();
    public bool Update();
    public bool Save();
}