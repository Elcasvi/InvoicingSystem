using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.Interfaces;
using InvoicingSystemMVC.Models.ViewModels.Facturas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InvoicingSystemMVC.Controllers;


public class FacturaController:Controller
{
    private readonly IFacturaRepository _facturaRepository;
    private readonly IConceptoRepository _conceptoRepository;
    
    public FacturaController(IFacturaRepository facturaRepository,IConceptoRepository conceptoRepository)
    {
        _facturaRepository = facturaRepository;
        _conceptoRepository = conceptoRepository;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
}