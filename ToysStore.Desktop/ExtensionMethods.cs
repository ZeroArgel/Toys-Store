namespace ToysStore.Desktop
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using ZAExtensions.zCore;
    using ZAExtensions.zHttp;
    using ZAExtensions.Forms;
    public static class ExtensionMethods
    {
        public static void ShowForm(this Form formMain, Form formChild)
        {
            formMain.ToSpinner();
            formMain.Hide();
            formChild.ShowDialog();
            formChild.Dispose();
            formMain.Show();
            formMain.ToSpinner();
        }
        public static Task<ZResult<TR>> Get<TR>(this string url) =>
            HttpMethod.Get.SendResponse<ZResult<TR>>($"{Program.UrlBaseApi}{url}", Program.ZHttpClient);
        public static Task<ZResult<TR>> Post<T, TR>(this T model, string url) =>
            HttpMethod.Post.SendResponse<T, ZResult<TR>>(model, $"{Program.UrlBaseApi}{url}", Program.ZHttpClient);
        public static Task<ZResult<TR>> Put<T, TR>(this T model, string url) =>
            HttpMethod.Put.SendResponse<T, ZResult<TR>>(model, $"{Program.UrlBaseApi}{url}", Program.ZHttpClient);
        public static Task<ZResult<TR>> Delete<TR>(this string url) =>
            HttpMethod.Delete.SendResponse<ZResult<TR>>($"{Program.UrlBaseApi}{url}", Program.ZHttpClient);
    }
}