using GramR.Controller;
using GramR.Model;
using Microsoft.Extensions.DependencyInjection;

namespace GramR
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            Application.SetColorMode(SystemColorMode.Dark);

            var serviceProvider = ConfigureServices.CreateServiceProvider();
            var mainForm = serviceProvider.GetService<MainForm>();

            Application.Run(mainForm!);
        }

        public static class ConfigureServices
        {
            public static ServiceProvider CreateServiceProvider()
            {
                var services = new ServiceCollection();

                services.AddSingleton<DataModel>();
                services.AddSingleton<DataController>();
                services.AddSingleton<MainForm>();

                return services.BuildServiceProvider();
            }
        }
    }
}