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

    
    public Task<HttpResponseMessage> PostFactura(CrearFacturaViewModel facturaVM)
    {
        string fechaYHora=DateTime.Now.ToString("s");
        Console.WriteLine("fecha y hora: "+fechaYHora);
        //2019-01-06T17:16:40
        /*
        // 2015 is year, 12 is month, 25 is day  
        DateTime date1 = new DateTime(2015, 12, 25);   
        Console.WriteLine(date1.ToString()); // 12/25/2015 12:00:00 AM    
      
        // 2015 - year, 12 - month, 25 – day, 10 – hour, 30 – minute, 50 - second  
        DateTime date2 = new DateTime(2012, 12, 25, 10, 30, 50);   
        Console.WriteLine(date1.ToString());// 12/25/2015 10:30:00 AM }  
        
        
        DateTime tempDate = new DateTime(2015, 12, 08); // creating date object with 8th December 2015  
        Console.WriteLine(tempDate.ToString("MMMM dd, yyyy")); //December 08, 2105.  
        DateTime tempDate2 = new DateTime(2015, 12, 08,10, 30, 50); // creating date object with 8th December 2015
        Console.WriteLine(tempDate2.ToString("s")); //December 08, 2105.
*/
        

        ContribuyenteEmisor contribuyenteEmisor = new ContribuyenteEmisor()
        {
            RFC = facturaVM.Contribuyente.RFC,
            RazonSocial = facturaVM.Contribuyente.RazonSocial,
            RegimenFiscal= facturaVM.Contribuyente.RegimenFiscal,
            CP = facturaVM.Contribuyente.CP
        };
        
        ContribuyenteReceptor contribuyenteReceptor = new ContribuyenteReceptor()
        {
            RFC = facturaVM.Cliente.RFC,
            RazonSocial = facturaVM.Cliente.RazonSocial,
            RegimenFiscal = facturaVM.Cliente.RegimenFiscal,
            CP = facturaVM.Cliente.CP
        };

        Factura factura = new Factura()
        {
            ContribuyenteEmisor = contribuyenteEmisor,
            ContribuyenteReceptor = contribuyenteReceptor,
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
        
        
        Console.WriteLine(factura.ToString());
        
        
        var response = _httpClient.PostAsJsonAsync("/ApiFactura",factura);
        Console.WriteLine("Response: "+response);
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
        
        /*
        foreach (var concepto in facturaVM.ConceptosViewModel)
        {
            
        }
        */
        return response;
        //return await response.Content.ReadFromJsonAsync<bool>();
    }
}