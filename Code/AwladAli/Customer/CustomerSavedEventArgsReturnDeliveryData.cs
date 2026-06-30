using AwladAli.GlobalClasses;
using AwladAli_Buisness;
using System;


namespace AwladAli.Customer
{
    public class CustomerSavedEventArgsReturnDeliveryData : EventArgs
    {
        public clsGlobal.CustomerDetailsInfo CustomerDetailsInfo { get; }
        public CustomerSavedEventArgsReturnDeliveryData(clsGlobal.CustomerDetailsInfo details)
        {
            CustomerDetailsInfo = details;
        }
    }
}
