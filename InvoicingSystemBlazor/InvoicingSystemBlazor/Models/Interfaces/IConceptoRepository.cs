using InvoicingSystemBlazor.Models.Entities;

namespace InvoicingSystemBlazor.Models.Interfaces;

public interface IConceptoRepository
{
    public bool Add(Concepto concepto);
    public Task<IEnumerable<Concepto>> GetConceptosByRFC(string RFC);
    public bool Save();
}