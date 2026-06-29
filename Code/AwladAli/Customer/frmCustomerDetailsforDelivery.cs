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
    public partial class frmCustomerDetailsforDelivery : Form
    {
        public frmCustomerDetailsforDelivery()
        {
            InitializeComponent();
        }

        private void frmCustomerDetailsforDelivery_Load(object sender, EventArgs e)
        {
            _LoadCustomerDetails();
        }

        private void _LoadCustomerDetails()
        {
            cbSearchWith.SelectedIndex = 0; // Default to search by phone number
            txtPhoneNameSearch.Text = "";
        }

        private void txtPhoneNameSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbSearchWith.SelectedIndex == 0)//if search by phone number
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void txtPhoneNameSearch_TextChanged(object sender, EventArgs e)
        {
            //search in database and show in datagridview
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();
            frm.ShowDialog();
        }
    }
}
