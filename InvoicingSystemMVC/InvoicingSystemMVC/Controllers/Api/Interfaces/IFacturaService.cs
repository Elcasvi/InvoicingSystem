using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.ViewModels.Facturas;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers.Api.Services.Interfaces;

public interface IFacturaService
{
    public Task<HttpResponseMessage> PostFactura(CrearFacturaViewModel factura);
}