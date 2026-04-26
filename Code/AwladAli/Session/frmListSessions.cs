using AwladAli_Buisness;
using System;
using System.Data;
using System.Windows.Forms;

namespace AwladAli.Session
{
    public partial class frmListSessions : Form
    {
        private DataTable _dtAllSessions;

        public frmListSessions()
        {
            InitializeComponent();
        }

        int _PageNumber = 1;
        int _PageSize = 10;


        private void _RefreshSessionsList()
        {
            _dtAllSessions = clsSession.GetAllSessions();
            dgvUsers.DataSource = _dtAllSessions;
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns["SessionID"].HeaderText = "معرف الجلسة";
                dgvUsers.Columns["UserName"].HeaderText = "المستخدم";

                dgvUsers.Columns["OrdersCount"].HeaderText = "عدد الطلبات";




                dgvUsers.Columns["StartTime"].Width = 200;
                dgvUsers.Columns["StartTime"].HeaderText = "وقت البداية";

                dgvUsers.Columns["EndTime"].Width = 200;
                dgvUsers.Columns["EndTime"].HeaderText = "وقت النهاية";

                dgvUsers.Columns["TotalCash"].HeaderText = "إجمالي المبيعات";
                dgvUsers.Columns["IsActive"].HeaderText = "نشطة؟";
            }
        }

        private void _RefreshSessionsListWithPagination(int PageNumber, int PageSize)
        {
            _dtAllSessions = clsSession.GetSessionsWithPagination(PageNumber, PageSize);
            dgvUsers.DataSource = _dtAllSessions;
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns["SessionID"].HeaderText = "معرف الجلسة";
                dgvUsers.Columns["UserName"].HeaderText = "المستخدم";

                dgvUsers.Columns["OrdersCount"].HeaderText = "عدد الطلبات";




                dgvUsers.Columns["StartTime"].Width = 200;
                dgvUsers.Columns["StartTime"].HeaderText = "وقت البداية";

                dgvUsers.Columns["EndTime"].Width = 200;
                dgvUsers.Columns["EndTime"].HeaderText = "وقت النهاية";

                dgvUsers.Columns["TotalCash"].HeaderText = "إجمالي المبيعات";
                dgvUsers.Columns["IsActive"].HeaderText = "نشطة؟";
            }
        }



        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                btnMore.Enabled = true;
                llReturnDefault.Enabled = true;
                llShowAll.Enabled = true;

                _PageNumber = 1;
                _RefreshSessionsListWithPagination(_PageNumber, _PageSize);
            }
            else
            {
                btnMore.Enabled = false;
                llReturnDefault.Enabled = false;
                llShowAll.Enabled = false;

                // تحميل كل الداتا عشان الفلتر يشتغل على قاعدة البيانات كاملة
                _RefreshSessionsList();
            }

            txtFilterValue.Visible = (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2);
            dtpFrom.Visible = (cbFilterBy.SelectedIndex == 3);
            lblFrom.Visible = (cbFilterBy.SelectedIndex == 3);
            cbCash.Visible = (cbFilterBy.SelectedIndex == 4);
            cbIsActive.Visible = (cbFilterBy.SelectedIndex == 5);

            // تصفير القيم
            txtFilterValue.Clear();
            txtCashValue.Clear();
            cbCash.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;

            if (_dtAllSessions != null)
                _dtAllSessions.DefaultView.RowFilter = "";

            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllSessions == null || _dtAllSessions.Rows.Count == 0) return;

            if (string.IsNullOrWhiteSpace(txtFilterValue.Text))
            {
                _dtAllSessions.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            string FilterColumn = (cbFilterBy.SelectedIndex == 1) ? "SessionID" : "UserName";

            if (FilterColumn == "UserName")
            {
                _dtAllSessions.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilterValue.Text.Trim().Replace("'", "''"));
            }
            else
            {
                if (int.TryParse(txtFilterValue.Text.Trim(), out int val))
                    _dtAllSessions.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, val);
                else
                    _dtAllSessions.DefaultView.RowFilter = "1=0"; 
            }

            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }


        private void _ApplyCashFilter()
        {
            if (cbCash.SelectedIndex == 0)
            {
                txtCashValue.Visible = false;
                _dtAllSessions.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }
            txtCashValue.Visible = true;
            string operatorSymbol = "";
            if(cbCash.SelectedIndex == 1) operatorSymbol = ">=";
            else if (cbCash.SelectedIndex == 2) operatorSymbol = "<=";
            else operatorSymbol = null;

            try
            {
                if(!string.IsNullOrEmpty(operatorSymbol))
                    _dtAllSessions.DefaultView.RowFilter = string.Format("TotalCash {0} {1}", operatorSymbol, txtCashValue.Text.Trim());
            }
            catch { }

            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void txtCashValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyCashFilter();
        }

        private void cbCash_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyCashFilter();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 0: الكل, 1: نشطة (IsActive=1), 2: مغلقة (IsActive=0)
            switch (cbIsActive.SelectedIndex)
            {
                case 1:
                    _dtAllSessions.DefaultView.RowFilter = "IsActive = 'نشطة'";
                    break;
                case 2:
                    _dtAllSessions.DefaultView.RowFilter = "IsActive = 'مغلقة'";
                    break;
                default:
                    _dtAllSessions.DefaultView.RowFilter = "";
                    break;
            }
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (_dtAllSessions == null) return;
            string filter = string.Format("StartTime >= #{0}#", dtpFrom.Value.ToString("MM/dd/yyyy"));
            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.SelectedIndex == 1) // إذا كان الفلتر على معرف الجلسة
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void txtCashValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;
            int SessionID = Convert.ToInt32(dgvUsers.CurrentRow.Cells["SessionID"].Value);


            frmSessionInfo frm = new frmSessionInfo(SessionID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListSessions_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            _PageNumber++;

            // 2. جلب الصفحة التالية من البيانات
            DataTable dtNextSessions = clsSession.GetSessionsWithPagination(_PageNumber, _PageSize);

            if (dtNextSessions != null && dtNextSessions.Rows.Count > 0)
            {
                // 3. دمج البيانات الجديدة مع الجدول الحالي
                _dtAllSessions.Merge(dtNextSessions);

                // تحديث مصدر البيانات والعدد
                dgvUsers.DataSource = _dtAllSessions;
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
            }
            else
            {
                // إذا لم توجد بيانات أخرى
                btnMore.Enabled = false;
                MessageBox.Show("لا توجد جلسات إضافية لتحميلها.", "انتهت البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _PageNumber--;
            }
        }

        private void llReturnDefault_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _PageNumber = 1;
            btnMore.Enabled = true;
            _RefreshSessionsListWithPagination(_PageNumber, _PageSize);
        }

        private void llShowAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _RefreshSessionsList();
            btnMore.Enabled = false;
        }
    }
}