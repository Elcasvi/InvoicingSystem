using InvoicingSystemMVC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Models.Interfaces;

public interface IContribuyenteRepository
{
    public bool Add();
    public bool Delete();
    public bool Update();
    public bool Save();
}