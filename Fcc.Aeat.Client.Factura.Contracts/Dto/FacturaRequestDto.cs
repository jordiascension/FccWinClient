using System;

namespace Fcc.Aeat.Client.Factura.Contracts.Dto
{
    public class FacturaRequestDto
    {
        public String Nif { get; set; }
        public String FechaInicio { get; set; }
        public String FechaFin { get; set; }

    }
}
