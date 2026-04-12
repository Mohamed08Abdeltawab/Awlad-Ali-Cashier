using AwladAli_Buisness;
using System;
using System.Windows.Forms;

namespace AwladAli.Category.Extra
{
    public partial class ctrlExtraRow : UserControl
    {
        // Event to notify the POS screen when something changes
        public event Action<decimal> OnExtraAmountChanged;

        private int _ExtraID = -1;
        private decimal _Price = 0;

        public ctrlExtraRow()
        {
            InitializeComponent();
        }

        // Properties to expose data
        public int ExtraID => _ExtraID;

        public string ExtraName
        {
            get => lblProductName.Text;
            set => lblProductName.Text = value;
        }

        public decimal Price
        {
            get => _Price;
            set
            {
                _Price = value;
                chkSelectPrice.Text = _Price.ToString("0.00");
            }
        }

        public short Quantity => (short)numQuantityS.Value;

        public bool IsSelected => chkSelectPrice.Checked;

        // Total price for this specific row (Price * Quantity)
        public decimal TotalRowPrice => IsSelected ? (_Price * (decimal)numQuantityS.Value) : 0;

        public void LoadData(int ExtraID, string Name, decimal Price)
        {
            _ExtraID = ExtraID;
            this.ExtraName = Name;
            this.Price = Price;
        }

        private void chkSelectPrice_CheckedChanged(object sender, EventArgs e)
        {
            // Enable or disable quantity based on selection
            numQuantityS.Enabled = chkSelectPrice.Checked;

            if (!chkSelectPrice.Checked)
                numQuantityS.Value = 1; // Reset quantity if unchecked

            // Trigger the event to update total bill
            OnExtraAmountChanged?.Invoke(TotalRowPrice);
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (chkSelectPrice.Checked)
            {
                // Trigger the event to update total bill
                OnExtraAmountChanged?.Invoke(TotalRowPrice);
            }
        }

        // Method to reset the control state
        public void Reset()
        {
            chkSelectPrice.Checked = false;
            numQuantityS.Value = 1;
            numQuantityS.Enabled = false;
        }
    }
}