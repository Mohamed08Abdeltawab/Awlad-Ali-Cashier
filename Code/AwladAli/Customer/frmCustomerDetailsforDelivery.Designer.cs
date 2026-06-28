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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.cbSearchWith = new System.Windows.Forms.ComboBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            this.txtPhoneNameSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // pbIcon
            // 
            this.pbIcon.Image = global::AwladAli.Properties.Resources.phone_number32;
            this.pbIcon.Location = new System.Drawing.Point(726, 107);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(31, 38);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon.TabIndex = 192;
            this.pbIcon.TabStop = false;
            // 
            // cbSearchWith
            // 
            this.cbSearchWith.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchWith.FormattingEnabled = true;
            this.cbSearchWith.Items.AddRange(new object[] {
            "رقم الهاتف",
            "الأسم"});
            this.cbSearchWith.Location = new System.Drawing.Point(575, 107);
            this.cbSearchWith.Name = "cbSearchWith";
            this.cbSearchWith.Size = new System.Drawing.Size(145, 39);
            this.cbSearchWith.TabIndex = 190;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AllowUserToResizeRows = false;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCustomers.Location = new System.Drawing.Point(13, 155);
            this.dgvCustomers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(746, 371);
            this.dgvCustomers.TabIndex = 193;
            this.dgvCustomers.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::AwladAli.Properties.Resources.close32_2;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(598, 536);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(161, 37);
            this.btnClose.TabIndex = 194;
            this.btnClose.Text = "إغلاق";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(123, 544);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(27, 20);
            this.lblRecordsCount.TabIndex = 196;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 544);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 195;
            this.label2.Text = "# Records:";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(171, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(460, 39);
            this.lblTitle.TabIndex = 197;
            this.lblTitle.Text = "إضافة عميل للطلب";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewCustomer.Image = global::AwladAli.Properties.Resources.add_32;
            this.btnAddNewCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewCustomer.Location = new System.Drawing.Point(12, 102);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(144, 45);
            this.btnAddNewCustomer.TabIndex = 243;
            this.btnAddNewCustomer.Text = "إضافة عميل جديد";
            this.btnAddNewCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewCustomer.UseVisualStyleBackColor = true;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // txtPhoneNameSearch
            // 
            this.txtPhoneNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNameSearch.Location = new System.Drawing.Point(271, 107);
            this.txtPhoneNameSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhoneNameSearch.MaxLength = 50;
            this.txtPhoneNameSearch.Name = "txtPhoneNameSearch";
            this.txtPhoneNameSearch.Size = new System.Drawing.Size(297, 38);
            this.txtPhoneNameSearch.TabIndex = 244;
            this.txtPhoneNameSearch.TextChanged += new System.EventHandler(this.txtPhoneNameSearch_TextChanged);
            this.txtPhoneNameSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNameSearch_KeyPress);
            // 
            // frmCustomerDetailsforDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 587);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
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
    }
}