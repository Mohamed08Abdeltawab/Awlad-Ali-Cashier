namespace AwladAli.Category.Extra
{
    partial class frmtestControls
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
            this.ctrlExtraRow1 = new AwladAli.Category.Extra.ctrlExtraRow();
            this.SuspendLayout();
            // 
            // ctrlExtraRow1
            // 
            this.ctrlExtraRow1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlExtraRow1.ExtraName = "منتج تجريبي";
            this.ctrlExtraRow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlExtraRow1.Location = new System.Drawing.Point(300, 108);
            this.ctrlExtraRow1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlExtraRow1.Name = "ctrlExtraRow1";
            this.ctrlExtraRow1.Size = new System.Drawing.Size(250, 38);
            this.ctrlExtraRow1.TabIndex = 0;
            // 
            // frmtestControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ctrlExtraRow1);
            this.Name = "frmtestControls";
            this.Text = "frmtestControls";
            this.Load += new System.EventHandler(this.frmtestControls_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlExtraRow ctrlExtraRow1;
    }
}