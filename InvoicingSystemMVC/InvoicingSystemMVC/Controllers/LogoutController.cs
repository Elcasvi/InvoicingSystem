using System.Net;
using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.Interfaces;
using InvoicingSystemMVC.Models.ViewModels;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;


namespace InvoicingSystemMVC.Controllers;

public class LogoutController:Controller
{
    private readonly IContribuyenteRepository _contribuyenteRepository;

    public LogoutController(IContribuyenteRepository contribuyenteRepository)
    {
        _contribuyenteRepository = contribuyenteRepository;
    }

    public async Task<IActionResult> Index(string RFC)
    {
        LogoutContribuyenteViewModel logoutContribuyenteVM = new LogoutContribuyenteViewModel()
        {
            Contribuyente = await _contribuyenteRepository.GetContribuyenteByRFC(RFC)
        };
        return View(logoutContribuyenteVM);
    }

    [HttpPost]
    public async Task<IActionResult> Index()
    {
        string key = "RFC";
        string value = string.Empty;
        CookieOptions options = new CookieOptions()
        {
            Expires = DateTime.Now.AddDays(-1)
        };
        Response.Cookies.Append(key,value,options);
        return RedirectToAction("Index","Home");
    }
}