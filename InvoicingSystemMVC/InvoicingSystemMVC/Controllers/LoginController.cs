using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.Interfaces;
using InvoicingSystemMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers;

public class LoginController:Controller
{
    private readonly IContribuyenteRepository _contribuyenteRepository;

    public LoginController(IContribuyenteRepository contribuyenteRepository)
    {
        _contribuyenteRepository = contribuyenteRepository;
    }

    public IActionResult Index()
    {
        LoginViewModel response = new LoginViewModel();
        return View(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel loginVM)
    {
        if (!ModelState.IsValid)
        {
            return View(loginVM);
        }
        Contribuyente contribuyente = await _contribuyenteRepository.GetContribuyenteByRFCAndPassword(loginVM.RFC, loginVM.Password);
        if (contribuyente == null)
        {
            TempData["Error!"] = "Este contribuyente no existe";
            return View(loginVM);
        }
        CookieOptions options = new CookieOptions()
        {
            Expires = DateTime.Now.AddDays(7)
        };
        
        Response.Cookies.Append("RFC",loginVM.RFC,options);
        return RedirectToAction("Index","Home");
        
    }
}
