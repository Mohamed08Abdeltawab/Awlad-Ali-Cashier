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
    public partial class frmCustomerDetailsforDelivery : Form
    {
        clsCustomer _Customer;
        DataTable _dtCustomers;
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

        public void SetDataGridView()
        {
            lblRecordsCount.Text = dgvCustomers.Rows.Count.ToString();
            if (dgvCustomers.Rows.Count > 0)
            {

                dgvCustomers.Columns[0].HeaderText = "رقم العميل";
                dgvCustomers.Columns[0].Width = 200;

                dgvCustomers.Columns[1].HeaderText = "اسم العميل";
                dgvCustomers.Columns[1].Width = 250;

                dgvCustomers.Columns[2].HeaderText = "حالة العميل";
                dgvCustomers.Columns[2].Width = 150;
            }
        }

        private void txtPhoneNameSearch_TextChanged(object sender, EventArgs e)
        {
            //search in database and show in datagridview
            if(cbSearchWith.SelectedIndex == 0)//if search by phone number
            {
                string searchText = txtPhoneNameSearch.Text.Trim();
                _dtCustomers = clsCustomer.GetTop10CustomersByPhoneNumber(searchText);
                dgvCustomers.DataSource = _dtCustomers;

                SetDataGridView();
            }
            else if(cbSearchWith.SelectedIndex == 1)//if search by name
            {
                string searchText = txtPhoneNameSearch.Text.Trim();
                _dtCustomers = clsCustomer.GetTop10CustomersByName(searchText);
                dgvCustomers.DataSource = _dtCustomers;

                SetDataGridView();
            }
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer();
            frm.ShowDialog();
        }

        private void chkDeliveryFeeStatus_CheckedChanged(object sender, EventArgs e)
        {
            if(chkDeliveryFeeStatus.Checked)
            {
                // Enable delivery fee related controls
                txtDeliveryFees.Enabled = true;
            }
            else
            {
                // Disable delivery fee related controls
                txtDeliveryFees.Enabled = false;
                txtDeliveryFees.Text = ""; // Clear the delivery fee textbox
            }
        }

        private void cmsCustomers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ctrlCustomerInfo1.LoadCustomerDetailsByPhoneNumber(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
        }

        private void SelectCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //same code of double click 
            ctrlCustomerInfo1.LoadCustomerDetailsByPhoneNumber(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل أنت متأكد من حذف العميل المحدد؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int customerId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells[0].Value);
                bool isDeleted = clsCustomer.Delete(customerId);
                if (isDeleted)
                {
                    MessageBox.Show("تم حذف العميل بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refresh the customer list after deletion
                    txtPhoneNameSearch_TextChanged(null, null);
                }
                else
                {
                    MessageBox.Show("لا يمكن حذف العميل. لوجود طلبات مرتبطة به.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (MessageBox.Show("هل تريد تعطيل العميل بدلاً من حذفه؟", "تعطيل العميل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool isDisabled = clsCustomer.Disable(customerId);
                        if (isDisabled)
                        {
                            MessageBox.Show("تم تعطيل العميل بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh the customer list after disabling
                            txtPhoneNameSearch_TextChanged(null, null);
                        }
                        else
                        {
                            MessageBox.Show("حدث خطأ أثناء تعطيل العميل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void cbSearchWith_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPhoneNameSearch.Text = "";
        }

        private void cmsCustomers_Opening(object sender, CancelEventArgs e)
        {
            bool isActive = Convert.ToBoolean(dgvCustomers.CurrentRow.Cells[2].Value);
            OnToolStripMenuItem.Visible = !isActive;
            OffToolStripMenuItem.Visible = isActive;
        }
    }
}
