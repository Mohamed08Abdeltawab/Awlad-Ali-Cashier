namespace AwladAli.Product
{
    partial class ctrlCategoryCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.pnlColumnsHeader = new System.Windows.Forms.Panel();
            this.lblHeaderSizes = new System.Windows.Forms.Label();
            this.lblHeaderProduct = new System.Windows.Forms.Label();
            this.flpItemsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.pnlColumnsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.pnlHeader.Controls.Add(this.lblCategoryName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(790, 50);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCategoryName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCategoryName.ForeColor = System.Drawing.Color.White;
            this.lblCategoryName.Image = global::AwladAli.Properties.Resources.CategoryBackground1;
            this.lblCategoryName.Location = new System.Drawing.Point(0, 0);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(790, 50);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "اسم القسم";
            this.lblCategoryName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlColumnsHeader
            // 
            this.pnlColumnsHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlColumnsHeader.Controls.Add(this.lblHeaderSizes);
            this.pnlColumnsHeader.Controls.Add(this.lblHeaderProduct);
            this.pnlColumnsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlColumnsHeader.Location = new System.Drawing.Point(0, 50);
            this.pnlColumnsHeader.Name = "pnlColumnsHeader";
            this.pnlColumnsHeader.Size = new System.Drawing.Size(790, 40);
            this.pnlColumnsHeader.TabIndex = 1;
            // 
            // lblHeaderSizes
            // 
            this.lblHeaderSizes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderSizes.Location = new System.Drawing.Point(26, 10);
            this.lblHeaderSizes.Name = "lblHeaderSizes";
            this.lblHeaderSizes.Size = new System.Drawing.Size(611, 21);
            this.lblHeaderSizes.TabIndex = 1;
            this.lblHeaderSizes.Text = "XL                L                  M              S/عادي";
            // 
            // lblHeaderProduct
            // 
            this.lblHeaderProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderProduct.Location = new System.Drawing.Point(690, 10);
            this.lblHeaderProduct.Name = "lblHeaderProduct";
            this.lblHeaderProduct.Size = new System.Drawing.Size(85, 25);
            this.lblHeaderProduct.TabIndex = 0;
            this.lblHeaderProduct.Text = "اسم الأكلة";
            // 
            // flpItemsContainer
            // 
            this.flpItemsContainer.AutoScroll = true;
            this.flpItemsContainer.BackColor = System.Drawing.Color.White;
            this.flpItemsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpItemsContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpItemsContainer.Location = new System.Drawing.Point(0, 90);
            this.flpItemsContainer.Name = "flpItemsContainer";
            this.flpItemsContainer.Size = new System.Drawing.Size(790, 492);
            this.flpItemsContainer.TabIndex = 0;
            this.flpItemsContainer.WrapContents = false;
            // 
            // ctrlCategoryCard
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flpItemsContainer);
            this.Controls.Add(this.pnlColumnsHeader);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ctrlCategoryCard";
            this.Size = new System.Drawing.Size(790, 582);
            this.pnlHeader.ResumeLayout(false);
            this.pnlColumnsHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Panel pnlColumnsHeader;
        private System.Windows.Forms.FlowLayoutPanel flpItemsContainer;
        private System.Windows.Forms.Label lblHeaderProduct;
        private System.Windows.Forms.Label lblHeaderSizes;
    }
}