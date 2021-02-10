using Fcc.Aeat.Client.Factura.Business.Facade.Contracts;
using Fcc.Aeat.Client.Factura.Business.Facade.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Windows.Forms;

namespace Fcc.Aeat.Client.Factura.WinSite
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Importante copiar appsettings.json a la carpeta de compilación
            var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true)
        .Build();

            var settings = config["AppSettings:Version"];

            var host = new HostBuilder()
                .ConfigureServices((context, services) =>
                {

                    // Main form
                    services.AddSingleton<Form1>();

                    // Transient Services
                    services.AddTransient<IFacturaFacade, FacturaFacade>();

                })
                .Build();


            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var form1 = services.GetRequiredService<Form1>();
                Application.Run(form1);
            }
        }


    }
}
