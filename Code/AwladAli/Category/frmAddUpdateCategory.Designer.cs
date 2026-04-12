namespace AwladAli.Category
{
    partial class frmAddUpdateCategory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCategoryID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.cmsProduct = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditMedicinetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeMedicineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewProduct = new System.Windows.Forms.Button();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbShowAllCategoryName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.cmsProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCategoryID
            // 
            this.lblCategoryID.AutoSize = true;
            this.lblCategoryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoryID.Location = new System.Drawing.Point(205, 120);
            this.lblCategoryID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategoryID.Name = "lblCategoryID";
            this.lblCategoryID.Size = new System.Drawing.Size(65, 25);
            this.lblCategoryID.TabIndex = 248;
            this.lblCategoryID.Text = "[???]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 120);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 25);
            this.label8.TabIndex = 246;
            this.label8.Text = "Category ID:";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryName.Location = new System.Drawing.Point(458, 114);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(215, 31);
            this.txtCategoryName.TabIndex = 251;
            this.txtCategoryName.Validating += new System.ComponentModel.CancelEventHandler(this.txtCategoryName_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(726, 116);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 25);
            this.label10.TabIndex = 249;
            this.label10.Text = ":اسم الصنف";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(235, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(397, 39);
            this.lblTitle.TabIndex = 252;
            this.lblTitle.Text = "اضافة صنف جديد";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.AllowUserToDeleteRows = false;
            this.dgvProduct.AllowUserToResizeRows = false;
            this.dgvProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.ContextMenuStrip = this.cmsProduct;
            this.dgvProduct.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProduct.Location = new System.Drawing.Point(13, 222);
            this.dgvProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvProduct.MultiSelect = false;
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduct.Size = new System.Drawing.Size(827, 258);
            this.dgvProduct.TabIndex = 254;
            this.dgvProduct.TabStop = false;
            // 
            // cmsProduct
            // 
            this.cmsProduct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditMedicinetoolStripMenuItem,
            this.removeMedicineToolStripMenuItem});
            this.cmsProduct.Name = "contextMenuStrip1";
            this.cmsProduct.Size = new System.Drawing.Size(186, 80);
            // 
            // EditMedicinetoolStripMenuItem
            // 
            this.EditMedicinetoolStripMenuItem.Image = global::AwladAli.Properties.Resources.edit2_32;
            this.EditMedicinetoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditMedicinetoolStripMenuItem.Name = "EditMedicinetoolStripMenuItem";
            this.EditMedicinetoolStripMenuItem.Size = new System.Drawing.Size(185, 38);
            this.EditMedicinetoolStripMenuItem.Text = "Edit Medicine";
            this.EditMedicinetoolStripMenuItem.Click += new System.EventHandler(this.EditMedicinetoolStripMenuItem_Click_1);
            // 
            // removeMedicineToolStripMenuItem
            // 
            this.removeMedicineToolStripMenuItem.Image = global::AwladAli.Properties.Resources.remove_32;
            this.removeMedicineToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.removeMedicineToolStripMenuItem.Name = "removeMedicineToolStripMenuItem";
            this.removeMedicineToolStripMenuItem.Size = new System.Drawing.Size(185, 38);
            this.removeMedicineToolStripMenuItem.Text = "Remove Medicine";
            this.removeMedicineToolStripMenuItem.Click += new System.EventHandler(this.removeMedicineToolStripMenuItem_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = global::AwladAli.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(76, 522);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 37);
            this.btnSave.TabIndex = 255;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::AwladAli.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(210, 522);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 256;
            this.btnClose.Text = "ألغاء";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewProduct
            // 
            this.btnAddNewProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewProduct.Image = global::AwladAli.Properties.Resources.add_32;
            this.btnAddNewProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewProduct.Location = new System.Drawing.Point(13, 174);
            this.btnAddNewProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewProduct.Name = "btnAddNewProduct";
            this.btnAddNewProduct.Size = new System.Drawing.Size(204, 38);
            this.btnAddNewProduct.TabIndex = 253;
            this.btnAddNewProduct.Text = "اضافة اكلة جديده";
            this.btnAddNewProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewProduct.UseVisualStyleBackColor = true;
            this.btnAddNewProduct.Click += new System.EventHandler(this.btnAddNewProduct_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::AwladAli.Properties.Resources.Category_32;
            this.pictureBox9.Location = new System.Drawing.Point(688, 114);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(31, 31);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 250;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::AwladAli.Properties.Resources.Number_32;
            this.pictureBox6.Location = new System.Drawing.Point(152, 120);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(31, 31);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 247;
            this.pictureBox6.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbShowAllCategoryName
            // 
            this.cbShowAllCategoryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShowAllCategoryName.FormattingEnabled = true;
            this.cbShowAllCategoryName.Location = new System.Drawing.Point(618, 186);
            this.cbShowAllCategoryName.Name = "cbShowAllCategoryName";
            this.cbShowAllCategoryName.Size = new System.Drawing.Size(217, 28);
            this.cbShowAllCategoryName.TabIndex = 257;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(715, 163);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 258;
            this.label1.Text = "عرض كل الاصناف";
            // 
            // frmAddUpdateCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(851, 573);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbShowAllCategoryName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.btnAddNewProduct);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblCategoryID);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddUpdateCategory";
            this.Text = "frmAddUpdateCategory";
            this.Load += new System.EventHandler(this.frmAddUpdateCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.cmsProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategoryID;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnAddNewProduct;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsProduct;
        private System.Windows.Forms.ToolStripMenuItem EditMedicinetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeMedicineToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbShowAllCategoryName;
    }
}