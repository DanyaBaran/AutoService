using AutoService.Infrastructure;

namespace AutoService
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var serviceProvider = new ServiceProvider();

            Application.Run(new MainForm(serviceProvider));
        }
    }
}