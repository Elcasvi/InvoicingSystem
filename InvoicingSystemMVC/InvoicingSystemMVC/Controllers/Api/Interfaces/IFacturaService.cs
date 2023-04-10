using InvoicingSystemMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers.Api.Services.Interfaces;

public interface IFacturaService
{
    public Task<bool> PostFactura(Factura factura);
}