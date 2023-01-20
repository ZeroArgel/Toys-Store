namespace ToysStore.Desktop.Views.Companies
{
    using Models.Requests.Companies;
    using System;
    using System.Windows.Forms;
    using ZAExtensions.Forms;
    public sealed partial class FrmAddUpdCompany : Form
    {
        private readonly Guid? _companyId;
        private readonly string _message;
        public FrmAddUpdCompany(string title, Guid? companyId = null)
        {
            try
            {
                InitializeComponent();
                var message = "The next company '{0}' shall be save";
                if (companyId != null)
                {
                    var company = (Program.CompaniesHandler.GetId((Guid)companyId).Result).Data;
                    TxtCompanyName.Text = company.CompanyName;
                    title = string.Format(title, company.CompanyName);
                    message = "The next company '" + company.CompanyName + "' shall be replace for '{0}'";
                }
                _companyId = companyId;
                _message = message;
                this.Text = title;
            }
            catch (Exception ex)
            {
                MessageBoxButtons.OK.ToErrorMessage(ex.Message, "Error");
            }
        }
        #region OnSaveCompany
        private async void OnSaveCompany(object sender, EventArgs e)
        {
            try
            {
                var message = string.Format(_message, TxtCompanyName.Text);
                if (_companyId == null && "Are you sure to add?".ToConfirmMessage(message))
                {
                    var request = new AddCompany.Request { CompanyName = TxtCompanyName.Text };
                    Program.Success = (await Program.CompaniesHandler.Add(request)).Success;
                    Close();
                }
                if (_companyId != null && "Are you sure to update?".ToConfirmMessage(message))
                {
                    var request = new UpdateCompany.Request{ CompanyName = TxtCompanyName.Text };
                    Program.Success = (await Program.CompaniesHandler.Update((Guid)_companyId, request)).Success;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBoxButtons.OK.ToErrorMessage(ex.Message, "Error");
            }
        }
        #endregion
        private void OnCancelCompany(object sender, EventArgs e) => Close();
    }
}