using AwladAli.Category;
using AwladAli.Category.Extra;
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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        
        private void btnUsersList_Click(object sender, EventArgs e)
        {
            frmListUsers Frm1 = new frmListUsers();
            Frm1.ShowDialog();
        }

        private void btnCategoriesList_Click(object sender, EventArgs e)
        {
            frmListCategories Frm1 = new frmListCategories();
            Frm1.ShowDialog();
        }

        private void btnExtraLists_Click(object sender, EventArgs e)
        {
            frmListExtra Frm1 = new frmListExtra();
            Frm1.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
