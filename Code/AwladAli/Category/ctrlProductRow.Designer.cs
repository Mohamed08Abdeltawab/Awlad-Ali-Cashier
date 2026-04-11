namespace AwladAli.Product
{
    partial class ctrlProductRow
    {
        private void InitializeComponent()
        {
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblPriceS = new System.Windows.Forms.Label();
            this.lblPriceM = new System.Windows.Forms.Label();
            this.lblPriceL = new System.Windows.Forms.Label();
            this.lblPriceXL = new System.Windows.Forms.Label();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.Location = new System.Drawing.Point(362, 8);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(130, 25);
            this.lblProductName.TabIndex = 6;
            this.lblProductName.Text = "منتج تجريبي";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPriceS
            // 
            this.lblPriceS.Location = new System.Drawing.Point(305, 10);
            this.lblPriceS.Name = "lblPriceS";
            this.lblPriceS.Size = new System.Drawing.Size(40, 21);
            this.lblPriceS.TabIndex = 5;
            this.lblPriceS.Text = "00";
            // 
            // lblPriceM
            // 
            this.lblPriceM.Location = new System.Drawing.Point(245, 10);
            this.lblPriceM.Name = "lblPriceM";
            this.lblPriceM.Size = new System.Drawing.Size(40, 21);
            this.lblPriceM.TabIndex = 4;
            this.lblPriceM.Text = "00";
            // 
            // lblPriceL
            // 
            this.lblPriceL.Location = new System.Drawing.Point(185, 10);
            this.lblPriceL.Name = "lblPriceL";
            this.lblPriceL.Size = new System.Drawing.Size(40, 21);
            this.lblPriceL.TabIndex = 3;
            this.lblPriceL.Text = "00";
            // 
            // lblPriceXL
            // 
            this.lblPriceXL.Location = new System.Drawing.Point(130, 10);
            this.lblPriceXL.Name = "lblPriceXL";
            this.lblPriceXL.Size = new System.Drawing.Size(40, 21);
            this.lblPriceXL.TabIndex = 2;
            this.lblPriceXL.Text = "00";
            // 
            // chkSelect
            // 
            this.chkSelect.Location = new System.Drawing.Point(85, 12);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(20, 20);
            this.chkSelect.TabIndex = 1;
            // 
            // numQuantity
            // 
            this.numQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.numQuantity.Location = new System.Drawing.Point(8, 9);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(50, 20);
            this.numQuantity.TabIndex = 0;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ctrlProductRow
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.chkSelect);
            this.Controls.Add(this.lblPriceXL);
            this.Controls.Add(this.lblPriceL);
            this.Controls.Add(this.lblPriceM);
            this.Controls.Add(this.lblPriceS);
            this.Controls.Add(this.lblProductName);
            this.Name = "ctrlProductRow";
            this.Size = new System.Drawing.Size(500, 40);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblPriceS;
        private System.Windows.Forms.Label lblPriceM;
        private System.Windows.Forms.Label lblPriceL;
        private System.Windows.Forms.Label lblPriceXL;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.NumericUpDown numQuantity;
    }
}