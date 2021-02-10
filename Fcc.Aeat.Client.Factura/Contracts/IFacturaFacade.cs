using System.Collections.Generic;
using System.Threading.Tasks;
using Dto = Fcc.Aeat.Client.Factura.Contracts.Dto;

namespace Fcc.Aeat.Client.Factura.Business.Facade.Contracts
{
    public interface IFacturaFacade
    {
        Task<List<Dto.Factura>> GetAll(Dto.FacturaRequestDto facturaRequestDto);
    }
}
