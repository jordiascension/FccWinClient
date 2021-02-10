using Fcc.Aeat.Client.Factura.Business.Facade.Contracts;
using Fcc.Aeat.Client.Factura.Contracts.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dto = Fcc.Aeat.Client.Factura.Contracts.Dto;

namespace Fcc.Aeat.Client.Factura.WinSite
{
    public partial class Form1 : Form
    {

        private IFacturaFacade _iFacturaFacade;

        public Form1(IFacturaFacade iFacturaFacade)
        {
            _iFacturaFacade = iFacturaFacade;
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await ProcessRepositories();
        }

        private async Task ProcessRepositories()
        {
            var facturaRequestDto = new FacturaRequestDto()
            {
                Nif = "B65346789",
                FechaInicio = "26-04-20",
                FechaFin = "26-04-20"
            };

            var facturas = await _iFacturaFacade.GetAll(facturaRequestDto);
            dgrFacturas.DataSource = facturas;

        }
    }
}
