
namespace ToysStore.Desktop.Views.Companies
{
    sealed partial class FrmAddUpdCompany
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddUpdCompany));
            this.GbxTitleCompany = new System.Windows.Forms.GroupBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TxtCompanyName = new System.Windows.Forms.TextBox();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.GbxTitleCompany.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbxTitleCompany
            // 
            this.GbxTitleCompany.Controls.Add(this.BtnSave);
            this.GbxTitleCompany.Controls.Add(this.BtnCancel);
            this.GbxTitleCompany.Controls.Add(this.TxtCompanyName);
            this.GbxTitleCompany.Controls.Add(this.LblCompanyName);
            this.GbxTitleCompany.Location = new System.Drawing.Point(21, 19);
            this.GbxTitleCompany.Margin = new System.Windows.Forms.Padding(5);
            this.GbxTitleCompany.Name = "GbxTitleCompany";
            this.GbxTitleCompany.Padding = new System.Windows.Forms.Padding(5);
            this.GbxTitleCompany.Size = new System.Drawing.Size(586, 174);
            this.GbxTitleCompany.TabIndex = 0;
            this.GbxTitleCompany.TabStop = false;
            this.GbxTitleCompany.Text = "Company Info";
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.Lime;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSave.ForeColor = System.Drawing.Color.Black;
            this.BtnSave.Location = new System.Drawing.Point(412, 110);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(5);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(164, 45);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.OnSaveCompany);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Red;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCancel.Location = new System.Drawing.Point(10, 110);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(164, 45);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.OnCancelCompany);
            // 
            // TxtCompanyName
            // 
            this.TxtCompanyName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TxtCompanyName.Location = new System.Drawing.Point(28, 70);
            this.TxtCompanyName.Margin = new System.Windows.Forms.Padding(5);
            this.TxtCompanyName.Name = "TxtCompanyName";
            this.TxtCompanyName.Size = new System.Drawing.Size(529, 30);
            this.TxtCompanyName.TabIndex = 1;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.AutoSize = true;
            this.LblCompanyName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCompanyName.Location = new System.Drawing.Point(28, 42);
            this.LblCompanyName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(138, 23);
            this.LblCompanyName.TabIndex = 0;
            this.LblCompanyName.Text = "Company Name";
            // 
            // FrmAddUpdCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(621, 200);
            this.Controls.Add(this.GbxTitleCompany);
            this.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmAddUpdCompany";
            this.Text = "Toys Store - Add Company";
            this.GbxTitleCompany.ResumeLayout(false);
            this.GbxTitleCompany.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxTitleCompany;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox TxtCompanyName;
        private System.Windows.Forms.Label LblCompanyName;
    }
}