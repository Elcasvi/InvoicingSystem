using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InvoicingSystemMVC.Controllers;

public class LogoutController:Controller
{
    public IActionResult Index()
    {
        return View();
    }
}