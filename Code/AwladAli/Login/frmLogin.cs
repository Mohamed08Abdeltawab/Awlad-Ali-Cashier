using AwladAli.GlobalClasses;
using AwladAli_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwladAli.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Validation check before processing
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                // Display a message box informing the user to fill all required fields
                MessageBox.Show("يرجى إدخال كل من اسم المستخدم وكلمة المرور.", "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Log the warning event for empty field login attempts
                clsGlobal.LogException("Login attempt with empty fields.", System.Diagnostics.EventLogEntryType.Warning);

                return;
            }

            // 2. Hashing and Searching
            string encryptedPassword = clsCryptography.Encrypt(txtPassword.Text.Trim());

            // Note: Make sure the method name in clsUser matches "FindByUsernameAndPassword"
            clsUser user = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), encryptedPassword);

            if (user != null && user.IsActive)
            {
                // 3. Handle "Remember Me"
                if (chkRememberMe.Checked)
                {
                    // Store plain username and password (Registry handles safety)
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("");
                }

                // 4. Success Logic
                clsGlobal.CurrentUser = user;
                this.Hide();

                frmMain frm = new frmMain(this);
                frm.Show(); 
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("اسم المستخدم أو كلمة المرور غير صالحة، أو المستخدم غير نشط.", "بيانات الاعتماد خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogException($"Failed login attempt for username: {txtUserName.Text.Trim()}", System.Diagnostics.EventLogEntryType.Warning);
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "";

            if (clsGlobal.GetStoredCredential(ref UserName))
            {
                txtUserName.Text = UserName;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

        private void llHidePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtPassword.PasswordChar = '*';

            // 2. تبديل الروابط
            llShowPassword.Visible = true;
            llHidePassword.Visible = false;
        }
        private void llShowPassword_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtPassword.PasswordChar = '\0'; // '\0' تعني إظهار النص كما هو

            // 2. تبديل الروابط
            llShowPassword.Visible = false;
            llHidePassword.Visible = true;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
