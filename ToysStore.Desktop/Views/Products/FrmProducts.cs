namespace ToysStore.Desktop.Views.Products
{
    #region using.
    using Models.Requests.Products;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using ZAExtensions.Forms;
    using ZAExtensions.Forms.Models;
    using ZAExtensions.zCore;
    #endregion
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
            this.ToSpinner();
            GetProduct().ConfigureAwait(true);
            this.ToSpinner();
        }
        #region GetProduct
        private async Task GetProduct()
        {
            try
            {
                var products = await Program.ProductsHandler.Get();
                var btnDelete = new List<BtnModel> { new(DeleteProduct, "Delete", "Delete") };
                var dgvConfig = new ZDgvConfig<GetProducts.Response>(products.Data, true, btnDelete);
                DgvProducts.ToAddDgv(dgvConfig);
            }
            catch (ZException ex)
            {
                MessageBoxButtons.OK.ToErrorMessage($@"{ex.Message}. {ex.InnerException}", @"Error");
            }
            catch (Exception ex)
            {
                MessageBoxButtons.OK.ToErrorMessage($@"{ex.Message}. {ex.InnerException}", @"Error");
            }
        }
        #endregion
        #region DeleteProduct
        private async void DeleteProduct(object _, DataGridViewCellEventArgs e)
        {
            try
            {
                this.ToSpinner();
                var deleteIndex = DgvProducts.Columns["Delete"]?.Index;
                if (deleteIndex == null || e.ColumnIndex != deleteIndex) return;

                var productIdIndex = DgvProducts.Columns["ProductId"]?.Index ??
                                     throw new ZException("please refresh or reopen screen, and try again");

                var id = DgvProducts[productIdIndex, e.RowIndex].Value.ToGuid();
                var isDelete = await Program.ProductsHandler.Delete(id);
                if (!isDelete.Success) throw new ZException(isDelete.Message, isDelete.StatusCode);
                await GetProduct();
                "Product Deleted".ToSuccessMessage("(Success) Toys Store");
            }
            catch (ZException ex)
            {
                MessageBoxButtons.OK.ToErrorMessage($@"{ex.Message}. {ex.InnerException}", @"Error");
            }
            catch (Exception ex)
            {
                MessageBoxButtons.OK.ToErrorMessage($@"{ex.Message}. {ex.InnerException}", @"Error");
            }
            finally
            {
                this.ToSpinner();
            }
        }
        #endregion
        #region SelectProduct
        private void SelectProduct(object sender, DataGridViewCellEventArgs e)
        {
            var row = e.RowIndex;
            var productIdIndex = DgvProducts.Columns["ProductId"]?.Index ?? throw new ZException("please refresh or reopen screen, and try again");

            var productId = DgvProducts[productIdIndex, row].Value.ToGuid();
            this.ShowForm(new FrmAddUpdProduct("Toys Store - Update Product '{0}'", productId));
            Refresh(Program.Success, "(Success) Toys Store", "Product Updated");
        }
        #endregion
        private void OnAddProduct(object sender, EventArgs e)
        {
            this.ShowForm(new FrmAddUpdProduct("Toys Store - Add Product"));
            Refresh(Program.Success, "(Success) Toys Store", "Product Saved");
        }
        private async void Refresh(bool success, string title, string message)
        {
            if (!success) return;
            await GetProduct();
            message.ToSuccessMessage(title);
            Program.Success = false;
        }
    }
}