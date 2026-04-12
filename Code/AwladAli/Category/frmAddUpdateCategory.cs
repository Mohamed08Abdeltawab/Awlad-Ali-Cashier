using AwladAli_Buisness;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AwladAli.Category
{
    public partial class frmAddUpdateCategory : Form
    {
        // Define enums for form modes
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _CategoryID = -1;
        private clsCategory _Category;

        // Constructor for Add New Mode
        public frmAddUpdateCategory()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        // Constructor for Update Mode
        public frmAddUpdateCategory(int CategoryID)
        {
            InitializeComponent();
            _CategoryID = CategoryID;
            _Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            _FillCategoriesComboBox();
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Category";
                _Category = new clsCategory();
                btnAddNewProduct.Enabled = false; // Cannot add products to unsaved category
            }
            else
            {
                lblTitle.Text = "Update Category";
                btnAddNewProduct.Enabled = true;
            }

            txtCategoryName.Text = "";
            btnSave.Enabled = true;
        }


        private void _LoadData()
        {

            _Category = clsCategory.Find(_CategoryID);

            if (_Category == null)
            {
                MessageBox.Show("Category Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblCategoryID.Text = _Category.CategoryID.ToString();
            txtCategoryName.Text = _Category.CategoryName;

            // Load products linked to this category
            _RefreshProductsList();
        }

        private void _RefreshProductsList()
        {
            DataTable dtProducts = clsProduct.GetAllProductsByCategory(_CategoryID);
            dgvProduct.DataSource = dtProducts;

            if (dgvProduct.Rows.Count > 0)
            {
                // Customizing column headers and widths
                dgvProduct.Columns["ProductID"].HeaderText = "ID";
                dgvProduct.Columns["ProductID"].Width = 60;

                dgvProduct.Columns["ProductName"].HeaderText = "اسم الأكلة";
                dgvProduct.Columns["ProductName"].Width = 150;

                dgvProduct.Columns["Small"].HeaderText = "صغير (S)";
                dgvProduct.Columns["Medium"].HeaderText = "وسط (M)";
                dgvProduct.Columns["Large"].HeaderText = "كبير (L)";
                dgvProduct.Columns["XLarge"].HeaderText = "ضخم (XL)";

                // Optional: formatting prices to show 2 decimal places
                dgvProduct.Columns["Small"].DefaultCellStyle.Format = "N2";
                dgvProduct.Columns["Medium"].DefaultCellStyle.Format = "N2";
                dgvProduct.Columns["Large"].DefaultCellStyle.Format = "N2";
                dgvProduct.Columns["XLarge"].DefaultCellStyle.Format = "N2";
            }
        }

        private void frmAddUpdateCategory_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void _FillCategoriesComboBox()
        {
            // 1. Get all categories from database
            DataTable dtCategories = clsCategory.GetAllCategories();

            // 2. Clear existing items just in case
            cbShowAllCategoryName.Items.Clear();

            // 3. Fill the ComboBox with Category Names
            foreach (DataRow row in dtCategories.Rows)
            {
                cbShowAllCategoryName.Items.Add(row["CategoryName"].ToString());
            }

            // 4. If we are in Update mode, set the selected item to the current category name
            if (_Mode == enMode.Update)
            {
                cbShowAllCategoryName.Text = _Category.CategoryName;
            }
        }

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            // Open the Add/Update Product form and pass current CategoryID
            frmAddUpdateProduct frm = new frmAddUpdateProduct(_CategoryID);
            frm.ShowDialog();

            // Refresh the grid after adding a new product
            _RefreshProductsList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please fill the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Category.CategoryName = txtCategoryName.Text.Trim();

            if (_Category.Save())
            {
                _CategoryID = _Category.CategoryID;
                lblCategoryID.Text = _CategoryID.ToString();

                // Switch mode to Update after first save
                _Mode = enMode.Update;
                lblTitle.Text = "Update Category";
                btnAddNewProduct.Enabled = true;

                MessageBox.Show("Category Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCategoryName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCategoryName, "Category name is required!");
            }
            else
            {
                errorProvider1.SetError(txtCategoryName, null);
            }
        }

        // --- Context Menu Actions ---

        private void EditMedicinetoolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int ProductID = Convert.ToInt32(dgvProduct.CurrentRow.Cells[0].Value);

            // Open Product form in Update mode
            frmAddUpdateProduct frm = new frmAddUpdateProduct(_CategoryID, ProductID);
            frm.ShowDialog();

            _RefreshProductsList();
        }

        private void removeMedicineToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ProductID = Convert.ToInt32(dgvProduct.CurrentRow.Cells[0].Value);
                if (clsProduct.DeleteProduct(ProductID))
                {
                    _RefreshProductsList();
                }
            }
        }

    }
}