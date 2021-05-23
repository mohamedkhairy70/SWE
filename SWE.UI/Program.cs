using Microsoft.Extensions.DependencyInjection;
using SWE.UI.Forms;
using SWE.UI.interfaces;
using SWE.UI.Models;
using System;
using System.Windows.Forms;

namespace SWE.UI
{
    static class Program
    {

        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped(typeof(IUnitOfWork), typeof(Models.UnitOfWork));

            services.AddScoped(typeof(IRepository<>), typeof(GUIDRepository<>));

            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigureServices();
            Application.Run(new frm_Main());
        }

    }
}
