namespace ToysStore.Desktop.Views.Products
{
    using Models.Requests.Companies;
    using Models.Requests.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using ZAExtensions.Forms;
    using ZAExtensions.Forms.Models;
    using ZAExtensions.zCore;
    public sealed partial class FrmAddUpdProduct : Form
    {
        private readonly Guid? _productId;
        private readonly string _message;
        public FrmAddUpdProduct(string title, Guid? productId = null)
        {
            try
            {
                InitializeComponent();
                var message = "The next product '{0}' shall be save";
                if (productId != null)
                {
                    var product = (Program.ProductsHandler.GetId((Guid)productId).Result).Data;
                    TxtProductName.Text = product.ProductName;
                    TxtProductDescription.Text = product.CompanyName;
                    TxtPrice.Text = product.Price.ToString("F");
                    TxtRestrictionAge.Text = product.RestrictionAge.ToString();
                    title = string.Format(title, product.ProductName);
                    message = "The next product '" + product.ProductName + "' shall be replace for '{0}'";
                }

                var companies = Program.CompaniesHandler.Get()
                    .Result
                    .Data
                    .ToMap<IEnumerable<GetCompanies.Response>, IEnumerable<CbxModel<string, Guid>>>()
                    .ToList();
                CbxCompany.ToAddCbx(new ZCbxConfig<string, Guid>(companies));

                _productId = productId;
                _message = message;
                this.Text = title;
            }
            catch (Exception ex)
            {
                MessageBoxButtons.OK.ToErrorMessage(ex.Message, "Error");
            }
        }
        #region OnSaveProduct
        private async void OnSaveProduct(object sender, EventArgs e)
        {
            try
            {
                var companyId = CbxCompany.SelectedValue.ToGuid();
                var price = TxtPrice.Text.ToDecimal();
                var restrictionAge = TxtRestrictionAge.Text.ToInt();
                var message = string.Format(_message, TxtProductName.Text);
                if (_productId == null && "Are you sure to add?".ToConfirmMessage(message))
                {
                    var request = new AddProduct.Request
                    {
                        ProductName = TxtProductName.Text,
                        ProductDescription = TxtProductDescription.Text,
                        CompanyId = companyId,
                        Price = price,
                        RestrictionAge = restrictionAge
                    };
                    Program.Success = (await Program.ProductsHandler.Add(request)).Success;
                    Close();
                }
                if (_productId != null && "Are you sure to update?".ToConfirmMessage(message))
                {
                    var request = new UpdateProduct.Request
                    {
                        ProductName = TxtProductName.Text,
                        ProductDescription = TxtProductDescription.Text,
                        CompanyId = companyId,
                        Price = price,
                        RestrictionAge = restrictionAge
                    };
                    Program.Success = (await Program.ProductsHandler.Update((Guid)_productId, request)).Success;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK);
            }
        }
        #endregion
        private void OnCancelProduct(object sender, EventArgs e) => this.Close();
    }
}