namespace AwladAli.Bill
{
    partial class frmOrderInfo
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlBillHeader = new System.Windows.Forms.Panel();
            this.lblBillTitle = new System.Windows.Forms.Label();
            this.pnlOrderItemsHeader = new System.Windows.Forms.Panel();
            this.lblH_Total = new System.Windows.Forms.Label();
            this.lblH_Qty = new System.Windows.Forms.Label();
            this.lblH_Price = new System.Windows.Forms.Label();
            this.lblH_Name = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.flpOrderItems = new System.Windows.Forms.FlowLayoutPanel();
            this.ctrlOrderLine1 = new AwladAli.Bill.ctrlOrderLine();
            this.pnlBillFooter = new System.Windows.Forms.Panel();
            this.btnSaveAndPrint = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.labelTotalText = new System.Windows.Forms.Label();
            this.pnlBillHeader.SuspendLayout();
            this.pnlOrderItemsHeader.SuspendLayout();
            this.flpOrderItems.SuspendLayout();
            this.pnlBillFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBillHeader
            // 
            this.pnlBillHeader.BackColor = System.Drawing.Color.White;
            this.pnlBillHeader.Controls.Add(this.lblBillTitle);
            this.pnlBillHeader.Controls.Add(this.pnlOrderItemsHeader);
            this.pnlBillHeader.Controls.Add(this.lblOrderDate);
            this.pnlBillHeader.Controls.Add(this.lblOrderID);
            this.pnlBillHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBillHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlBillHeader.Name = "pnlBillHeader";
            this.pnlBillHeader.Size = new System.Drawing.Size(450, 159);
            this.pnlBillHeader.TabIndex = 0;
            // 
            // lblBillTitle
            // 
            this.lblBillTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBillTitle.Location = new System.Drawing.Point(0, 9);
            this.lblBillTitle.Name = "lblBillTitle";
            this.lblBillTitle.Size = new System.Drawing.Size(450, 40);
            this.lblBillTitle.TabIndex = 0;
            this.lblBillTitle.Text = "Awlad Ali - أولاد علي";
            this.lblBillTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOrderItemsHeader
            // 
            this.pnlOrderItemsHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlOrderItemsHeader.BackColor = System.Drawing.Color.LightGray;
            this.pnlOrderItemsHeader.Controls.Add(this.lblH_Total);
            this.pnlOrderItemsHeader.Controls.Add(this.lblH_Qty);
            this.pnlOrderItemsHeader.Controls.Add(this.lblH_Price);
            this.pnlOrderItemsHeader.Controls.Add(this.lblH_Name);
            this.pnlOrderItemsHeader.Location = new System.Drawing.Point(0, 124);
            this.pnlOrderItemsHeader.Name = "pnlOrderItemsHeader";
            this.pnlOrderItemsHeader.Size = new System.Drawing.Size(450, 35);
            this.pnlOrderItemsHeader.TabIndex = 3;
            // 
            // lblH_Total
            // 
            this.lblH_Total.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblH_Total.Location = new System.Drawing.Point(16, 5);
            this.lblH_Total.Name = "lblH_Total";
            this.lblH_Total.Size = new System.Drawing.Size(107, 25);
            this.lblH_Total.TabIndex = 0;
            this.lblH_Total.Text = "الإجمالي بالجنية";
            this.lblH_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblH_Qty
            // 
            this.lblH_Qty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblH_Qty.Location = new System.Drawing.Point(131, 5);
            this.lblH_Qty.Name = "lblH_Qty";
            this.lblH_Qty.Size = new System.Drawing.Size(68, 25);
            this.lblH_Qty.TabIndex = 1;
            this.lblH_Qty.Text = "الكمية";
            this.lblH_Qty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblH_Price
            // 
            this.lblH_Price.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblH_Price.Location = new System.Drawing.Point(215, 5);
            this.lblH_Price.Name = "lblH_Price";
            this.lblH_Price.Size = new System.Drawing.Size(102, 25);
            this.lblH_Price.TabIndex = 2;
            this.lblH_Price.Text = "السعر بالجنية";
            this.lblH_Price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblH_Name
            // 
            this.lblH_Name.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblH_Name.Location = new System.Drawing.Point(311, 5);
            this.lblH_Name.Name = "lblH_Name";
            this.lblH_Name.Size = new System.Drawing.Size(127, 25);
            this.lblH_Name.TabIndex = 3;
            this.lblH_Name.Text = "اسم المنتج";
            this.lblH_Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOrderDate.Location = new System.Drawing.Point(12, 85);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(200, 23);
            this.lblOrderDate.TabIndex = 2;
            this.lblOrderDate.Text = "التاريخ: 2026-04-14";
            this.lblOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderID
            // 
            this.lblOrderID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrderID.Location = new System.Drawing.Point(238, 85);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(200, 23);
            this.lblOrderID.TabIndex = 1;
            this.lblOrderID.Text = "رقم الفاتورة: #000000";
            this.lblOrderID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flpOrderItems
            // 
            this.flpOrderItems.AutoScroll = true;
            this.flpOrderItems.BackColor = System.Drawing.Color.White;
            this.flpOrderItems.Controls.Add(this.ctrlOrderLine1);
            this.flpOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpOrderItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpOrderItems.Location = new System.Drawing.Point(0, 159);
            this.flpOrderItems.Name = "flpOrderItems";
            this.flpOrderItems.Padding = new System.Windows.Forms.Padding(10);
            this.flpOrderItems.Size = new System.Drawing.Size(450, 457);
            this.flpOrderItems.TabIndex = 1;
            this.flpOrderItems.WrapContents = false;
            // 
            // ctrlOrderLine1
            // 
            this.ctrlOrderLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlOrderLine1.Location = new System.Drawing.Point(14, 15);
            this.ctrlOrderLine1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlOrderLine1.Name = "ctrlOrderLine1";
            this.ctrlOrderLine1.Size = new System.Drawing.Size(424, 39);
            this.ctrlOrderLine1.TabIndex = 0;
            // 
            // pnlBillFooter
            // 
            this.pnlBillFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBillFooter.Controls.Add(this.btnSaveAndPrint);
            this.pnlBillFooter.Controls.Add(this.lblTotalAmount);
            this.pnlBillFooter.Controls.Add(this.labelTotalText);
            this.pnlBillFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBillFooter.Location = new System.Drawing.Point(0, 616);
            this.pnlBillFooter.Name = "pnlBillFooter";
            this.pnlBillFooter.Size = new System.Drawing.Size(450, 130);
            this.pnlBillFooter.TabIndex = 2;
            // 
            // btnSaveAndPrint
            // 
            this.btnSaveAndPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSaveAndPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndPrint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSaveAndPrint.ForeColor = System.Drawing.Color.White;
            this.btnSaveAndPrint.Location = new System.Drawing.Point(117, 70);
            this.btnSaveAndPrint.Name = "btnSaveAndPrint";
            this.btnSaveAndPrint.Size = new System.Drawing.Size(200, 45);
            this.btnSaveAndPrint.TabIndex = 2;
            this.btnSaveAndPrint.Text = "حفظ وطباعة";
            this.btnSaveAndPrint.UseVisualStyleBackColor = false;
            this.btnSaveAndPrint.Click += new System.EventHandler(this.btnSaveAndPrint_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalAmount.Location = new System.Drawing.Point(12, 15);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(150, 37);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTotalText
            // 
            this.labelTotalText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTotalText.Location = new System.Drawing.Point(288, 15);
            this.labelTotalText.Name = "labelTotalText";
            this.labelTotalText.Size = new System.Drawing.Size(150, 37);
            this.labelTotalText.TabIndex = 0;
            this.labelTotalText.Text = "الإجمالي النهائي:";
            this.labelTotalText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmOrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 746);
            this.Controls.Add(this.flpOrderItems);
            this.Controls.Add(this.pnlBillHeader);
            this.Controls.Add(this.pnlBillFooter);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOrderInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "معاينة الفاتورة";
            this.Load += new System.EventHandler(this.frmOrderInfo_Load);
            this.pnlBillHeader.ResumeLayout(false);
            this.pnlOrderItemsHeader.ResumeLayout(false);
            this.flpOrderItems.ResumeLayout(false);
            this.pnlBillFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBillHeader;
        private System.Windows.Forms.Label lblBillTitle;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.FlowLayoutPanel flpOrderItems;
        private System.Windows.Forms.Panel pnlBillFooter;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label labelTotalText;
        private System.Windows.Forms.Button btnSaveAndPrint;

        private System.Windows.Forms.Panel pnlOrderItemsHeader;
        private System.Windows.Forms.Label lblH_Total;
        private System.Windows.Forms.Label lblH_Price;
        private System.Windows.Forms.Label lblH_Qty;
        private System.Windows.Forms.Label lblH_Name;
        private ctrlOrderLine ctrlOrderLine1;
    }
}