
namespace ToysStore.Desktop.Views.Companies
{
    partial class FrmCompanies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompanies));
            this.GbxCompanies = new System.Windows.Forms.GroupBox();
            this.DgvCompanies = new System.Windows.Forms.DataGridView();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.GbxCompanies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCompanies)).BeginInit();
            this.SuspendLayout();
            // 
            // GbxCompanies
            // 
            this.GbxCompanies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.GbxCompanies.Controls.Add(this.DgvCompanies);
            this.GbxCompanies.Controls.Add(this.BtnAdd);
            this.GbxCompanies.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GbxCompanies.Location = new System.Drawing.Point(12, 12);
            this.GbxCompanies.Name = "GbxCompanies";
            this.GbxCompanies.Size = new System.Drawing.Size(887, 319);
            this.GbxCompanies.TabIndex = 0;
            this.GbxCompanies.TabStop = false;
            this.GbxCompanies.Text = "Companies";
            // 
            // DgvCompanies
            // 
            this.DgvCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCompanies.Location = new System.Drawing.Point(7, 61);
            this.DgvCompanies.Name = "DgvCompanies";
            this.DgvCompanies.RowHeadersWidth = 51;
            this.DgvCompanies.RowTemplate.Height = 29;
            this.DgvCompanies.Size = new System.Drawing.Size(874, 252);
            this.DgvCompanies.TabIndex = 2;
            this.DgvCompanies.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnSelectCompany);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.Lime;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnAdd.Location = new System.Drawing.Point(787, 26);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(94, 29);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.OnAddCompany);
            // 
            // FrmCompanies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(911, 342);
            this.Controls.Add(this.GbxCompanies);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCompanies";
            this.Text = "Toys Store - View Companies";
            this.GbxCompanies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCompanies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxCompanies;
        private System.Windows.Forms.DataGridView DgvCompanies;
        private System.Windows.Forms.Button BtnAdd;
    }
}