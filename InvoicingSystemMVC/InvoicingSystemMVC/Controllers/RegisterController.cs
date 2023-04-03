using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.Interfaces;
using InvoicingSystemMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers;

public class RegisterController:Controller
{
    private readonly IContribuyenteRepository _contribuyenteRepository;

    public RegisterController(IContribuyenteRepository contribuyenteRepository)
    {
        _contribuyenteRepository = contribuyenteRepository;
    }

    public IActionResult Index()
    {
        RegisterContribuyenteViewModel contribuyenteViewModel = new RegisterContribuyenteViewModel();
        return View(contribuyenteViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegisterContribuyenteViewModel contribuyenteVM)
    {
        if (!ModelState.IsValid)
        {
            return View(contribuyenteVM);
        }
        Console.WriteLine("Antes de la llamada a la Db");
        var contribuyente =await _contribuyenteRepository.GetContribuyenteByRFC(contribuyenteVM.RFC);
        Console.WriteLine("contribuyente: "+contribuyente);
        if (contribuyente!=null)
        {
            TempData["Error!"] = "Este contribuyente ya existe";
            return View(contribuyenteVM);
        }
        Contribuyente newContribuyente = new Contribuyente()
        {
            RFC = contribuyenteVM.RFC,
            RazonSocial = contribuyenteVM.RazonSocial,
            RegimenFiscal = contribuyenteVM.RegimenFiscal,
            CP=contribuyenteVM.CP,
            Password = contribuyenteVM.Password
        };
        Console.WriteLine("newContribuyente: "+newContribuyente);

        CookieOptions options = new CookieOptions();
        Response.Cookies.Append("RFC",newContribuyente.RFC,options);
        
        _contribuyenteRepository.Add(newContribuyente);
        return RedirectToAction("Index","Home");
    }
}