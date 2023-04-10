using InvoicingSystemMVC.Controllers.Api.Services.Interfaces;
using InvoicingSystemMVC.Models.Entities;


namespace InvoicingSystemMVC.Controllers.Api.Services;

public class FacturaService:IFacturaService
{
    private readonly HttpClient _httpClient;

    public FacturaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    
    public async Task<bool> PostFactura(Factura factura)
    {
        var response = await _httpClient.PostAsJsonAsync("/ApiFactura",factura);
        return await response.Content.ReadFromJsonAsync<bool>();
    }


   
}