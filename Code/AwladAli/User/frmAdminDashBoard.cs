using AwladAli.Bill;
using AwladAli.Category;
using AwladAli.Category.Extra;
using AwladAli.Session;
using AwladAli_Buisness;
using System;
using System.Windows.Forms;

namespace AwladAli.User
{
    public partial class frmAdminDashBoard : Form
    {
        public frmAdminDashBoard()
        {
            InitializeComponent();
        }

        private void frmAdminDashBoard_Load(object sender, EventArgs e)
        {
            dgvOrders.AllowUserToAddRows = false;

            //calling the refresh method with default dates to load all data at the beginning
            cbFilterBy.SelectedIndex = 0;
        }

        
        private void _RefreshDashboard(DateTime from, DateTime to)
        {
            try
            {
                clsDashboard dash = new clsDashboard(from, to);

                _FillStats(dash);
                _FillGrid(dash);
                _FillTopProducts(dash);
                _FillTopCategories(dash);
                _FillTopExtras(dash);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات:\n" + ex.Message,
                                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════
        //  1. كروت الإحصائيات
        // ════════════════════════════════════════════════════════════
        private void _FillStats(clsDashboard dash)
        {
            lblTotalRevenue.Text = dash.TotalRevenue.ToString("N2");
            lblDayRevenue.Text = dash.TodayRevenue.ToString("N2");
            lblOrderCount.Text = dash.OrdersCount.ToString();
            dtpFrom.MinDate = clsOrder.GetFirstOrderDate();
        }

        // ════════════════════════════════════════════════════════════
        //  2. DataGridView
        // ════════════════════════════════════════════════════════════
        private void _FillGrid(clsDashboard dash)
        {
            dgvOrders.DataSource = dash.Orders;
            lblRecordsCount.Text = dgvOrders.Rows.Count.ToString();

            if (dgvOrders.Columns.Count >= 4)
            {
                dgvOrders.Columns[0].HeaderText = "رقم الطلب";
                dgvOrders.Columns[0].Width = 130;
                dgvOrders.Columns[1].HeaderText = "اسم المستخدم";
                dgvOrders.Columns[1].Width = 130;
                dgvOrders.Columns[2].HeaderText = "التاريخ والوقت";
                dgvOrders.Columns[2].Width = 220;
                dgvOrders.Columns[3].HeaderText = "السعر الإجمالي";
                dgvOrders.Columns[3].Width = 150;
            }
        }

        // ════════════════════════════════════════════════════════════
        //  3. أكثر الأكلات طلباً
        // ════════════════════════════════════════════════════════════
        private void _FillTopProducts(clsDashboard dash)
        {
            lblProduct1.Text = clsDashboard.GetRankName(dash.TopProducts, 0, "ProductName");
            lblProduct2.Text = clsDashboard.GetRankName(dash.TopProducts, 1, "ProductName");
            lblProduct3.Text = clsDashboard.GetRankName(dash.TopProducts, 2, "ProductName");
            lblProduct4.Text = clsDashboard.GetRankName(dash.TopProducts, 3, "ProductName");
            lblProduct5.Text = clsDashboard.GetRankName(dash.TopProducts, 4, "ProductName");
            lblProduct6.Text = clsDashboard.GetRankName(dash.TopProducts, 5, "ProductName");
        }

        // ════════════════════════════════════════════════════════════
        //  4. أكثر الأصناف طلباً
        // ════════════════════════════════════════════════════════════
        private void _FillTopCategories(clsDashboard dash)
        {
            lblCategory1.Text = clsDashboard.GetRankName(dash.TopCategories, 0, "CategoryName");
            lblCategory2.Text = clsDashboard.GetRankName(dash.TopCategories, 1, "CategoryName");
            lblCategory3.Text = clsDashboard.GetRankName(dash.TopCategories, 2, "CategoryName");
        }

        // ════════════════════════════════════════════════════════════
        //  5. أكثر الإضافات طلباً
        // ════════════════════════════════════════════════════════════
        private void _FillTopExtras(clsDashboard dash)
        {
            lblExtra1.Text = clsDashboard.GetRankName(dash.TopExtras, 0, "ExtraName");
            lblExtra2.Text = clsDashboard.GetRankName(dash.TopExtras, 1, "ExtraName");
            lblExtra3.Text = clsDashboard.GetRankName(dash.TopExtras, 2, "ExtraName");
        }

        // ════════════════════════════════════════════════════════════
        //  زر تحديث بناءً على dtpFrom / dtpTo
        // ════════════════════════════════════════════════════════════
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                MessageBox.Show("تاريخ البداية يجب أن يكون قبل تاريخ النهاية!",
                                "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _RefreshDashboard(dtpFrom.Value.Date, dtpTo.Value.Date);
        }

        // ════════════════════════════════════════════════════════════
        //  زر إعادة تعيين – يرجع لـ "بلا"
        // ════════════════════════════════════════════════════════════
        private void btnRefreshAll_Click(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0; 
        }

        // ════════════════════════════════════════════════════════════
        //  ComboBox – فلترة بفترات جاهزة
        // ════════════════════════════════════════════════════════════
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime from = clsOrder.GetFirstOrderDate(); // تاريخ أول طلب في النظام
            DateTime to = DateTime.Today;

            switch (cbFilterBy.SelectedIndex)
            {
                case 0: from = clsOrder.GetFirstOrderDate(); to = DateTime.Today; break; // بلا
                case 1: from = DateTime.Today; to = DateTime.Today; break; // اليوم
                case 2: from = DateTime.Today.AddDays(-7); to = DateTime.Today; break; // الأسبوع الماضي
                case 3: from = DateTime.Today.AddMonths(-1); to = DateTime.Today; break; // الشهر الماضي
                case 4: from = DateTime.Today.AddMonths(-3); to = DateTime.Today; break; // آخر 3 أشهر
                case 5: from = DateTime.Today.AddMonths(-6); to = DateTime.Today; break; // آخر 6 أشهر
                case 6: from = DateTime.Today.AddYears(-1); to = DateTime.Today; break; // آخر سنة
                default: return;
            }

            // تحديث الـ DateTimePickers لتعكس الفلتر
            dtpFrom.Value = from;
            dtpTo.Value = to;

            _RefreshDashboard(from, to);
        }

        // ════════════════════════════════════════════════════════════
        //  ContextMenu – عرض تفاصيل الطلب
        // ════════════════════════════════════════════════════════════
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null) return;

            int orderID = Convert.ToInt32(dgvOrders.CurrentRow.Cells[0].Value);
            frmOrderInfo frm = new frmOrderInfo(orderID);
            frm.IsShowOrder = true;
            frm.ShowDialog();
        }

        // ════════════════════════════════════════════════════════════
        //  أزرار الإدارة
        // ════════════════════════════════════════════════════════════
        private void btnUsersList_Click(object sender, EventArgs e)
        {
            new frmListUsers().ShowDialog();
            _RefreshDashboard(dtpFrom.Value.Date, dtpTo.Value.Date);
        }

        private void btnCategoriesList_Click(object sender, EventArgs e)
        {
            new frmProductandExtra().ShowDialog();
            _RefreshDashboard(dtpFrom.Value.Date, dtpTo.Value.Date);
        }
        private void btnSessionList_Click(object sender, EventArgs e)
        {
            new frmListSessions().ShowDialog();
            _RefreshDashboard(dtpFrom.Value.Date, dtpTo.Value.Date);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}