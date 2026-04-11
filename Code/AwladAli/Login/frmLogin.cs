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
                MessageBox.Show("Please enter both Username and Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clsGlobal.LogException("Login attempt with empty fields.", System.Diagnostics.EventLogEntryType.Warning);
                return;
            }

            // 2. Hashing and Searching
            string hashPassword = clsGlobal.hashingPassword(txtPassword.Text.Trim());

            // Note: Make sure the method name in clsUser matches "FindByUsernameAndPassword"
            clsUser user = clsUser.FindByUsernameAndPassword(txtUserName.Text.Trim(), hashPassword);

            if (user != null)
            {
                // 3. Handle "Remember Me"
                if (chkRememberMe.Checked)
                {
                    // Store plain username and password (Registry handles safety)
                    clsGlobal.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
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
                MessageBox.Show("Invalid Username/Password.", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsGlobal.LogException($"Failed login attempt for username: {txtUserName.Text.Trim()}", System.Diagnostics.EventLogEntryType.Warning);
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }
    }
}
