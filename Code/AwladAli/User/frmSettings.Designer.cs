namespace AwladAli.User
{
    partial class frmSettings
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.btnExtraLists = new System.Windows.Forms.Button();
            this.btnCategoriesList = new System.Windows.Forms.Button();
            this.btnUsersList = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(-1, 217);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(390, 50);
            this.lblTitle.TabIndex = 221;
            this.lblTitle.Text = "ادارة النظام";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::AwladAli.Properties.Resources.settings_512;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(73, 32);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(247, 180);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 225;
            this.pbPersonImage.TabStop = false;
            // 
            // btnExtraLists
            // 
            this.btnExtraLists.BackColor = System.Drawing.Color.Transparent;
            this.btnExtraLists.BackgroundImage = global::AwladAli.Properties.Resources.settingbtn_background;
            this.btnExtraLists.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExtraLists.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExtraLists.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExtraLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtraLists.ForeColor = System.Drawing.Color.Transparent;
            this.btnExtraLists.Image = global::AwladAli.Properties.Resources.extra_64;
            this.btnExtraLists.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExtraLists.Location = new System.Drawing.Point(73, 477);
            this.btnExtraLists.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExtraLists.Name = "btnExtraLists";
            this.btnExtraLists.Size = new System.Drawing.Size(247, 80);
            this.btnExtraLists.TabIndex = 224;
            this.btnExtraLists.Text = "ادارة الأضافات";
            this.btnExtraLists.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExtraLists.UseVisualStyleBackColor = false;
            this.btnExtraLists.Click += new System.EventHandler(this.btnExtraLists_Click);
            // 
            // btnCategoriesList
            // 
            this.btnCategoriesList.BackColor = System.Drawing.Color.Transparent;
            this.btnCategoriesList.BackgroundImage = global::AwladAli.Properties.Resources.settingbtn_background;
            this.btnCategoriesList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCategoriesList.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCategoriesList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCategoriesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoriesList.ForeColor = System.Drawing.Color.Transparent;
            this.btnCategoriesList.Image = global::AwladAli.Properties.Resources.Foods_64;
            this.btnCategoriesList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoriesList.Location = new System.Drawing.Point(73, 387);
            this.btnCategoriesList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCategoriesList.Name = "btnCategoriesList";
            this.btnCategoriesList.Size = new System.Drawing.Size(247, 80);
            this.btnCategoriesList.TabIndex = 223;
            this.btnCategoriesList.Text = "ادارة الأطعمة";
            this.btnCategoriesList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCategoriesList.UseVisualStyleBackColor = false;
            this.btnCategoriesList.Click += new System.EventHandler(this.btnCategoriesList_Click);
            // 
            // btnUsersList
            // 
            this.btnUsersList.BackColor = System.Drawing.Color.Transparent;
            this.btnUsersList.BackgroundImage = global::AwladAli.Properties.Resources.settingbtn_background;
            this.btnUsersList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUsersList.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnUsersList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUsersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsersList.ForeColor = System.Drawing.Color.Transparent;
            this.btnUsersList.Image = global::AwladAli.Properties.Resources.users_64;
            this.btnUsersList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsersList.Location = new System.Drawing.Point(73, 297);
            this.btnUsersList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUsersList.Name = "btnUsersList";
            this.btnUsersList.Size = new System.Drawing.Size(247, 80);
            this.btnUsersList.TabIndex = 222;
            this.btnUsersList.Text = "ادارة المستخدمين";
            this.btnUsersList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsersList.UseVisualStyleBackColor = false;
            this.btnUsersList.Click += new System.EventHandler(this.btnUsersList_Click);
            // 
            // btnClose
            // 
            this.btnClose.CausesValidation = false;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::AwladAli.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(125, 602);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(146, 46);
            this.btnClose.TabIndex = 240;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 676);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.btnExtraLists);
            this.Controls.Add(this.btnCategoriesList);
            this.Controls.Add(this.btnUsersList);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSettings";
            this.Text = "AdminPanel";
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnUsersList;
        private System.Windows.Forms.Button btnCategoriesList;
        private System.Windows.Forms.Button btnExtraLists;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Button btnClose;
    }
}