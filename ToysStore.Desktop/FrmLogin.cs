namespace ToysStore.Desktop
{
    using System;
    using System.Windows.Forms;
    using Views;
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void OnLogin(object sender, EventArgs e)
        {
            var home = new FrmHome();
            this.ShowForm(home);
        }
    }
}