using InvoicingSystemBlazor.Models.Entities;


namespace InvoicingSystemBlazor.Controllers.Api.Services.Interfaces;

public interface IContribuyenteService
{
    public Task<Contribuyente> GetContribuyente(string RFC);
}