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
        private string _PhoneNumber;
        public ctrlCustomerInfo()
        {
            InitializeComponent();
        }
        public void LoadCustomerDetailsByPhoneNumber(string phoneNumber)
        {
            _PhoneNumber = phoneNumber;
            _Customer = clsCustomer.FindByPhoneNumber(phoneNumber);
            if( _Customer == null)
            {
                MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblCustomerID.Text = _Customer.CustomerID.ToString();
            lblPhoneNumber.Text = _Customer.PhoneNumber;
            lblCustomerName.Text = _Customer.FullName;
            lblAddress.Text = _Customer.Address;
            lblActivation.Text = _Customer.IsActive ? "نشط" : "غير نشط";
        }

        private void llEditDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer(_PhoneNumber);
            frm.ShowDialog();
            // Reload customer details after editing
            LoadCustomerDetailsByPhoneNumber(_PhoneNumber);
        }
    }
}
