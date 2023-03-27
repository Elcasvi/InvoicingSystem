using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers;

public class FacturaController:Controller
{
    private readonly ILogger<HomeController> _logger;

    public FacturaController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}