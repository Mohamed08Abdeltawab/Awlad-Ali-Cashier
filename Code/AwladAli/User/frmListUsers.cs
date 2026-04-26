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

namespace AwladAli.User
{
    public partial class frmListUsers : Form
    {
        private  DataTable _dtAllUsers;
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtAllUsers;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();

            dgvUsers.Columns[0].HeaderText = "User ID";
            dgvUsers.Columns[0].Width = 110;

            dgvUsers.Columns[1].HeaderText = "UserName";
            dgvUsers.Columns[1].Width = 170;

            dgvUsers.Columns[2].HeaderText = "Role Name";
            dgvUsers.Columns[2].Width = 150;

            dgvUsers.Columns[3].HeaderText = "Status";
            dgvUsers.Columns[3].Width = 150;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtAllUsers.DefaultView.RowFilter = "";//Reset the filter to show all data before apply new filter.
            if (cbFilterBy.Text == "Role")
            {
                txtFilterValue.Visible = false;
                cbActivation.Visible = false;
                cbRole.Visible = true;
                cbRole.Focus();
                cbRole.SelectedIndex = 0;
            }
            else if(cbFilterBy.Text == "Status")
            {
                txtFilterValue.Visible = false;
                cbActivation.Visible = true;
                cbRole.Visible = false;
                cbActivation.Focus();
                cbActivation.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbRole.Visible = false;//if not check role 

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "UserName":
                    FilterColumn = "UserName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "UserName")
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "RoleName";
            string FilterValue = cbRole.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Admin":
                    FilterValue = "Admin";
                    break;
                case "Cashier":
                    FilterValue = "Cashier";
                    break;
            }


            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}'", FilterColumn, FilterValue);

            lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();
        }

        private void cbActivation_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "Status";
            string FilterValue = cbActivation.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Active":
                    FilterValue = "Active";
                    break;
                case "Inactive":
                    FilterValue = "Inactive";
                    break;
            }


            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}'", FilterColumn, FilterValue);

            lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser Frm1 = new frmAddUpdateUser();
            Frm1.ShowDialog();
            frmListUsers_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            frmAddUpdateUser Frm1 = new frmAddUpdateUser(UserID);
            Frm1.ShowDialog();
            frmListUsers_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            if(UserID == 1)//super admin
            {
                MessageBox.Show("لا يمكن حذف المستخدم لأنه مسؤول", "فشل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsUser.DeleteUser(UserID))
            {
                MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListUsers_Load(null, null);
            }
            else
            {
                if (MessageBox.Show("لا يمكن حذف المستخدم بسبب وجود بيانات مرتبطة به هل تريد تعطيل المستخدم ؟", "فشل", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    OffToolStripMenuItem_Click(sender, e);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser Frm1 = new frmAddUpdateUser();
            Frm1.ShowDialog();
            frmListUsers_Load(null, null);
        }

        private void OnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            if (clsUser.ActivateUser(UserID))
            {
                MessageBox.Show("تم تفعيل المستخدم بنجاح", "Activated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnToolStripMenuItem.Enabled = false;
                OffToolStripMenuItem.Enabled = true;
                frmListUsers_Load(null, null);
            }
        }

        private void OffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            if (clsUser.DeactivateUser(UserID))
            {
                MessageBox.Show("تم تعطيل المستخدم بنجاح", "Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnToolStripMenuItem.Enabled = true;
                OffToolStripMenuItem.Enabled = false;
                frmListUsers_Load(null, null);
            }
        }

        private void cmsUsers_Opening(object sender, CancelEventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            if (UserID == 1)//super admin
            {
                OnToolStripMenuItem.Enabled = false;
                OffToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                return;
            }

            string currentStatus = dgvUsers.CurrentRow.Cells["Status"].Value.ToString();

            if (currentStatus == "Active")
            {
                // لو هو شغال: اقفل زرار التفعيل وشغل زرار التعطيل
                OnToolStripMenuItem.Enabled = false;
                OffToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
            else
            {
                // لو هو معطل: شغل زرار التفعيل واقفل زرار التعطيل
                OnToolStripMenuItem.Enabled = true;
                OffToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = true;
            }
        }
    }
}