using InvoicingSystemBlazor.Models.Entities;

namespace InvoicingSystemBlazor.Controllers.Api.Services.Interfaces;

public interface IClienteService
{
    public Task<List<Cliente>> GetClientes();
}