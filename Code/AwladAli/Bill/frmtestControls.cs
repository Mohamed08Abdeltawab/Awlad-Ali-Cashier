using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwladAli.Bill
{
    public partial class frmtestControls : Form
    {
        public frmtestControls()
        {
            InitializeComponent();
        }

        private void frmtestControls_Load(object sender, EventArgs e)
        {
            ctrlOrderLine1.LoadData(1); // Load data for OrderDetailID = 1
        }
    }
}
