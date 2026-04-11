using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwladAli.Category
{
    public partial class frmTestControls : Form
    {
        public frmTestControls()
        {
            InitializeComponent();
        }

        private void frmTestControls_Load(object sender, EventArgs e)
        {
            ctrlCategoryCard1.LoadCategoryData(1);
        }
    }
}
