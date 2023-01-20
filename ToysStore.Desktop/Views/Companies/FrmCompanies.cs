namespace ToysStore.Desktop.Views.Companies
{
    #region using.
    using Models.Requests.Companies;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using ZAExtensions.Forms;
    using ZAExtensions.Forms.Models;
    using ZAExtensions.zCore;
    #endregion
    public partial class FrmCompanies : Form
    {
        public FrmCompanies()
        {
            InitializeComponent();
            this.ToSpinner();
            GetCompany().ConfigureAwait(true);
            this.ToSpinner();
        }
        #region GetCompany
        private async Task GetCompany()
        {
            try
            {
                var companies = await Program.CompaniesHandler.Get();
                var btnDelete = new List<BtnModel> { new(OnDeleteCompany, "Delete", "Can delete") };
                var dgvConfig = new ZDgvConfig<GetCompanies.Response>(companies.Data, true, btnDelete);
                DgvCompanies.ToAddDgv(dgvConfig);
                Program.Success = false;
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
        #region OnDeleteCompany
        private async void OnDeleteCompany(object _, DataGridViewCellEventArgs e)
        {
            try
            {
                this.ToSpinner();
                var deleteIndex = DgvCompanies.Columns["Can delete"]?.Index;
                if (deleteIndex == null || e.ColumnIndex != deleteIndex) return;

                var companyIdIndex = DgvCompanies.Columns["CompanyId"]?.Index ??
                                     throw new ZException("please refresh or reopen screen, and try again");

                var id = DgvCompanies[companyIdIndex, e.RowIndex].Value.ToGuid();
                var isDelete = await Program.CompaniesHandler.Delete(id);
                if (!isDelete.Success) throw new ZException(isDelete.Message, isDelete.StatusCode);
                await GetCompany();
                "Company Deleted".ToSuccessMessage("(Success) Toys Store");
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
        #region OnSelectCompany
        private void OnSelectCompany(object sender, DataGridViewCellEventArgs e)
        {
            var companyIdIndex = DgvCompanies.Columns["CompanyId"]?.Index ?? throw new ZException("please refresh or reopen screen, and try again");

            var companyId = DgvCompanies[companyIdIndex, e.RowIndex].Value.ToGuid();
            this.ShowForm(new FrmAddUpdCompany("Toys Store - Update Company '{0}'", companyId));
            Refresh(Program.Success, "(Success) Toys Store", "Company Updated");
        }
        #endregion
        private void OnAddCompany(object sender, EventArgs e)
        {
            this.ShowForm(new FrmAddUpdCompany("Toys Store - Add Company"));
            Refresh(Program.Success, "(Success) Toys Store", "Company Saved");
        }
        private async void Refresh(bool success, string title, string message)
        {
            if (!success) return;
            await GetCompany();
            message.ToSuccessMessage(title);
            Program.Success = false;
        }
    }
}