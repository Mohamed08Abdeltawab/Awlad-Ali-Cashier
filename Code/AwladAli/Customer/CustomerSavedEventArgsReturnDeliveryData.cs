using System;


namespace AwladAli.Customer
{
    public class CustomerSavedEventArgsReturnDeliveryData : EventArgs
    {
        public string PhoneNumber { get; }
        public string DeliveryFee { get; }
        public CustomerSavedEventArgsReturnDeliveryData(string phoneNumber, string deliveryFee)
        {
            PhoneNumber = phoneNumber;
            DeliveryFee = deliveryFee;
        }
    }
}
