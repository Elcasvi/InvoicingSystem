using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers;

public class ClienteController:Controller
{
    private readonly ILogger<HomeController> _logger;

    public ClienteController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}