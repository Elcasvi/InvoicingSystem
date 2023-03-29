using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers;

public class LoginController:Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
