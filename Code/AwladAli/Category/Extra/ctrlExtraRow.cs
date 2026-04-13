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
        private clsExtra _Extra;

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

        public short Quantity => (short)numQuantity.Value;

        public decimal Price => _Extra != null ? _Extra.Price : 0;

        public bool IsSelected => chkSelectPrice.Checked;

        // Total price for this specific row (Price * Quantity)
        public decimal TotalRowPrice => (IsSelected && _Extra != null) ? (_Extra.Price * (decimal)numQuantity.Value) : 0;
        public void LoadData(int ExtraID)
        {
            _ExtraID = ExtraID;
            _Extra = clsExtra.Find(ExtraID);

            if (_Extra != null)
            {
                lblProductName.Text = _Extra.ExtraName;
                chkSelectPrice.Text = _Extra.Price.ToString("0.00");
                numQuantity.Value = 1; // Default quantity when loading is 1
            }
        }

        private void chkSelectPrice_CheckedChanged(object sender, EventArgs e)
        {
            numQuantity.Enabled = chkSelectPrice.Checked;

            if (chkSelectPrice.Checked)
            {
                if (numQuantity.Value == 0) numQuantity.Value = 1;
            }
            else
            {
                numQuantity.Value = 0; // Or keep it 1 but disabled
            }

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
            numQuantity.Value = 0;
            numQuantity.Enabled = false;
        }
    }
}