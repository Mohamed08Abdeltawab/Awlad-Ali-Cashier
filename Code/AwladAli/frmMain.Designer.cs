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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.flpAddonsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.flpProductCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.llReset = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.btnSaveandShowOrderInfo = new System.Windows.Forms.Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSessionTimer = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sessionTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartSession = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlMainContainer.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.Controls.Add(this.panel1);
            this.pnlMainContainer.Controls.Add(this.flpAddonsContainer);
            this.pnlMainContainer.Controls.Add(this.flpProductCards);
            this.pnlMainContainer.Controls.Add(this.pnlFooter);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 89);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(1924, 972);
            this.pnlMainContainer.TabIndex = 2;
            // 
            // flpAddonsContainer
            // 
            this.flpAddonsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpAddonsContainer.AutoScroll = true;
            this.flpAddonsContainer.Location = new System.Drawing.Point(1663, 107);
            this.flpAddonsContainer.Name = "flpAddonsContainer";
            this.flpAddonsContainer.Size = new System.Drawing.Size(261, 751);
            this.flpAddonsContainer.TabIndex = 2;
            // 
            // flpProductCards
            // 
            this.flpProductCards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpProductCards.AutoScroll = true;
            this.flpProductCards.BackColor = System.Drawing.Color.Gainsboro;
            this.flpProductCards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flpProductCards.Location = new System.Drawing.Point(0, 0);
            this.flpProductCards.Name = "flpProductCards";
            this.flpProductCards.Padding = new System.Windows.Forms.Padding(15);
            this.flpProductCards.Size = new System.Drawing.Size(1657, 858);
            this.flpProductCards.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.AutoSize = true;
            this.pnlFooter.BackColor = System.Drawing.Color.LightGray;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.llReset);
            this.pnlFooter.Controls.Add(this.label1);
            this.pnlFooter.Controls.Add(this.pnlLine);
            this.pnlFooter.Controls.Add(this.btnSaveandShowOrderInfo);
            this.pnlFooter.Controls.Add(this.lblTotalPrice);
            this.pnlFooter.Controls.Add(this.lblTotalText);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 858);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1924, 114);
            this.pnlFooter.TabIndex = 1;
            // 
            // llReset
            // 
            this.llReset.AutoSize = true;
            this.llReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llReset.Location = new System.Drawing.Point(353, 48);
            this.llReset.Name = "llReset";
            this.llReset.Size = new System.Drawing.Size(111, 31);
            this.llReset.TabIndex = 4;
            this.llReset.TabStop = true;
            this.llReset.Text = "اعادة تعيين";
            this.llReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llReset_LinkClicked);
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
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.DarkGray;
            this.pnlLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLine.Location = new System.Drawing.Point(0, 110);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(1922, 2);
            this.pnlLine.TabIndex = 0;
            // 
            // btnSaveandShowOrderInfo
            // 
            this.btnSaveandShowOrderInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSaveandShowOrderInfo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveandShowOrderInfo.ForeColor = System.Drawing.Color.Black;
            this.btnSaveandShowOrderInfo.Location = new System.Drawing.Point(30, 5);
            this.btnSaveandShowOrderInfo.Name = "btnSaveandShowOrderInfo";
            this.btnSaveandShowOrderInfo.Size = new System.Drawing.Size(267, 104);
            this.btnSaveandShowOrderInfo.TabIndex = 0;
            this.btnSaveandShowOrderInfo.Text = "حفظ وعرض الطلب";
            this.btnSaveandShowOrderInfo.UseVisualStyleBackColor = false;
            this.btnSaveandShowOrderInfo.Click += new System.EventHandler(this.btnSaveandShowOrderInfo_Click);
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
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Black;
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlHeader.Controls.Add(this.lblSessionTimer);
            this.pnlHeader.Controls.Add(this.btnStartSession);
            this.pnlHeader.Controls.Add(this.pictureBox1);
            this.pnlHeader.Controls.Add(this.label8);
            this.pnlHeader.Controls.Add(this.pictureBox8);
            this.pnlHeader.Controls.Add(this.lblUsername);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.btnSettings);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1924, 89);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblSessionTimer
            // 
            this.lblSessionTimer.AutoSize = true;
            this.lblSessionTimer.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionTimer.ForeColor = System.Drawing.Color.White;
            this.lblSessionTimer.Location = new System.Drawing.Point(442, 31);
            this.lblSessionTimer.Name = "lblSessionTimer";
            this.lblSessionTimer.Size = new System.Drawing.Size(112, 32);
            this.lblSessionTimer.TabIndex = 141;
            this.lblSessionTimer.Text = "00:00:00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label8.Location = new System.Drawing.Point(1658, 35);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(253, 20);
            this.label8.TabIndex = 138;
            this.label8.Text = "By Eng: Mohamed Abdeltawab";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(1347, 27);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(62, 30);
            this.lblUsername.TabIndex = 123;
            this.lblUsername.Text = "[؟؟؟]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1486, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 30);
            this.label2.TabIndex = 122;
            this.label2.Text = ":اسم المستخدم";
            // 
            // sessionTimer
            // 
            this.sessionTimer.Interval = 1000;
            this.sessionTimer.Tick += new System.EventHandler(this.sessionTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.BackgroundImage = global::AwladAli.Properties.Resources.CategoryBackground;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1666, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 98);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(71, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 39);
            this.label3.TabIndex = 0;
            this.label3.Text = "الاضافات";
            // 
            // btnStartSession
            // 
            this.btnStartSession.BackColor = System.Drawing.Color.Transparent;
            this.btnStartSession.BackgroundImage = global::AwladAli.Properties.Resources.settingbtn_background;
            this.btnStartSession.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStartSession.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStartSession.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStartSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartSession.ForeColor = System.Drawing.Color.Transparent;
            this.btnStartSession.Image = global::AwladAli.Properties.Resources.start_session_64;
            this.btnStartSession.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartSession.Location = new System.Drawing.Point(578, 5);
            this.btnStartSession.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartSession.Name = "btnStartSession";
            this.btnStartSession.Size = new System.Drawing.Size(198, 80);
            this.btnStartSession.TabIndex = 140;
            this.btnStartSession.Text = "بدأ جلسة";
            this.btnStartSession.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartSession.UseVisualStyleBackColor = false;
            this.btnStartSession.Click += new System.EventHandler(this.btnStartSession_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AwladAli.Properties.Resources.Logojpeg;
            this.pictureBox1.Location = new System.Drawing.Point(836, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 139;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.White;
            this.pictureBox8.Image = global::AwladAli.Properties.Resources.Person_32;
            this.pictureBox8.Location = new System.Drawing.Point(1449, 31);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 26);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 129;
            this.pictureBox8.TabStop = false;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BackgroundImage = global::AwladAli.Properties.Resources.settingbtn_background;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSettings.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.Transparent;
            this.btnSettings.Image = global::AwladAli.Properties.Resources.setting_64;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(4, 5);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(247, 80);
            this.btnSettings.TabIndex = 121;
            this.btnSettings.Text = "ادارة النظام";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Awlad Ali - POS System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlMainContainer.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.FlowLayoutPanel flpProductCards; // Scrollable area for items
        private System.Windows.Forms.Panel pnlFooter; // Fixed bottom area
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnSaveandShowOrderInfo;
        private Panel pnlLine;
        private Label label1;
        private Button btnSettings;
        private Label lblUsername;
        private Label label2;
        private PictureBox pictureBox8;
        private FlowLayoutPanel flpAddonsContainer;
        private Panel panel1;
        private Label label3;
        private LinkLabel llReset;
        private Label label8;
        private PictureBox pictureBox1;
        private Button btnStartSession;
        private Label lblSessionTimer;
        private Timer sessionTimer;
    }
}