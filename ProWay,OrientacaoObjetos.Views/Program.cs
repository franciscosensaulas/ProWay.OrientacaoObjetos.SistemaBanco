using ProWay.OrientacaoObjetos.Views.Contas;

namespace ProWay.OrientacaoObjetos.Views
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //Application.Run(new FormPrincipal());
            Application.Run(new FormContaPoupanca());
        }
    }
}