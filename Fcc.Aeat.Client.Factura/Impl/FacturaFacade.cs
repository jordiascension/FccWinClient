using Fcc.Aeat.Client.Factura.Business.Facade.Contracts;
using Fcc.Aeat.Client.Factura.Contracts.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dto = Fcc.Aeat.Client.Factura.Contracts.Dto;

namespace Fcc.Aeat.Client.Factura.Business.Facade.Impl
{
    public class FacturaFacade : IFacturaFacade
    {
        private readonly HttpClient client = new HttpClient();

        public async Task<List<Dto.Factura>> GetAll(Dto.FacturaRequestDto facturaRequestDto)
        {


            var json = JsonConvert.SerializeObject(facturaRequestDto);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44301/api/factura"),

                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var response = client.SendAsync(request);
            var content = response.GetAwaiter().GetResult().Content;
            var result = content.ReadAsStringAsync().GetAwaiter().GetResult();

            var facturas = JsonConvert.
                    DeserializeObject<List<Dto.Factura>>(result);

            //https://www.tpisoftware.com/tpu/articleDetails/2007
            return facturas;
        }
    }
}
