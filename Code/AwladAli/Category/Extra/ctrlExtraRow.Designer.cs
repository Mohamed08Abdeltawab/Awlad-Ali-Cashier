namespace AwladAli.Category.Extra
{
    partial class ctrlExtraRow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.chkSelectPrice = new System.Windows.Forms.CheckBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numQuantity
            // 
            this.numQuantity.BackColor = System.Drawing.SystemColors.Window;
            this.numQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantity.Location = new System.Drawing.Point(3, 3);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.ReadOnly = true;
            this.numQuantity.Size = new System.Drawing.Size(50, 26);
            this.numQuantity.TabIndex = 7;
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            // 
            // chkSelectPrice
            // 
            this.chkSelectPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectPrice.Location = new System.Drawing.Point(59, 8);
            this.chkSelectPrice.Name = "chkSelectPrice";
            this.chkSelectPrice.Size = new System.Drawing.Size(63, 20);
            this.chkSelectPrice.TabIndex = 8;
            this.chkSelectPrice.Text = "--";
            this.chkSelectPrice.CheckedChanged += new System.EventHandler(this.chkSelectPrice_CheckedChanged);
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(112, 3);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(127, 25);
            this.lblProductName.TabIndex = 9;
            this.lblProductName.Text = "منتج تجريبي";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblProductName);
            this.panel1.Controls.Add(this.numQuantity);
            this.panel1.Controls.Add(this.chkSelectPrice);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 32);
            this.panel1.TabIndex = 10;
            // 
            // ctrlExtraRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlExtraRow";
            this.Size = new System.Drawing.Size(250, 38);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.CheckBox chkSelectPrice;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Panel panel1;
    }
}
