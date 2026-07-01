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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderInfo));
            this.pnlBillHeader = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBillTitle = new System.Windows.Forms.Label();
            this.pnlOrderItemsHeader = new System.Windows.Forms.Panel();
            this.lblH_Total = new System.Windows.Forms.Label();
            this.lblH_Qty = new System.Windows.Forms.Label();
            this.lblH_Price = new System.Windows.Forms.Label();
            this.lblH_Name = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.flpOrderItems = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBillFooter = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbIcon1 = new System.Windows.Forms.PictureBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbIconStatus = new System.Windows.Forms.PictureBox();
            this.lblTitleStatus = new System.Windows.Forms.Label();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnSaveAndPrint = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.labelTotalText = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDeliveryFee = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMealPrice = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ctrlOrderLine1 = new AwladAli.Bill.ctrlOrderLine();
            this.pnlBillHeader.SuspendLayout();
            this.pnlOrderItemsHeader.SuspendLayout();
            this.flpOrderItems.SuspendLayout();
            this.pnlBillFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBillHeader
            // 
            this.pnlBillHeader.BackColor = System.Drawing.Color.White;
            this.pnlBillHeader.Controls.Add(this.label4);
            this.pnlBillHeader.Controls.Add(this.label1);
            this.pnlBillHeader.Controls.Add(this.lblBillTitle);
            this.pnlBillHeader.Controls.Add(this.pnlOrderItemsHeader);
            this.pnlBillHeader.Controls.Add(this.lblOrderDate);
            this.pnlBillHeader.Controls.Add(this.lblOrderID);
            this.pnlBillHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBillHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlBillHeader.Name = "pnlBillHeader";
            this.pnlBillHeader.Size = new System.Drawing.Size(457, 159);
            this.pnlBillHeader.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(187, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = ":التاريخ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(355, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = ":رقم الفاتورة";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.pnlOrderItemsHeader.Location = new System.Drawing.Point(3, 124);
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
            this.lblOrderDate.Size = new System.Drawing.Size(169, 23);
            this.lblOrderDate.TabIndex = 2;
            this.lblOrderDate.Text = "2026-04-14";
            this.lblOrderDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderID
            // 
            this.lblOrderID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrderID.Location = new System.Drawing.Point(259, 85);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(90, 23);
            this.lblOrderID.TabIndex = 1;
            this.lblOrderID.Text = "#000000";
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
            this.flpOrderItems.Size = new System.Drawing.Size(457, 343);
            this.flpOrderItems.TabIndex = 1;
            this.flpOrderItems.WrapContents = false;
            // 
            // pnlBillFooter
            // 
            this.pnlBillFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBillFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBillFooter.Controls.Add(this.label10);
            this.pnlBillFooter.Controls.Add(this.label9);
            this.pnlBillFooter.Controls.Add(this.label6);
            this.pnlBillFooter.Controls.Add(this.label5);
            this.pnlBillFooter.Controls.Add(this.lblDeliveryFee);
            this.pnlBillFooter.Controls.Add(this.label7);
            this.pnlBillFooter.Controls.Add(this.lblMealPrice);
            this.pnlBillFooter.Controls.Add(this.label8);
            this.pnlBillFooter.Controls.Add(this.pictureBox1);
            this.pnlBillFooter.Controls.Add(this.pbIcon1);
            this.pnlBillFooter.Controls.Add(this.lblPhoneNumber);
            this.pnlBillFooter.Controls.Add(this.lblCustomerName);
            this.pnlBillFooter.Controls.Add(this.label3);
            this.pnlBillFooter.Controls.Add(this.label2);
            this.pnlBillFooter.Controls.Add(this.pbIconStatus);
            this.pnlBillFooter.Controls.Add(this.lblTitleStatus);
            this.pnlBillFooter.Controls.Add(this.btnIgnore);
            this.pnlBillFooter.Controls.Add(this.btnSaveAndPrint);
            this.pnlBillFooter.Controls.Add(this.lblTotalAmount);
            this.pnlBillFooter.Controls.Add(this.labelTotalText);
            this.pnlBillFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBillFooter.Location = new System.Drawing.Point(0, 502);
            this.pnlBillFooter.Name = "pnlBillFooter";
            this.pnlBillFooter.Size = new System.Drawing.Size(457, 323);
            this.pnlBillFooter.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AwladAli.Properties.Resources.person32_2;
            this.pictureBox1.Location = new System.Drawing.Point(328, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 194;
            this.pictureBox1.TabStop = false;
            // 
            // pbIcon1
            // 
            this.pbIcon1.Image = global::AwladAli.Properties.Resources.phone_number32;
            this.pbIcon1.Location = new System.Drawing.Point(328, 92);
            this.pbIcon1.Name = "pbIcon1";
            this.pbIcon1.Size = new System.Drawing.Size(31, 23);
            this.pbIcon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon1.TabIndex = 193;
            this.pbIcon1.TabStop = false;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhoneNumber.Location = new System.Drawing.Point(71, 92);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(249, 23);
            this.lblPhoneNumber.TabIndex = 186;
            this.lblPhoneNumber.Text = "N/A";
            this.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.Location = new System.Drawing.Point(67, 53);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(253, 23);
            this.lblCustomerName.TabIndex = 185;
            this.lblCustomerName.Text = "N/A";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(359, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 184;
            this.label3.Text = ":رقم العميل";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(359, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 183;
            this.label2.Text = ":أسم العميل";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbIconStatus
            // 
            this.pbIconStatus.Image = global::AwladAli.Properties.Resources.takeaway32;
            this.pbIconStatus.Location = new System.Drawing.Point(96, 7);
            this.pbIconStatus.Name = "pbIconStatus";
            this.pbIconStatus.Size = new System.Drawing.Size(31, 26);
            this.pbIconStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIconStatus.TabIndex = 182;
            this.pbIconStatus.TabStop = false;
            // 
            // lblTitleStatus
            // 
            this.lblTitleStatus.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleStatus.Location = new System.Drawing.Point(133, 3);
            this.lblTitleStatus.Name = "lblTitleStatus";
            this.lblTitleStatus.Size = new System.Drawing.Size(245, 37);
            this.lblTitleStatus.TabIndex = 4;
            this.lblTitleStatus.Text = "(Takeaway) إستلام من المحل";
            this.lblTitleStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnIgnore
            // 
            this.btnIgnore.BackColor = System.Drawing.Color.Red;
            this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIgnore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnIgnore.ForeColor = System.Drawing.Color.White;
            this.btnIgnore.Location = new System.Drawing.Point(287, 265);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(115, 51);
            this.btnIgnore.TabIndex = 3;
            this.btnIgnore.Text = "حذف والغاء";
            this.btnIgnore.UseVisualStyleBackColor = false;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // btnSaveAndPrint
            // 
            this.btnSaveAndPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSaveAndPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndPrint.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndPrint.ForeColor = System.Drawing.Color.White;
            this.btnSaveAndPrint.Location = new System.Drawing.Point(45, 265);
            this.btnSaveAndPrint.Name = "btnSaveAndPrint";
            this.btnSaveAndPrint.Size = new System.Drawing.Size(225, 51);
            this.btnSaveAndPrint.TabIndex = 2;
            this.btnSaveAndPrint.Text = "حفظ وطباعة";
            this.btnSaveAndPrint.UseVisualStyleBackColor = false;
            this.btnSaveAndPrint.Click += new System.EventHandler(this.btnSaveAndPrint_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalAmount.Location = new System.Drawing.Point(60, 213);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(150, 37);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTotalText
            // 
            this.labelTotalText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTotalText.Location = new System.Drawing.Point(291, 213);
            this.labelTotalText.Name = "labelTotalText";
            this.labelTotalText.Size = new System.Drawing.Size(150, 37);
            this.labelTotalText.TabIndex = 0;
            this.labelTotalText.Text = ":الإجمالي النهائي";
            this.labelTotalText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(-57, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 25);
            this.label5.TabIndex = 199;
            this.label5.Text = "جُنية";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeliveryFee
            // 
            this.lblDeliveryFee.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDeliveryFee.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblDeliveryFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDeliveryFee.Location = new System.Drawing.Point(212, 175);
            this.lblDeliveryFee.Name = "lblDeliveryFee";
            this.lblDeliveryFee.Size = new System.Drawing.Size(96, 25);
            this.lblDeliveryFee.TabIndex = 198;
            this.lblDeliveryFee.Text = "0.00";
            this.lblDeliveryFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(317, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 26);
            this.label7.TabIndex = 197;
            this.label7.Text = ":سعر التوصيل";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMealPrice
            // 
            this.lblMealPrice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMealPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMealPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblMealPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMealPrice.Location = new System.Drawing.Point(212, 136);
            this.lblMealPrice.Name = "lblMealPrice";
            this.lblMealPrice.Size = new System.Drawing.Size(102, 27);
            this.lblMealPrice.TabIndex = 196;
            this.lblMealPrice.Text = "0.00";
            this.lblMealPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(334, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 28);
            this.label8.TabIndex = 195;
            this.label8.Text = ":سعر الوجبة";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(160, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 27);
            this.label6.TabIndex = 200;
            this.label6.Text = "ج.م";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(160, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 27);
            this.label9.TabIndex = 201;
            this.label9.Text = "ج.م";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(3, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 37);
            this.label10.TabIndex = 202;
            this.label10.Text = "ج.م";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlOrderLine1
            // 
            this.ctrlOrderLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlOrderLine1.Location = new System.Drawing.Point(14, 15);
            this.ctrlOrderLine1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlOrderLine1.Name = "ctrlOrderLine1";
            this.ctrlOrderLine1.Size = new System.Drawing.Size(436, 39);
            this.ctrlOrderLine1.TabIndex = 0;
            // 
            // frmOrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(457, 825);
            this.Controls.Add(this.flpOrderItems);
            this.Controls.Add(this.pnlBillHeader);
            this.Controls.Add(this.pnlBillFooter);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOrderInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "معاينة الفاتورة";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrderInfo_FormClosing);
            this.Load += new System.EventHandler(this.frmOrderInfo_Load);
            this.pnlBillHeader.ResumeLayout(false);
            this.pnlOrderItemsHeader.ResumeLayout(false);
            this.flpOrderItems.ResumeLayout(false);
            this.pnlBillFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconStatus)).EndInit();
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
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Label lblTitleStatus;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbIconStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbIcon1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDeliveryFee;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMealPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}