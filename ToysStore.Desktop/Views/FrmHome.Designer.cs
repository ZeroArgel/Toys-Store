
namespace ToysStore.Desktop.Views
{
    partial class FrmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHome));
            this.PnlHome = new System.Windows.Forms.Panel();
            this.HomeMenu = new System.Windows.Forms.MenuStrip();
            this.companiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmViewCompanies = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmAddCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmViewProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmAddProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlHome.SuspendLayout();
            this.HomeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlHome
            // 
            this.PnlHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlHome.BackgroundImage")));
            this.PnlHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlHome.Controls.Add(this.HomeMenu);
            this.PnlHome.Location = new System.Drawing.Point(-1, -1);
            this.PnlHome.Name = "PnlHome";
            this.PnlHome.Size = new System.Drawing.Size(684, 348);
            this.PnlHome.TabIndex = 0;
            // 
            // HomeMenu
            // 
            this.HomeMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.HomeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.HomeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companiesToolStripMenuItem,
            this.productsToolStripMenuItem});
            this.HomeMenu.Location = new System.Drawing.Point(0, 0);
            this.HomeMenu.Name = "HomeMenu";
            this.HomeMenu.Size = new System.Drawing.Size(684, 28);
            this.HomeMenu.TabIndex = 0;
            this.HomeMenu.Text = "menuStrip1";
            // 
            // companiesToolStripMenuItem
            // 
            this.companiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmViewCompanies,
            this.TsmAddCompany});
            this.companiesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.companiesToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.companiesToolStripMenuItem.Name = "companiesToolStripMenuItem";
            this.companiesToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.companiesToolStripMenuItem.Text = "Companies";
            // 
            // TsmViewCompanies
            // 
            this.TsmViewCompanies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.TsmViewCompanies.ForeColor = System.Drawing.Color.Black;
            this.TsmViewCompanies.Name = "TsmViewCompanies";
            this.TsmViewCompanies.Size = new System.Drawing.Size(225, 26);
            this.TsmViewCompanies.Text = "View all companies";
            this.TsmViewCompanies.Click += new System.EventHandler(this.OnViewCompanies);
            // 
            // TsmAddCompany
            // 
            this.TsmAddCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.TsmAddCompany.ForeColor = System.Drawing.Color.Black;
            this.TsmAddCompany.Name = "TsmAddCompany";
            this.TsmAddCompany.Size = new System.Drawing.Size(225, 26);
            this.TsmAddCompany.Text = "Add company";
            this.TsmAddCompany.Click += new System.EventHandler(this.OnAddCompany);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmViewProducts,
            this.TsmAddProduct});
            this.productsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.productsToolStripMenuItem.Text = "Products";
            // 
            // TsmViewProducts
            // 
            this.TsmViewProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.TsmViewProducts.ForeColor = System.Drawing.Color.Black;
            this.TsmViewProducts.Name = "TsmViewProducts";
            this.TsmViewProducts.Size = new System.Drawing.Size(224, 26);
            this.TsmViewProducts.Text = "View all products";
            this.TsmViewProducts.Click += new System.EventHandler(this.OnViewProducts);
            // 
            // TsmAddProduct
            // 
            this.TsmAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.TsmAddProduct.ForeColor = System.Drawing.Color.Black;
            this.TsmAddProduct.Name = "TsmAddProduct";
            this.TsmAddProduct.Size = new System.Drawing.Size(224, 26);
            this.TsmAddProduct.Text = "Add Product";
            this.TsmAddProduct.Click += new System.EventHandler(this.OnAddProduct);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 347);
            this.Controls.Add(this.PnlHome);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.HomeMenu;
            this.Name = "FrmHome";
            this.Text = "Toys Store - Home";
            this.PnlHome.ResumeLayout(false);
            this.PnlHome.PerformLayout();
            this.HomeMenu.ResumeLayout(false);
            this.HomeMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlHome;
        private System.Windows.Forms.MenuStrip HomeMenu;
        private System.Windows.Forms.ToolStripMenuItem companiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TsmViewCompanies;
        private System.Windows.Forms.ToolStripMenuItem TsmAddCompany;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TsmViewProducts;
        private System.Windows.Forms.ToolStripMenuItem TsmAddProduct;
    }
}