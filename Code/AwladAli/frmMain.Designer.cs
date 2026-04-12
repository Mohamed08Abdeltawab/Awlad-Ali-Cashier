using System.Drawing;
using System.Windows.Forms;

namespace AwladAli
{
    partial class frmMain
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.flpProductCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            this.pnlMainContainer.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlHeader.Controls.Add(this.pictureBox8);
            this.pnlHeader.Controls.Add(this.lblUsername);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1924, 80);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(809, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(274, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "نظام كاشير - أولاد علي";
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.Controls.Add(this.flpProductCards);
            this.pnlMainContainer.Controls.Add(this.pnlFooter);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 80);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(1924, 981);
            this.pnlMainContainer.TabIndex = 2;
            // 
            // flpProductCards
            // 
            this.flpProductCards.AutoScroll = true;
            this.flpProductCards.BackColor = System.Drawing.Color.Gainsboro;
            this.flpProductCards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flpProductCards.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpProductCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProductCards.Location = new System.Drawing.Point(0, 0);
            this.flpProductCards.Name = "flpProductCards";
            this.flpProductCards.Padding = new System.Windows.Forms.Padding(15);
            this.flpProductCards.Size = new System.Drawing.Size(1924, 867);
            this.flpProductCards.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.AutoSize = true;
            this.pnlFooter.BackColor = System.Drawing.Color.LightGray;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.label1);
            this.pnlFooter.Controls.Add(this.pnlLine);
            this.pnlFooter.Controls.Add(this.btnCheckout);
            this.pnlFooter.Controls.Add(this.lblTotalPrice);
            this.pnlFooter.Controls.Add(this.lblTotalText);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 867);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1924, 114);
            this.pnlFooter.TabIndex = 1;
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.DarkGray;
            this.pnlLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLine.Location = new System.Drawing.Point(0, 110);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(1922, 2);
            this.pnlLine.TabIndex = 0;
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.ForeColor = System.Drawing.Color.Transparent;
            this.btnCheckout.Location = new System.Drawing.Point(30, 5);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(267, 104);
            this.btnCheckout.TabIndex = 0;
            this.btnCheckout.Text = "اصدار الفاتورة";
            this.btnCheckout.UseVisualStyleBackColor = false;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTotalPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalPrice.Location = new System.Drawing.Point(1555, 29);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(160, 60);
            this.lblTotalPrice.TabIndex = 1;
            this.lblTotalPrice.Text = "0.00";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalText
            // 
            this.lblTotalText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalText.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalText.Location = new System.Drawing.Point(1681, 29);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(207, 50);
            this.lblTotalText.TabIndex = 2;
            this.lblTotalText.Text = ":أجمالي السعر";
            this.lblTotalText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.label1.Location = new System.Drawing.Point(1452, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 60);
            this.label1.TabIndex = 3;
            this.label1.Text = "جُنية";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = global::AwladAli.Properties.Resources.Background01;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Image = global::AwladAli.Properties.Resources.setting_64;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(247, 80);
            this.btnClose.TabIndex = 121;
            this.btnClose.Text = "ادارة النظام";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1768, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 30);
            this.label2.TabIndex = 122;
            this.label2.Text = ":اسم المستخدم";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(1629, 27);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(62, 30);
            this.lblUsername.TabIndex = 123;
            this.lblUsername.Text = "[؟؟؟]";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.White;
            this.pictureBox8.Image = global::AwladAli.Properties.Resources.Person_32;
            this.pictureBox8.Location = new System.Drawing.Point(1731, 31);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 26);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 129;
            this.pictureBox8.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.Text = "Awlad Ali - POS System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlMainContainer.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.FlowLayoutPanel flpProductCards; // Scrollable area for items
        private System.Windows.Forms.Panel pnlFooter; // Fixed bottom area

        // Labels
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnCheckout;
        private Panel pnlLine;
        private Label label1;
        private Button btnClose;
        private Label lblUsername;
        private Label label2;
        private PictureBox pictureBox8;
    }
}