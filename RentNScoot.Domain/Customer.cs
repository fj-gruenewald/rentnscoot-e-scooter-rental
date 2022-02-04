using System;
using Org.BouncyCastle.Security;

namespace RentNScoot
{
    public class Customer
    {
        public string CustomerID { get; set; } = String.Empty;
        public string CustomerName { get; set; } = String.Empty;
        public string CustomerAddress { get; set; } = String.Empty;
        public string CustomerPayment { get; set; } = String.Empty;

        //Create an Customer Object
        public Customer(string name, string address, string payment)
        {
            Guid customerguid = System.Guid.NewGuid();

            CustomerID = customerguid.ToString("N");
            CustomerName = name;
            CustomerAddress = address;
            CustomerPayment = payment;
        }

        public Customer()
        { }
    }
}