using AwladAli_Buisness; // تأكد من استدعاء طبقة البيزنس
using System;
using System.Data;
using System.Windows.Forms;

namespace AwladAli.Category
{
    public partial class frmListCategories : Form
    {
        // DataTable لحفظ البيانات وتسهيل عملية الفلترة
        private DataTable _dtAllCategories;

        public frmListCategories()
        {
            InitializeComponent();
        }


        private void frmListCategories_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0; // ضبط الفلترة على "None" افتراضياً
            _dtAllCategories = clsCategory.GetAllCategories();
            dgvGategory.DataSource = _dtAllCategories;
            lblRecordsCount.Text = dgvGategory.Rows.Count.ToString();

            if (dgvGategory.Rows.Count > 0)
            {
                dgvGategory.Columns[0].HeaderText = "Category ID";
                dgvGategory.Columns[0].Width = 120;

                dgvGategory.Columns[1].HeaderText = "Category Name";
                dgvGategory.Columns[1].Width = 350; // عرض أكبر لاسم التصنيف
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            // إعادة ضبط الجدول لعرض كافة البيانات عند تغيير نوع الفلتر
            if (_dtAllCategories != null)
                _dtAllCategories.DefaultView.RowFilter = "";

            lblRecordsCount.Text = dgvGategory.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            // ربط الاختيار في ComboBox بأسماء الأعمدة الحقيقية في قاعدة البيانات
            switch (cbFilterBy.Text)
            {
                case "Category ID":
                    FilterColumn = "CategoryID";
                    break;
                case "Category Name":
                    FilterColumn = "CategoryName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllCategories.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvGategory.Rows.Count.ToString();
                return;
            }

            // معالجة الفلترة بناءً على نوع البيانات (رقم ID أو نص Name)
            if (FilterColumn == "CategoryID")
            {
                // التحقق من أن القيمة المدخلة رقمية لتجنب الخطأ
                if (int.TryParse(txtFilterValue.Text.Trim(), out int _))
                    _dtAllCategories.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            }
            else
            {
                _dtAllCategories.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            }

            lblRecordsCount.Text = dgvGategory.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void AddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmAddUpdateCategory frm = new frmAddUpdateCategory();
             frm.ShowDialog();
             frmListCategories_Load(null,null);
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(dgvGategory.CurrentRow.Cells[0].Value);
            frmAddUpdateCategory frm = new frmAddUpdateCategory(CategoryID);
             frm.ShowDialog();
                frmListCategories_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل أنت متأكد من حذف هذا التصنيف؟ قد يؤدي هذا لحذف كافة الأكلات المندرجة تحته!",
                "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            int CategoryID = Convert.ToInt32(dgvGategory.CurrentRow.Cells[0].Value);

            if (clsCategory.DeleteCategory(CategoryID))
            {
                MessageBox.Show("تم حذف التصنيف بنجاح.");
                frmListCategories_Load(null, null);
            }
            else
            {
                MessageBox.Show("لا يمكن حذف التصنيف لوجود بيانات مرتبطة به.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            frmAddUpdateCategory frm = new frmAddUpdateCategory();
            frm.ShowDialog();
            frmListCategories_Load(null, null);
        }
    }
}