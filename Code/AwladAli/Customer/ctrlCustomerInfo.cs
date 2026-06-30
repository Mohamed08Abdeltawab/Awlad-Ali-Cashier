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
    public partial class ctrlCustomerInfo : UserControl
    {
        clsCustomer _Customer;
        public string CurrentPhoneNumber = "-1";
        public bool EditFlage = true;
        public bool IsActive = false;
        public ctrlCustomerInfo()
        {
            InitializeComponent();
        }
        public void LoadCustomerDetailsByPhoneNumber(string phoneNumber)
        {
            CurrentPhoneNumber = phoneNumber;
            _Customer = clsCustomer.FindByPhoneNumber(phoneNumber);

            if (_Customer == null)
            {
                MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearCustomerDetails();
                return;
            }

            // تفعيل أو تعطيل اللينك بناءً على قيمة الفلاغ
            llEditDetails.Enabled = EditFlage;
            llClear.Enabled = EditFlage;

            lblCustomerID.Text = _Customer.CustomerID.ToString();
            lblPhoneNumber.Text = _Customer.PhoneNumber;
            lblCustomerName.Text = _Customer.FullName;
            lblAddress.Text = _Customer.Address;
            lblActivation.Text = _Customer.IsActive ? "نشط" : "غير نشط";
            IsActive = _Customer.IsActive;

            if (_Customer.IsActive)
            {
                ActivationflowLayoutPanel.BackColor = Color.Lime;
            }
            else
            {
                ActivationflowLayoutPanel.BackColor = Color.Red;
            }
        }

        private void llEditDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentPhoneNumber == null)
            {
                MessageBox.Show("No customer selected to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer(CurrentPhoneNumber);
            frm.CustomerSaved += Frm_CustomerSaved;
            frm.ShowDialog();
            // Reload customer details after editing
            LoadCustomerDetailsByPhoneNumber(CurrentPhoneNumber);
        }

        private void Frm_CustomerSaved(object sender, CustomerSavedEventArgsFillCtrl e)
        {
            CurrentPhoneNumber = e.PhoneNumber;
        }

        public void ClearCustomerDetails()
        {
            CurrentPhoneNumber = null;
            lblCustomerID.Text = "[؟؟؟]";
            lblPhoneNumber.Text = "[؟؟؟]";
            lblCustomerName.Text = "[؟؟؟]";
            lblAddress.Text = "[؟؟؟]";
            lblActivation.Text = "[؟؟؟]";
            IsActive = false;
            ActivationflowLayoutPanel.BackColor = SystemColors.Control;

            // 💡 التصحيح: يجب تطبيق التغيير على الأداة (Control) مباشرة لتسمع في الواجهة فوراً
            llEditDetails.Enabled = false;
            llClear.Enabled = false;
        }

        private void llClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearCustomerDetails();
        }
    }
}
