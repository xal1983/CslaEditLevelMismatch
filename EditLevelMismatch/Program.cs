using Csla.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditLevelMismatch
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureCsla();
            Application.Run(new Form1());
        }
        public static IHost Host { get; private set; }
        static void ConfigureCsla() {
            var host = new HostBuilder().ConfigureServices(
              (HostBuilderContext context, IServiceCollection services ) => {

                services.AddCsla(
                  (opt) => { 
                    opt.AddWindowsForms();
                  });


                
              }).Build();
            Host = host;

        }
    }
}
