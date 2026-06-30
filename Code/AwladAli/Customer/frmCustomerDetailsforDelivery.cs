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
        public event EventHandler<CustomerSavedEventArgsReturnDeliveryData> DeliveryDataBack;
        //clsCustomer _Customer;
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

            txtPhoneNameSearch_TextChanged(null, null);
            txtPhoneNameSearch.Focus();
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

                dgvCustomers.Columns[0].HeaderText = "رقم هاتف العميل";
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
            if (cbSearchWith.SelectedIndex == 0)//if search by phone number
            {
                string searchText = txtPhoneNameSearch.Text.Trim();
                _dtCustomers = clsCustomer.GetTop10CustomersByPhoneNumber(searchText);
                dgvCustomers.DataSource = _dtCustomers;
                SetDataGridView();
            }
            else if (cbSearchWith.SelectedIndex == 1)//if search by name
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
            frm.CustomerSaved += frm_CustomerSaved; // Subscribe to the CustomerSaved event
            frm.ShowDialog();
        }

        private void frm_CustomerSaved(object sender, CustomerSavedEventArgsFillCtrl e)
        {
            txtPhoneNameSearch.Text = e.PhoneNumber; // Set the search textbox to the saved customer's phone number
            ctrlCustomerInfo1.LoadCustomerDetailsByPhoneNumber(e.PhoneNumber);
        }

        private void chkDeliveryFeeStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeliveryFeeStatus.Checked)
            {
                txtDeliveryFees.Enabled = true;
                txtDeliveryFees.Text = "5";
                txtDeliveryFees.Focus(); 
            }
            else
            {
                txtDeliveryFees.Enabled = false;
                txtDeliveryFees.Text = "0"; 
                errorProvider1.SetError(txtDeliveryFees, null); 
            }
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
                string phoneNumber = dgvCustomers.CurrentRow.Cells[0].Value.ToString();
                bool isDeleted = clsCustomer.Delete(phoneNumber);
                if (isDeleted)
                {
                    MessageBox.Show("تم حذف العميل بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refresh the customer list after deletion
                    txtPhoneNameSearch_TextChanged(null, null);
                    if (ctrlCustomerInfo1.CurrentPhoneNumber == phoneNumber)
                    {
                        ctrlCustomerInfo1.ClearCustomerDetails();
                    }
                }
                else
                {
                    MessageBox.Show("لا يمكن حذف العميل. لوجود طلبات مرتبطة به.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (MessageBox.Show("هل تريد تعطيل العميل بدلاً من حذفه؟", "تعطيل العميل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool isDisabled = clsCustomer.Disable(phoneNumber);
                        if (isDisabled)
                        {
                            MessageBox.Show("تم تعطيل العميل بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh the customer list after disabling
                            txtPhoneNameSearch_TextChanged(null, null);
                            if (ctrlCustomerInfo1.CurrentPhoneNumber == phoneNumber)
                            {
                                ctrlCustomerInfo1.ClearCustomerDetails();
                            }
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
            if(cbSearchWith.SelectedIndex == 0)
            {
                pbIcon.Image = Properties.Resources.phone_number32; // Set phone icon
            }
            else if(cbSearchWith.SelectedIndex == 1)
            {
                pbIcon.Image = Properties.Resources.person32_2; // Set name icon
            }
        }

        private void cmsCustomers_Opening(object sender, CancelEventArgs e)
        {
            bool isActive = dgvCustomers.CurrentRow.Cells[2].Value.ToString() == "نشط";
            OnToolStripMenuItem.Visible = !isActive;
            OffToolStripMenuItem.Visible = isActive;
        }

        private void dgvCustomers_DoubleClick(object sender, EventArgs e)
        {
            ctrlCustomerInfo1.LoadCustomerDetailsByPhoneNumber(dgvCustomers.CurrentRow.Cells[0].Value.ToString());
        }

        private void OnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string phoneNumber = dgvCustomers.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("هل أنت متأكد من تفعيل العميل المحدد؟", "تأكيد التفعيل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool isEnabled = clsCustomer.Activate(phoneNumber);
                if (isEnabled)
                {
                    MessageBox.Show("تم تفعيل العميل بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refresh the customer list after enabling
                    txtPhoneNameSearch_TextChanged(null, null);
                    if(ctrlCustomerInfo1.CurrentPhoneNumber == phoneNumber)
                    {
                        ctrlCustomerInfo1.ClearCustomerDetails();
                    }
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء تفعيل العميل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string phoneNumber = dgvCustomers.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("هل أنت متأكد من تعطيل العميل المحدد؟", "تأكيد التعطيل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool isDisabled = clsCustomer.Disable(phoneNumber);
                if (isDisabled)
                {
                    MessageBox.Show("تم تعطيل العميل بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refresh the customer list after disabling
                    txtPhoneNameSearch_TextChanged(null, null);
                    if (ctrlCustomerInfo1.CurrentPhoneNumber == phoneNumber)
                    {
                        ctrlCustomerInfo1.ClearCustomerDetails();
                    }
                }
                else
                {
                    MessageBox.Show("حدث خطأ أثناء تعطيل العميل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string phoneNumber = dgvCustomers.CurrentRow.Cells[0].Value.ToString();
            frmAddUpdateCustomer frm = new frmAddUpdateCustomer(phoneNumber);
            frm.ShowDialog();
            frmCustomerDetailsforDelivery_Load(null, null); // Refresh the customer list after editing
            if (ctrlCustomerInfo1.CurrentPhoneNumber == phoneNumber)
            {
                ctrlCustomerInfo1.ClearCustomerDetails();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDeliveryFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDeliveryFees_Validating(object sender, CancelEventArgs e)
        {
            // Validate only if delivery fee status checkbox is checked
            if (chkDeliveryFeeStatus.Checked)
            {
                string text = txtDeliveryFees.Text.Trim();

                if (string.IsNullOrEmpty(text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtDeliveryFees, "رسوم التوصيل لا يمكن أن تكون فارغة.");
                }
                else if (!decimal.TryParse(text, out decimal deliveryFee) || deliveryFee < 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtDeliveryFees, "رسوم التوصيل يجب أن تكون رقماً موجباً.");
                }
                else
                {
                    errorProvider1.SetError(txtDeliveryFees, null);
                }
            }
            else
            {
                errorProvider1.SetError(txtDeliveryFees, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("بعض الحقول غير صالحة! ضع الماوس فوق الأيقونة الحمراء لرؤية الخطأ",
                    "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            string currentPhone = ctrlCustomerInfo1.CurrentPhoneNumber;
            if (!clsCustomer.IsCustomerExist(currentPhone))
            {
                MessageBox.Show("يرجى اختيار عميل قبل حفظ البيانات.",
                                "خطأ في اختيار العميل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string deliveryFeesToSend = chkDeliveryFeeStatus.Checked ? txtDeliveryFees.Text.Trim() : "0";


            DeliveryDataBack?.Invoke(this, new CustomerSavedEventArgsReturnDeliveryData(ctrlCustomerInfo1.CurrentPhoneNumber, deliveryFeesToSend));
            this.Close();
        }
    }
}
