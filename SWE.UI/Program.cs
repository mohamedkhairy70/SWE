using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SWE.UI.Forms;
using SWE.UI.interfaces;
using SWE.UI.Models;
using SWE.UI.Models.Domain;
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

            services.AddScoped(typeof(IUnitOfWork<>), typeof(Models.UnitOfWork<>));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
            Application.Run(new Faculties());


            //var container = Bootstrap();

            //Application.Run(container.GetInstance<Form1>());
        }
        //private static Container Bootstrap()
        //{
        //    // Create the container as usual.
        //    var container = new Container();

        //    // Register your types, for instance:
        //    container.Register<IUnitOfWork<Facultie>, UnitOfWork<Facultie>>();

        //    AutoRegisterWindowsForms(container);

        //    container.Verify();

        //    return container;
        //}

        //private static void AutoRegisterWindowsForms(Container container)
        //{
        //    var types = container.GetTypesToRegister<Form>(typeof(Program).Assembly);

        //    foreach (var type in types)
        //    {
        //        var registration =
        //            Lifestyle.Transient.CreateRegistration(type, container);

        //        registration.SuppressDiagnosticWarning(
        //            DiagnosticType.DisposableTransientComponent,
        //            "Forms should be disposed by app code; not by the container.");

        //        container.AddRegistration(type, registration);
        //    }
        //}
    }
}
