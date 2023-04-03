﻿using InvoicingSystemMVC.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InvoicingSystemMVC.Controllers;

//[Route("api/[Controller]")]
public class FacturaController:Controller
{
    private readonly IClienteRepository _clienteRepository;

    public FacturaController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var clientes=await _clienteRepository.GetAllClientes();
        return View(clientes);
    }
}