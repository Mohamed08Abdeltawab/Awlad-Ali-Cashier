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

namespace AwladAli.Customer
{
    public partial class frmAddUpdateCustomer : Form
    {
        public event EventHandler<CustomerSavedEventArgsFillCtrl> CustomerSaved;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public enum enCustomerActive { Active = 0, Inactive = 1 };//in save will see condition if == 0 then active else inactive
        public string _PhoneNumber = "";
        private clsCustomer _Customer;
        private clsUser _User;
        public frmAddUpdateCustomer()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateCustomer(string PhoneNumber)
        {
            InitializeComponent();
            _PhoneNumber = PhoneNumber;
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "اضافة عميل جديد";
                _Customer = new clsCustomer();
                cbActivation.SelectedIndex = 0; // Default to Active status

                _User = clsUser.Find(clsGlobal.CurrentUser.UserID);
                if (_User != null)
                    lblCreatedByUser.Text = _User.UserName;
                else
                    lblCreatedByUser.Text = "N/A";
            }
            else
            {
                lblTitle.Text = "تعديل عميل";
            }
            txtCustomerName.Text = "";
            txtPhoneNumber.Text = "";
            rtxtAddress.Text = "";
            btnSave.Enabled = true; // Enabled by default or handle with validation
        }

        private void _LoadData()
        {
            _Customer = clsCustomer.FindByPhoneNumber(_PhoneNumber);
            if (_Customer == null)
            {
                MessageBox.Show("العميل غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblCustomerID.Text = _Customer.CustomerID.ToString();
            txtCustomerName.Text = _Customer.FullName;
            txtPhoneNumber.Text = _Customer.PhoneNumber;
            rtxtAddress.Text = _Customer.Address;
            rtxtNotes.Text = _Customer.Notes;
            lblCreatedDate.Text = _Customer.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
            cbActivation.SelectedIndex = _Customer.IsActive ? 0 : 1; // Assuming IsActive is a boolean

            if (_Customer.CreatedByUserID.HasValue)
            {
                _User = clsUser.Find(_Customer.CreatedByUserID.Value);

                if (_User != null)
                    lblCreatedByUser.Text = _User.UserName;
                else
                    lblCreatedByUser.Text = "N/A";
            }
            else
            {
                lblCreatedByUser.Text = "N/A";
            }
        }

        private void frmAddUpdateCustomer_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if(_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhoneNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhoneNumber, "رقم الهاتف لا يمكن أن يكون فارغاً");
            }
            // Check if Username exists (Only in AddNew mode)
            else if (_Mode == enMode.AddNew)
            {
                if (clsCustomer.IsCustomerExist(txtPhoneNumber.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtPhoneNumber, "رقم الهاتف مستخدم من قبل عميل آخر");
                }
                else
                {
                    errorProvider1.SetError(txtPhoneNumber, null);
                }
            }
            else
            {
                errorProvider1.SetError(txtPhoneNumber, null);
            }
        }

        private void txtCustomerName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCustomerName, "اسم العميل لا يمكن أن يكون فارغاً");
            }
            else
            {
                errorProvider1.SetError(txtCustomerName, null);
            }
        }

        private void rtxtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtAddress.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(rtxtAddress, "العنوان لا يمكن أن يكون فارغاً");
            }
            else
            {
                errorProvider1.SetError(rtxtAddress, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("بعض الحقول غير صالحة! ضع الماوس فوق الأيقونة الحمراء لرؤية الخطأ",
                    "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Customer.FullName = txtCustomerName.Text.Trim();
            _Customer.PhoneNumber = txtPhoneNumber.Text.Trim();
            _Customer.Address = rtxtAddress.Text.Trim();
            _Customer.Notes = rtxtNotes.Text.Trim();
            _Customer.IsActive = (cbActivation.SelectedIndex == 0); // Assuming 0 is Active, 1 is Inactive
            if(clsGlobal.CurrentUser != null)
                _Customer.CreatedByUserID = clsGlobal.CurrentUser.UserID; // Assuming you have a way to get the current user

            if (_Customer.Save())
            {
                lblCustomerID.Text = _Customer.CustomerID.ToString();
                lblCreatedDate.Text = _Customer.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss");
                lblTitle.Text = "تعديل عميل";
                _Mode = enMode.Update; // Change mode to update after saving
                MessageBox.Show("تم حفظ بيانات العميل بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CustomerSaved?.Invoke(this, new CustomerSavedEventArgsFillCtrl(_Customer.PhoneNumber)); // Raise the event to notify subscribers
            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء حفظ بيانات العميل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
