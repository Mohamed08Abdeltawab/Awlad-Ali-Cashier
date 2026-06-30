using System;


namespace AwladAli.Customer
{
	public class CustomerSavedEventArgsFillCtrl : EventArgs
	{
		public string PhoneNumber { get; }
		public CustomerSavedEventArgsFillCtrl(string phoneNumber)
		{
			PhoneNumber = phoneNumber;
		}
	}
}
