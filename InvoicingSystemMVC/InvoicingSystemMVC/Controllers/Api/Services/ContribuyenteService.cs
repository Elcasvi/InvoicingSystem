using InvoicingSystemMVC.Controllers.Api.Services.Interfaces;
using InvoicingSystemMVC.Models.Entities;

namespace InvoicingSystemMVC.Controllers.Api.Services;

public class ContribuyenteService:IContribuyenteService
{
    private readonly HttpClient _httpClient;

    public ContribuyenteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Contribuyente> GetContribuyente(string RFC)
    {
        var contribuyente= await _httpClient.GetFromJsonAsync<Contribuyente>("/ApiContribuyente/"+RFC);
        return contribuyente;
    }
}