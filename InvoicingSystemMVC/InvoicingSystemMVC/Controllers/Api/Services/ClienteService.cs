﻿using InvoicingSystemMVC.Controllers.Api.Services.Interfaces;
using InvoicingSystemMVC.Models.Entities;

namespace InvoicingSystemMVC.Controllers.Api.Services;

public class ClienteService:IClienteService
{
    private readonly HttpClient _httpClient;

    public ClienteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Cliente>> Clientes()
    {
        return await _httpClient.GetFromJsonAsync<List<Cliente>>("/ApiCliente");
    }
}