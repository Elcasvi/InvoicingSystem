using InvoicingSystemBlazor.Controllers.Api.Services.Interfaces;
using InvoicingSystemBlazor.Models.Entities;


namespace InvoicingSystemBlazor.Controllers.Api.Services;

public class ContribuyenteService:IContribuyenteService
{
    private readonly HttpClient _httpClient;

    public ContribuyenteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<Contribuyente> GetContribuyente(string RFC)
    {
        var contribuyente=  _httpClient.GetFromJsonAsync<Contribuyente>("/ApiContribuyente/"+RFC);
        //Console.WriteLine(contribuyente.Result);
        return contribuyente;
    }
}