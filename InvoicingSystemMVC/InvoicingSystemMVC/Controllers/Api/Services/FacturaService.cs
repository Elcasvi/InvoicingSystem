using InvoicingSystemMVC.Controllers.Api.Services.Interfaces;
using InvoicingSystemMVC.Models.Entities;
using InvoicingSystemMVC.Models.ViewModels.Facturas;


namespace InvoicingSystemMVC.Controllers.Api.Services;

public class FacturaService:IFacturaService
{
    private readonly HttpClient _httpClient;

    public FacturaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    
    public async Task<HttpResponseMessage> PostFactura(CrearFacturaViewModel facturaVM)
    {
        string fechaYHora=DateTime.Now.ToString("s");

        Console.WriteLine("Size: "+facturaVM.ConceptosViewModel.Count());
        Factura factura = new Factura()
        {
            RFCEmsior = facturaVM.Contribuyente.RFC,
            RFCReceptor = facturaVM.Cliente.RFC,
            TipoDeFactura = facturaVM.TipoDeFactura,
            UsoDeFactura = facturaVM.UsoDeFactura,
            FechaHoraDeExpedicion = fechaYHora,
            Moneda = facturaVM.Moneda.ToString(),
            FormaDePago = facturaVM.FormaDePago.ToString(),
            MetodoDePago = facturaVM.MetodoDePago.ToString(),
            Serie = facturaVM.Serie,
            Folio=facturaVM.Folio,
            CondicionesDePago = facturaVM.CondicionesDePago,
            SubtotalFactura = facturaVM.SubtotalFactura,
            DescuentoFactura = facturaVM.DescuentoFactura,
            TotalIVA = facturaVM.TotalIVA,
            TotalFactura = facturaVM.TotalFactura,
        };
        
        var response =await _httpClient.PostAsJsonAsync("/ApiFactura",factura);
        
        Console.WriteLine("Antes de recuperar la factura");
        Factura facturaRecuperada = await _httpClient.GetFromJsonAsync<Factura>("/ApiFactura/"+factura.RFCEmsior+"/"+factura.RFCReceptor+"/"+factura.FechaHoraDeExpedicion);
        Console.WriteLine("----------------------------------------------------------------------------------------------");
        Console.WriteLine("facturaRecuperada: "+facturaRecuperada.Id);
        
        
        Console.WriteLine("Size: "+facturaVM.ConceptosViewModel.Count());
        foreach (var VARIABLE in facturaVM.ConceptosViewModel)
        {
            Console.WriteLine("Descripcion: "+VARIABLE.Descripcion);
            Console.WriteLine("Cantidad"+VARIABLE.Cantidad);
        }

        PostConceptos(facturaVM.ConceptosViewModel,facturaRecuperada);
        return response;
        //return await response.Content.ReadFromJsonAsync<bool>();
    }

    private async void PostConceptos(List<ConceptoViewModel> conceptosVM,Factura facturaRecuperada)
    {
        foreach (ConceptoViewModel conceptoVM in conceptosVM)
        {
            Console.WriteLine("Dentro del foreach");
            Concepto concepto = new Concepto()
            {
                ClaveDeProductoOServicio = conceptoVM.ClaveDeProductoOServicio,
                ClaveDeUnidad = conceptoVM.ClaveDeUnidad,
                Cantidad = conceptoVM.Cantidad,
                Unidad = conceptoVM.Unidad,
                NumeroDeIdentificacion=conceptoVM.NumeroDeIdentificacion,
                Descripcion = conceptoVM.Descripcion,
                ValorUnitario = conceptoVM.ValorUnitario,
                TieneIVA = conceptoVM.TieneIVA,
                TasaIVA = conceptoVM.TasaIVA,
                TotalIVA = conceptoVM.TotalIVA,
                FacturaId = facturaRecuperada.Id
            };
            Console.WriteLine("Antes de agregar un nuevo concepto"+concepto.Descripcion);
            var res=await _httpClient.PostAsJsonAsync("/ApiConcepto",concepto);
            Console.WriteLine("Concepto hecho: "+res);
        }
    }
}