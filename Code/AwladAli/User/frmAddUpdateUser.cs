using AwladAli.GlobalClasses;
using AwladAli_Buisness;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AwladAli.User
{
    public partial class frmAddUpdateUser : Form
    {
        // Define Mode: Add or Update
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public enum enUserRole { Admin = 0, Cashier = 1 };

        public enum enUserActive { Active = 0, Inactive = 1 };

        private int _UserID = -1;
        private clsUser _User;

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                _User = new clsUser();
                cbRole.SelectedIndex = 1; // Default to Cashier role
                cbActivation.SelectedIndex = 0; // Default to Active status
            }
            else
            {
                lblTitle.Text = "Update User";
            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            btnSave.Enabled = true; // Enabled by default or handle with validation
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            if(clsUser.IsUserAdmin(_UserID))
            {
                cbRole.Enabled = false; // Disable role change for admin users
                cbActivation.Enabled = false; // Disable activation change for admin users
            }

            llHidePassword.Visible = false; // Hide the "Hide Password" link by default in Update mode
            llShowPassword.Visible = true; // Show the "Show Password" link by default in Update mode
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            string decryptedPassword = clsCryptography.Decrypt(_User.Password);
            txtPassword.Text = decryptedPassword;
            txtConfirmPassword.Text = decryptedPassword;
            cbRole.SelectedIndex = (int)_User.Role;
            cbActivation.SelectedIndex = _User.IsActive ? 0 : 1; // Assuming 0 = Active, 1 = Inactive
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }

            // Check if Username exists (Only in AddNew mode)
            if (_Mode == enMode.AddNew)
            {
                if (clsUser.IsUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "Username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else if(txtPassword.Text.Trim().Length < 4)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password must be at least 4 characters long");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.UserName = txtUserName.Text.Trim();
            string encryptedPassword = clsCryptography.Encrypt(txtPassword.Text.Trim());
            _User.Password = encryptedPassword;
            _User.Role = (short)cbRole.SelectedIndex;
            _User.IsActive = (cbActivation.SelectedIndex == 0); // Assuming 0 = Active, 1 = Inactive

            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                _Mode = enMode.Update; // Change mode to update after saving
                lblTitle.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            txtPassword.PasswordChar = '\0'; // '\0' تعني إظهار النص كما هو
            txtConfirmPassword.PasswordChar = '\0';

            // 2. تبديل الروابط
            llShowPassword.Visible = false;
            llHidePassword.Visible = true;
        }

        private void llHidePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // إخفاء النص مرة أخرى باستخدام النجمة أو الدائرة
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';

            // 2. تبديل الروابط
            llShowPassword.Visible = true;
            llHidePassword.Visible = false;
        }
    }
}