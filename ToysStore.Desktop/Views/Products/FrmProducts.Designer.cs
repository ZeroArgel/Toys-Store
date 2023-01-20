
namespace ToysStore.Desktop.Views.Products
{
    partial class FrmProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProducts));
            this.GbxProducts = new System.Windows.Forms.GroupBox();
            this.DgvProducts = new System.Windows.Forms.DataGridView();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.GbxProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // GbxProducts
            // 
            this.GbxProducts.Controls.Add(this.DgvProducts);
            this.GbxProducts.Controls.Add(this.BtnAdd);
            this.GbxProducts.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.GbxProducts.Location = new System.Drawing.Point(12, 12);
            this.GbxProducts.Name = "GbxProducts";
            this.GbxProducts.Size = new System.Drawing.Size(736, 319);
            this.GbxProducts.TabIndex = 1;
            this.GbxProducts.TabStop = false;
            this.GbxProducts.Text = "Products";
            // 
            // DgvProducts
            // 
            this.DgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProducts.Location = new System.Drawing.Point(7, 61);
            this.DgvProducts.Name = "DgvProducts";
            this.DgvProducts.RowHeadersWidth = 51;
            this.DgvProducts.RowTemplate.Height = 29;
            this.DgvProducts.Size = new System.Drawing.Size(723, 252);
            this.DgvProducts.TabIndex = 2;
            this.DgvProducts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectProduct);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.Lime;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnAdd.Location = new System.Drawing.Point(636, 26);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(94, 29);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.OnAddProduct);
            // 
            // FrmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(757, 350);
            this.Controls.Add(this.GbxProducts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProducts";
            this.Text = "Toys Store - View Products";
            this.GbxProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxProducts;
        private System.Windows.Forms.DataGridView DgvProducts;
        private System.Windows.Forms.Button BtnAdd;
    }
}