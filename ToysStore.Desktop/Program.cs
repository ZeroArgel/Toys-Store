namespace ToysStore.Desktop
{
    using Handlers;
    using Handlers.Core;
    using System;
    using System.Windows.Forms;
    using ZAExtensions.zCore;
    internal static class Program
    {
        internal static bool Success { get; set; }
        internal static ZHttpClient ZHttpClient { get; } = new ("https://localhost:5001".ToUri());
        internal static string UrlBaseApi { get; } = "https://localhost:5001/api/";
        internal static ICompaniesHandler CompaniesHandler { get; set; }
        internal static IProductsHandler ProductsHandler { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }

        internal static void SetCompanies() => CompaniesHandler = new CompaniesHandler();
        internal static void SetProducts() => ProductsHandler = new ProductsHandler();
        internal static void DestructInstances()
        {
            CompaniesHandler = null;
            ProductsHandler = null;
        }
    }
}