using InvoicingSystemMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers.Api.Services.Interfaces;

public interface IContribuyenteService
{
    public Task<Contribuyente> GetContribuyente(string RFC);
}