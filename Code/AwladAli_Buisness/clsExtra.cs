using System;
using System.Data;
using AwladAli_Data;

namespace AwladAli_Buisness
{
    public class clsExtra
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ExtraID { get; set; }
        public string ExtraName { get; set; }
        public decimal Price { get; set; }

        public clsExtra()
        {
            this.ExtraID = -1;
            this.ExtraName = "";
            this.Price = 0;
            Mode = enMode.AddNew;
        }

        private clsExtra(int ExtraID, string ExtraName, decimal Price)
        {
            this.ExtraID = ExtraID;
            this.ExtraName = ExtraName;
            this.Price = Price;
            Mode = enMode.Update;
        }

        public static clsExtra Find(int ExtraID)
        {
            string Name = ""; decimal Price = 0;
            if (clsExtraData.GetExtraByID(ExtraID, ref Name, ref Price))
                return new clsExtra(ExtraID, Name, Price);
            return null;
        }

        private bool _AddNew() => (this.ExtraID = clsExtraData.AddNewExtra(this.ExtraName, this.Price)) != -1;
        private bool _Update() => clsExtraData.UpdateExtra(this.ExtraID, this.ExtraName, this.Price);

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew()) { Mode = enMode.Update; return true; }
                    return false;
                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static bool Delete(int ExtraID) => clsExtraData.DeleteExtra(ExtraID);
        public static DataTable GetAllExtras() => clsExtraData.GetAllExtras();
    }
}