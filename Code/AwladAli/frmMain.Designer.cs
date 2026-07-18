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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.flpAddonsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.flpProductCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDeliveryFee = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMealPrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTakeawayDelivery = new System.Windows.Forms.Panel();
            this.rbTakeaway = new System.Windows.Forms.RadioButton();
            this.llShowCustomerDetails = new System.Windows.Forms.LinkLabel();
            this.rbDelivery = new System.Windows.Forms.RadioButton();
            this.pbCancel = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.llCustomerDetails = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.llReset = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.btnSaveandShowOrderInfo = new System.Windows.Forms.Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblSessionTimer = new System.Windows.Forms.Label();
            this.btnStartSession = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.sessionTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlMainContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlTakeawayDelivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlHeader.SuspendLayout();
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
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 71);
            this.pnlMainContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(1343, 658);
            this.pnlMainContainer.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.BackgroundImage = global::AwladAli.Properties.Resources.CategoryBackground;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1137, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 78);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(63, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "الاضافات";
            // 
            // flpAddonsContainer
            // 
            this.flpAddonsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpAddonsContainer.AutoScroll = true;
            this.flpAddonsContainer.Location = new System.Drawing.Point(1137, 86);
            this.flpAddonsContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpAddonsContainer.Name = "flpAddonsContainer";
            this.flpAddonsContainer.Size = new System.Drawing.Size(203, 481);
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
            this.flpProductCards.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpProductCards.Name = "flpProductCards";
            this.flpProductCards.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.flpProductCards.Size = new System.Drawing.Size(1131, 567);
            this.flpProductCards.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.AutoSize = true;
            this.pnlFooter.BackColor = System.Drawing.Color.LightGray;
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.label6);
            this.pnlFooter.Controls.Add(this.label5);
            this.pnlFooter.Controls.Add(this.lblDeliveryFee);
            this.pnlFooter.Controls.Add(this.label7);
            this.pnlFooter.Controls.Add(this.lblMealPrice);
            this.pnlFooter.Controls.Add(this.label4);
            this.pnlFooter.Controls.Add(this.pnlTakeawayDelivery);
            this.pnlFooter.Controls.Add(this.llReset);
            this.pnlFooter.Controls.Add(this.label1);
            this.pnlFooter.Controls.Add(this.pnlLine);
            this.pnlFooter.Controls.Add(this.btnSaveandShowOrderInfo);
            this.pnlFooter.Controls.Add(this.lblTotalPrice);
            this.pnlFooter.Controls.Add(this.lblTotalText);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 568);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1343, 90);
            this.pnlFooter.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(1101, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 192;
            this.label6.Text = "جُنية";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(857, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 191;
            this.label5.Text = "جُنية";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeliveryFee
            // 
            this.lblDeliveryFee.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDeliveryFee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeliveryFee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblDeliveryFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDeliveryFee.Location = new System.Drawing.Point(905, 11);
            this.lblDeliveryFee.Name = "lblDeliveryFee";
            this.lblDeliveryFee.Size = new System.Drawing.Size(85, 20);
            this.lblDeliveryFee.TabIndex = 190;
            this.lblDeliveryFee.Text = "0.00";
            this.lblDeliveryFee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(982, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 21);
            this.label7.TabIndex = 189;
            this.label7.Text = ":سعر التوصيل";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMealPrice
            // 
            this.lblMealPrice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMealPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMealPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblMealPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMealPrice.Location = new System.Drawing.Point(1148, 11);
            this.lblMealPrice.Name = "lblMealPrice";
            this.lblMealPrice.Size = new System.Drawing.Size(91, 22);
            this.lblMealPrice.TabIndex = 188;
            this.lblMealPrice.Text = "0.00";
            this.lblMealPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(1236, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 22);
            this.label4.TabIndex = 187;
            this.label4.Text = ":سعر الوجبة";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlTakeawayDelivery
            // 
            this.pnlTakeawayDelivery.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTakeawayDelivery.Controls.Add(this.rbTakeaway);
            this.pnlTakeawayDelivery.Controls.Add(this.llShowCustomerDetails);
            this.pnlTakeawayDelivery.Controls.Add(this.rbDelivery);
            this.pnlTakeawayDelivery.Controls.Add(this.pbCancel);
            this.pnlTakeawayDelivery.Controls.Add(this.pictureBox5);
            this.pnlTakeawayDelivery.Controls.Add(this.llCustomerDetails);
            this.pnlTakeawayDelivery.Controls.Add(this.pictureBox2);
            this.pnlTakeawayDelivery.Location = new System.Drawing.Point(356, 1);
            this.pnlTakeawayDelivery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTakeawayDelivery.Name = "pnlTakeawayDelivery";
            this.pnlTakeawayDelivery.Size = new System.Drawing.Size(491, 84);
            this.pnlTakeawayDelivery.TabIndex = 186;
            // 
            // rbTakeaway
            // 
            this.rbTakeaway.AutoSize = true;
            this.rbTakeaway.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbTakeaway.Checked = true;
            this.rbTakeaway.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbTakeaway.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTakeaway.Location = new System.Drawing.Point(218, 8);
            this.rbTakeaway.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbTakeaway.Name = "rbTakeaway";
            this.rbTakeaway.Size = new System.Drawing.Size(228, 28);
            this.rbTakeaway.TabIndex = 5;
            this.rbTakeaway.TabStop = true;
            this.rbTakeaway.Text = "(Takeaway) إستلام من المحل";
            this.rbTakeaway.UseVisualStyleBackColor = true;
            this.rbTakeaway.CheckedChanged += new System.EventHandler(this.rbTakeaway_CheckedChanged);
            // 
            // llShowCustomerDetails
            // 
            this.llShowCustomerDetails.AutoSize = true;
            this.llShowCustomerDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowCustomerDetails.LinkColor = System.Drawing.Color.Green;
            this.llShowCustomerDetails.Location = new System.Drawing.Point(44, 50);
            this.llShowCustomerDetails.Name = "llShowCustomerDetails";
            this.llShowCustomerDetails.Size = new System.Drawing.Size(168, 25);
            this.llShowCustomerDetails.TabIndex = 185;
            this.llShowCustomerDetails.TabStop = true;
            this.llShowCustomerDetails.Text = "عرض معلومات العميل";
            this.llShowCustomerDetails.Visible = false;
            this.llShowCustomerDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowCustomerDetails_LinkClicked);
            // 
            // rbDelivery
            // 
            this.rbDelivery.AutoSize = true;
            this.rbDelivery.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbDelivery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDelivery.Location = new System.Drawing.Point(246, 47);
            this.rbDelivery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbDelivery.Name = "rbDelivery";
            this.rbDelivery.Size = new System.Drawing.Size(200, 28);
            this.rbDelivery.TabIndex = 6;
            this.rbDelivery.Text = "(Delivery) توصيل للمنزل";
            this.rbDelivery.UseVisualStyleBackColor = true;
            this.rbDelivery.CheckedChanged += new System.EventHandler(this.rbDelivery_CheckedChanged);
            // 
            // pbCancel
            // 
            this.pbCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCancel.Image = global::AwladAli.Properties.Resources.cancel32;
            this.pbCancel.Location = new System.Drawing.Point(11, 50);
            this.pbCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(28, 21);
            this.pbCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCancel.TabIndex = 184;
            this.pbCancel.TabStop = false;
            this.pbCancel.Visible = false;
            this.pbCancel.Click += new System.EventHandler(this.pbCancel_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::AwladAli.Properties.Resources.takeaway32;
            this.pictureBox5.Location = new System.Drawing.Point(452, 10);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(28, 21);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 181;
            this.pictureBox5.TabStop = false;
            // 
            // llCustomerDetails
            // 
            this.llCustomerDetails.AutoSize = true;
            this.llCustomerDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llCustomerDetails.LinkColor = System.Drawing.Color.Red;
            this.llCustomerDetails.Location = new System.Drawing.Point(52, 49);
            this.llCustomerDetails.Name = "llCustomerDetails";
            this.llCustomerDetails.Size = new System.Drawing.Size(148, 25);
            this.llCustomerDetails.TabIndex = 183;
            this.llCustomerDetails.TabStop = true;
            this.llCustomerDetails.Text = "إضافة بيانات العميل";
            this.llCustomerDetails.Visible = false;
            this.llCustomerDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCustomerDetails_LinkClicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AwladAli.Properties.Resources.delivery32;
            this.pictureBox2.Location = new System.Drawing.Point(452, 49);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 182;
            this.pictureBox2.TabStop = false;
            // 
            // llReset
            // 
            this.llReset.AutoSize = true;
            this.llReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llReset.Location = new System.Drawing.Point(226, 41);
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
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.label1.Location = new System.Drawing.Point(944, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "جُنية";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.DarkGray;
            this.pnlLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLine.Location = new System.Drawing.Point(0, 86);
            this.pnlLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(1341, 2);
            this.pnlLine.TabIndex = 0;
            // 
            // btnSaveandShowOrderInfo
            // 
            this.btnSaveandShowOrderInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSaveandShowOrderInfo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveandShowOrderInfo.ForeColor = System.Drawing.Color.Black;
            this.btnSaveandShowOrderInfo.Location = new System.Drawing.Point(27, 4);
            this.btnSaveandShowOrderInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveandShowOrderInfo.Name = "btnSaveandShowOrderInfo";
            this.btnSaveandShowOrderInfo.Size = new System.Drawing.Size(193, 82);
            this.btnSaveandShowOrderInfo.TabIndex = 0;
            this.btnSaveandShowOrderInfo.Text = "حفظ وعرض الطلب";
            this.btnSaveandShowOrderInfo.UseVisualStyleBackColor = false;
            this.btnSaveandShowOrderInfo.Click += new System.EventHandler(this.btnSaveandShowOrderInfo_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTotalPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalPrice.Location = new System.Drawing.Point(1035, 40);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(147, 34);
            this.lblTotalPrice.TabIndex = 1;
            this.lblTotalPrice.Text = "0.00";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalText
            // 
            this.lblTotalText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalText.Location = new System.Drawing.Point(1197, 38);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(91, 39);
            this.lblTotalText.TabIndex = 2;
            this.lblTotalText.Text = ":أجمالي السعر";
            this.lblTotalText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Black;
            this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlHeader.Controls.Add(this.btnLogout);
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
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1343, 71);
            this.pnlHeader.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.BackgroundImage = global::AwladAli.Properties.Resources.settingbtn_background;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogout.Image = global::AwladAli.Properties.Resources.logout64;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(1153, 3);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(190, 64);
            this.btnLogout.TabIndex = 142;
            this.btnLogout.Text = "تسجيل الخروج";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblSessionTimer
            // 
            this.lblSessionTimer.AutoSize = true;
            this.lblSessionTimer.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionTimer.ForeColor = System.Drawing.Color.White;
            this.lblSessionTimer.Location = new System.Drawing.Point(241, 33);
            this.lblSessionTimer.Name = "lblSessionTimer";
            this.lblSessionTimer.Size = new System.Drawing.Size(97, 30);
            this.lblSessionTimer.TabIndex = 141;
            this.lblSessionTimer.Text = "00:00:00";
            // 
            // btnStartSession
            // 
            this.btnStartSession.BackColor = System.Drawing.Color.Transparent;
            this.btnStartSession.BackgroundImage = global::AwladAli.Properties.Resources.settingbtn_background;
            this.btnStartSession.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStartSession.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStartSession.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStartSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartSession.ForeColor = System.Drawing.Color.Transparent;
            this.btnStartSession.Image = global::AwladAli.Properties.Resources.start_session_64;
            this.btnStartSession.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartSession.Location = new System.Drawing.Point(345, 4);
            this.btnStartSession.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartSession.Name = "btnStartSession";
            this.btnStartSession.Size = new System.Drawing.Size(160, 64);
            this.btnStartSession.TabIndex = 140;
            this.btnStartSession.Text = "بدأ جلسة";
            this.btnStartSession.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartSession.UseVisualStyleBackColor = false;
            this.btnStartSession.Click += new System.EventHandler(this.btnStartSession_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AwladAli.Properties.Resources.Logojpeg;
            this.pictureBox1.Location = new System.Drawing.Point(566, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 139;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label8.Location = new System.Drawing.Point(673, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 16);
            this.label8.TabIndex = 138;
            this.label8.Text = "By Eng: Mohamed Abdeltawab";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.White;
            this.pictureBox8.Image = global::AwladAli.Properties.Resources.Person_32;
            this.pictureBox8.Location = new System.Drawing.Point(954, 25);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(28, 21);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 129;
            this.pictureBox8.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(886, 16);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(62, 30);
            this.lblUsername.TabIndex = 123;
            this.lblUsername.Text = "[؟؟؟]";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(988, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 30);
            this.label2.TabIndex = 122;
            this.label2.Text = ":اسم المستخدم";
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BackgroundImage = global::AwladAli.Properties.Resources.settingbtn_background;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.Transparent;
            this.btnSettings.Image = global::AwladAli.Properties.Resources.setting_64;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(4, 3);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(172, 68);
            this.btnSettings.TabIndex = 121;
            this.btnSettings.Text = "ادارة النظام";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // sessionTimer
            // 
            this.sessionTimer.Interval = 1000;
            this.sessionTimer.Tick += new System.EventHandler(this.sessionTimer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 729);
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1213, 582);
            this.Name = "frmMain";
            this.Text = "Awlad Ali - POS System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlMainContainer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlTakeawayDelivery.ResumeLayout(false);
            this.pnlTakeawayDelivery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.FlowLayoutPanel flpProductCards; // Scrollable area for items
        private Button btnSettings;
        private Label lblUsername;
        private Label label2;
        private PictureBox pictureBox8;
        private FlowLayoutPanel flpAddonsContainer;
        private Panel panel1;
        private Label label3;
        private Label label8;
        private PictureBox pictureBox1;
        private Button btnStartSession;
        private Label lblSessionTimer;
        private Timer sessionTimer;
        private Panel pnlFooter;
        private PictureBox pbCancel;
        private LinkLabel llCustomerDetails;
        private PictureBox pictureBox2;
        private PictureBox pictureBox5;
        private RadioButton rbDelivery;
        private RadioButton rbTakeaway;
        private LinkLabel llReset;
        private Label label1;
        private Panel pnlLine;
        private Button btnSaveandShowOrderInfo;
        private Label lblTotalPrice;
        private Label lblTotalText;
        private LinkLabel llShowCustomerDetails;
        private Panel pnlTakeawayDelivery;
        private Label lblMealPrice;
        private Label label4;
        private Label lblDeliveryFee;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button btnLogout;
    }
}