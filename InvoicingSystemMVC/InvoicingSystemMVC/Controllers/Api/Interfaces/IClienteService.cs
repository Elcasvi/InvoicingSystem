using InvoicingSystemMVC.Models.Entities;

namespace InvoicingSystemMVC.Controllers.Api.Services.Interfaces;

public interface IClienteService
{
    public Task<List<Cliente>> Clientes();
}