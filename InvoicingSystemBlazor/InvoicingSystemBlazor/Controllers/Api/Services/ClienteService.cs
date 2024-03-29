﻿using InvoicingSystemBlazor.Controllers.Api.Services.Interfaces;
using InvoicingSystemBlazor.Models.Entities;

namespace InvoicingSystemBlazor.Controllers.Api.Services;

public class ClienteService:IClienteService
{
    private readonly HttpClient _httpClient;

    public ClienteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<List<Cliente>> GetClientes()
    {
        var clientes= _httpClient.GetFromJsonAsync<List<Cliente>>("/ApiCliente");
        return clientes;
    }
}