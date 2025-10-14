using System.Globalization;

namespace Medidor_de_Temperatura
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-Br");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-Br");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);   
            Application.Run(new FormularioPrincipal());
        }
    }
}