namespace ToysStore.Desktop.Views
{
    using System;
    using System.Windows.Forms;
    using Companies;
    using Products;
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void OnViewCompanies(object sender, EventArgs e)
        {
            Program.SetCompanies();
            this.ShowForm(new FrmCompanies());
        }

        private void OnAddCompany(object sender, EventArgs e)
        {
            Program.SetCompanies();
            this.ShowForm(new FrmAddUpdCompany("Toys Store - Add Company"));
        }

        private void OnViewProducts(object sender, EventArgs e)
        {
            Program.SetCompanies();
            Program.SetProducts();
            this.ShowForm(new FrmProducts());
        }

        private void OnAddProduct(object sender, EventArgs e)
        {
            Program.SetCompanies();
            Program.SetProducts();
            this.ShowForm(new FrmAddUpdProduct("Toys Store - Add Product"));
        }

        ~FrmHome()
        {
            Program.DestructInstances();
        }
    }
}