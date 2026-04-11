namespace AwladAli.Category
{
    partial class frmTestControls
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
            this.ctrlCategoryCard1 = new AwladAli.Product.ctrlCategoryCard();
            this.SuspendLayout();
            // 
            // ctrlCategoryCard1
            // 
            this.ctrlCategoryCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlCategoryCard1.Location = new System.Drawing.Point(151, 26);
            this.ctrlCategoryCard1.Name = "ctrlCategoryCard1";
            this.ctrlCategoryCard1.Size = new System.Drawing.Size(800, 582);
            this.ctrlCategoryCard1.TabIndex = 0;
            // 
            // frmTestControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 636);
            this.Controls.Add(this.ctrlCategoryCard1);
            this.Name = "frmTestControls";
            this.Text = "frmTestControls";
            this.Load += new System.EventHandler(this.frmTestControls_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Product.ctrlCategoryCard ctrlCategoryCard1;
    }
}