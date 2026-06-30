namespace AwladAli.Customer
{
    partial class frmCustomerDetailsforDelivery
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbSearchWith = new System.Windows.Forms.ComboBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.cmsCustomers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SelectCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InactiveStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPhoneNameSearch = new System.Windows.Forms.TextBox();
            this.txtDeliveryFees = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDeliveryFeeStatus = new System.Windows.Forms.CheckBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlCustomerInfo1 = new AwladAli.Customer.ctrlCustomerInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.cmsCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSearchWith
            // 
            this.cbSearchWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchWith.FormattingEnabled = true;
            this.cbSearchWith.Items.AddRange(new object[] {
            "رقم الهاتف",
            "الأسم"});
            this.cbSearchWith.Location = new System.Drawing.Point(576, 62);
            this.cbSearchWith.Name = "cbSearchWith";
            this.cbSearchWith.Size = new System.Drawing.Size(145, 39);
            this.cbSearchWith.TabIndex = 190;
            this.cbSearchWith.SelectedIndexChanged += new System.EventHandler(this.cbSearchWith_SelectedIndexChanged);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AllowUserToResizeRows = false;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.ContextMenuStrip = this.cmsCustomers;
            this.dgvCustomers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCustomers.Location = new System.Drawing.Point(14, 110);
            this.dgvCustomers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(744, 211);
            this.dgvCustomers.TabIndex = 193;
            this.dgvCustomers.TabStop = false;
            this.dgvCustomers.DoubleClick += new System.EventHandler(this.dgvCustomers_DoubleClick);
            // 
            // cmsCustomers
            // 
            this.cmsCustomers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectCustomerToolStripMenuItem,
            this.editToolStripMenuItem,
            this.InactiveStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.cmsCustomers.Name = "contextMenuStrip1";
            this.cmsCustomers.Size = new System.Drawing.Size(179, 156);
            this.cmsCustomers.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCustomers_Opening);
            // 
            // SelectCustomerToolStripMenuItem
            // 
            this.SelectCustomerToolStripMenuItem.Image = global::AwladAli.Properties.Resources.select32;
            this.SelectCustomerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SelectCustomerToolStripMenuItem.Name = "SelectCustomerToolStripMenuItem";
            this.SelectCustomerToolStripMenuItem.Size = new System.Drawing.Size(178, 38);
            this.SelectCustomerToolStripMenuItem.Text = "تأكيد إختيار العميل";
            this.SelectCustomerToolStripMenuItem.Click += new System.EventHandler(this.SelectCustomerToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::AwladAli.Properties.Resources.edit2_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(178, 38);
            this.editToolStripMenuItem.Text = "تعديل";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // InactiveStripMenuItem1
            // 
            this.InactiveStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OnToolStripMenuItem,
            this.OffToolStripMenuItem});
            this.InactiveStripMenuItem1.Image = global::AwladAli.Properties.Resources.Activation_32;
            this.InactiveStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InactiveStripMenuItem1.Name = "InactiveStripMenuItem1";
            this.InactiveStripMenuItem1.Size = new System.Drawing.Size(178, 38);
            this.InactiveStripMenuItem1.Text = "الحالة";
            // 
            // OnToolStripMenuItem
            // 
            this.OnToolStripMenuItem.Image = global::AwladAli.Properties.Resources.Active_32;
            this.OnToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.OnToolStripMenuItem.Name = "OnToolStripMenuItem";
            this.OnToolStripMenuItem.Size = new System.Drawing.Size(186, 38);
            this.OnToolStripMenuItem.Text = "(ON) تنشيط";
            this.OnToolStripMenuItem.Click += new System.EventHandler(this.OnToolStripMenuItem_Click);
            // 
            // OffToolStripMenuItem
            // 
            this.OffToolStripMenuItem.Image = global::AwladAli.Properties.Resources.Inactive_32;
            this.OffToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.OffToolStripMenuItem.Name = "OffToolStripMenuItem";
            this.OffToolStripMenuItem.Size = new System.Drawing.Size(186, 38);
            this.OffToolStripMenuItem.Text = "(OFF) الغاء التنشيط";
            this.OffToolStripMenuItem.Click += new System.EventHandler(this.OffToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::AwladAli.Properties.Resources.remove_32;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(178, 38);
            this.deleteToolStripMenuItem.Text = "حذف";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(114, 326);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(27, 20);
            this.lblRecordsCount.TabIndex = 196;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 195;
            this.label2.Text = "# Records:";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(169, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(460, 39);
            this.lblTitle.TabIndex = 197;
            this.lblTitle.Text = "إضافة عميل للطلب";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPhoneNameSearch
            // 
            this.txtPhoneNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNameSearch.Location = new System.Drawing.Point(272, 62);
            this.txtPhoneNameSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhoneNameSearch.MaxLength = 50;
            this.txtPhoneNameSearch.Name = "txtPhoneNameSearch";
            this.txtPhoneNameSearch.Size = new System.Drawing.Size(297, 38);
            this.txtPhoneNameSearch.TabIndex = 244;
            this.txtPhoneNameSearch.TextChanged += new System.EventHandler(this.txtPhoneNameSearch_TextChanged);
            this.txtPhoneNameSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNameSearch_KeyPress);
            // 
            // txtDeliveryFees
            // 
            this.txtDeliveryFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryFees.Enabled = false;
            this.txtDeliveryFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeliveryFees.Location = new System.Drawing.Point(370, 750);
            this.txtDeliveryFees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDeliveryFees.MaxLength = 50;
            this.txtDeliveryFees.Name = "txtDeliveryFees";
            this.txtDeliveryFees.Size = new System.Drawing.Size(219, 31);
            this.txtDeliveryFees.TabIndex = 247;
            this.txtDeliveryFees.Text = "0";
            this.txtDeliveryFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeliveryFees_KeyPress);
            this.txtDeliveryFees.Validating += new System.ComponentModel.CancelEventHandler(this.txtDeliveryFees_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(634, 757);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 248;
            this.label1.Text = ":مصاريف التوصيل";
            // 
            // chkDeliveryFeeStatus
            // 
            this.chkDeliveryFeeStatus.AutoSize = true;
            this.chkDeliveryFeeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeliveryFeeStatus.Location = new System.Drawing.Point(553, 710);
            this.chkDeliveryFeeStatus.Name = "chkDeliveryFeeStatus";
            this.chkDeliveryFeeStatus.Size = new System.Drawing.Size(206, 29);
            this.chkDeliveryFeeStatus.TabIndex = 250;
            this.chkDeliveryFeeStatus.Text = "إضافة مضاريف للتوصيل";
            this.chkDeliveryFeeStatus.UseVisualStyleBackColor = true;
            this.chkDeliveryFeeStatus.CheckedChanged += new System.EventHandler(this.chkDeliveryFeeStatus_CheckedChanged);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::AwladAli.Properties.Resources.money2_32;
            this.pictureBox8.Location = new System.Drawing.Point(596, 750);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 31);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 249;
            this.pictureBox8.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = global::AwladAli.Properties.Resources.save32_2;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(16, 797);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 37);
            this.btnSave.TabIndex = 245;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewCustomer.Image = global::AwladAli.Properties.Resources.add_32;
            this.btnAddNewCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewCustomer.Location = new System.Drawing.Point(13, 57);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(144, 45);
            this.btnAddNewCustomer.TabIndex = 243;
            this.btnAddNewCustomer.Text = "إضافة عميل جديد";
            this.btnAddNewCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewCustomer.UseVisualStyleBackColor = true;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::AwladAli.Properties.Resources.close32_2;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(200, 797);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(161, 37);
            this.btnClose.TabIndex = 194;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbIcon
            // 
            this.pbIcon.Image = global::AwladAli.Properties.Resources.phone_number32;
            this.pbIcon.Location = new System.Drawing.Point(727, 62);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(31, 38);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon.TabIndex = 192;
            this.pbIcon.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlCustomerInfo1
            // 
            this.ctrlCustomerInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlCustomerInfo1.Location = new System.Drawing.Point(13, 351);
            this.ctrlCustomerInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlCustomerInfo1.Name = "ctrlCustomerInfo1";
            this.ctrlCustomerInfo1.Size = new System.Drawing.Size(752, 351);
            this.ctrlCustomerInfo1.TabIndex = 246;
            // 
            // frmCustomerDetailsforDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(779, 850);
            this.Controls.Add(this.chkDeliveryFeeStatus);
            this.Controls.Add(this.txtDeliveryFees);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.ctrlCustomerInfo1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPhoneNameSearch);
            this.Controls.Add(this.btnAddNewCustomer);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.cbSearchWith);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCustomerDetailsforDelivery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCustomerDetailsforDelivery";
            this.Load += new System.EventHandler(this.frmCustomerDetailsforDelivery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.cmsCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.ComboBox cbSearchWith;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddNewCustomer;
        private System.Windows.Forms.TextBox txtPhoneNameSearch;
        private System.Windows.Forms.Button btnSave;
        private ctrlCustomerInfo ctrlCustomerInfo1;
        private System.Windows.Forms.TextBox txtDeliveryFees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.CheckBox chkDeliveryFeeStatus;
        private System.Windows.Forms.ContextMenuStrip cmsCustomers;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InactiveStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectCustomerToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}