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
    public partial class frmProductandExtra : Form
    {
        public frmProductandExtra()
        {
            InitializeComponent();
        }

        private void btnCategoriesList_Click(object sender, EventArgs e)
        {
            new frmListCategories().ShowDialog();
        }

        private void btnExtraLists_Click(object sender, EventArgs e)
        {
            new frmListExtra().ShowDialog();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
