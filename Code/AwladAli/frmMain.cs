using AwladAli.GlobalClasses;
using AwladAli.Login;
using AwladAli.Product; 
using AwladAli_Buisness; 
using System;
using System.Data;
using System.Windows.Forms;

namespace AwladAli
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;

        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            this._frmLogin = frm;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "User: " + clsGlobal.CurrentUser.UserName;

            _LoadRestaurantMenu();
        }

        private void _LoadRestaurantMenu()
        {
            flpProductCards.Controls.Clear();

            
            DataTable dtCategories = clsCategory.GetAllCategories();

            if (dtCategories == null || dtCategories.Rows.Count == 0)
            {
                MessageBox.Show("No Categories found in Database!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            flpProductCards.SuspendLayout();

            foreach (DataRow row in dtCategories.Rows)
            {
                // إنشاء كارت جديد لكل قسم
                ctrlCategoryCard categoryCard = new ctrlCategoryCard();

                // الحصول على الـ ID من الصف
                int categoryID = Convert.ToInt32(row["CategoryID"]);

                categoryCard.LoadCategoryData(categoryID);

                flpProductCards.Controls.Add(categoryCard);
            }

            // استئناف التحديث البصري
            flpProductCards.ResumeLayout();
        }
    }
}