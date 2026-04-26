using AwladAli_Buisness; // تأكد من استدعاء طبقة البيزنس
using System;
using System.Data;
using System.Windows.Forms;

namespace AwladAli.Category.Extra
{
    public partial class frmListExtra : Form
    {
        // DataTable لحفظ البيانات وتسهيل عملية الفلترة
        private DataTable _dtAllExtras;

        public frmListExtra()
        {
            InitializeComponent();
        }

        // دالة لتحديث قائمة الإضافات من قاعدة البيانات
        private void _RefreshExtrasList()
        {
            _dtAllExtras = clsExtra.GetAllExtras();
            dgvExtra.DataSource = _dtAllExtras;
            lblRecordsCount.Text = dgvExtra.Rows.Count.ToString();

            if (dgvExtra.Rows.Count > 0)
            {
                dgvExtra.Columns[0].HeaderText = "معرف الإضافة";
                dgvExtra.Columns[0].Width = 120;

                dgvExtra.Columns[1].HeaderText = "اسم الإضافة";
                dgvExtra.Columns[1].Width = 300;

                dgvExtra.Columns[2].HeaderText = "السعر";
                dgvExtra.Columns[2].Width = 150;
            }
        }

        private void frmListExtra_Load(object sender, EventArgs e)
        {
            _RefreshExtrasList();
            cbFilterBy.SelectedIndex = 0; // ضبط الفلترة على "None"
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.SelectedIndex != 0);

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            if (_dtAllExtras != null)
                _dtAllExtras.DefaultView.RowFilter = "";

            lblRecordsCount.Text = dgvExtra.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.SelectedIndex)
            {
                case 1:
                    FilterColumn = "ExtraID";
                    break;
                case 2:
                    FilterColumn = "ExtraName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllExtras.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvExtra.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "ExtraID")
            {
                // التحقق من الرقم لتجنب Exception
                if (int.TryParse(txtFilterValue.Text.Trim(), out _))
                    _dtAllExtras.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            }
            else
            {
                _dtAllExtras.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            }

            lblRecordsCount.Text = dgvExtra.Rows.Count.ToString();
        }

        private void btnAddExtra_Click(object sender, EventArgs e)
        {
            frmAddUpdateExtra frm = new frmAddUpdateExtra();
            frm.ShowDialog();
            _RefreshExtrasList();
        }

        private void AddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddExtra_Click(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvExtra.CurrentRow == null) return;

            int ExtraID = Convert.ToInt32(dgvExtra.CurrentRow.Cells[0].Value);
            frmAddUpdateExtra frm = new frmAddUpdateExtra(ExtraID);
            frm.ShowDialog();
            _RefreshExtrasList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvExtra.CurrentRow == null) return;

            int ExtraID = Convert.ToInt32(dgvExtra.CurrentRow.Cells[0].Value);

            if (MessageBox.Show("هل أنت متأكد من حذف هذه الإضافة؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (clsExtra.Delete(ExtraID))
            {
                MessageBox.Show("تم حذف الإضافة بنجاح.");
                _RefreshExtrasList();
            }
            else
            {
                MessageBox.Show("فشل الحذف، قد تكون الإضافة مرتبطة بطلبات سابقة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (cbFilterBy.SelectedIndex == 1)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}