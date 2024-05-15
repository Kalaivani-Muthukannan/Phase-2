using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public class CustomerDetails
    {
        private static int s_customerID = 1000;
        public string CustomerID { get; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public long Phone { get; set; }
        public double WalletBalance { get; set; }
        public string MailID { get; set; }
        

        //parameterized Constructor
        public CustomerDetails(string customerName, string city, long phone, double walletBalance, string mailID)
        {
            s_customerID++;
            CustomerID = "CID" + s_customerID;
            CustomerName = customerName;
            City = city;
            Phone = phone;
            WalletBalance = walletBalance;
            MailID = mailID;

        }

        public CustomerDetails(string customer1)
        {
            string [] values = customer1.Split(",");
            s_customerID = int.Parse(values[0].Remove(0,3));
            CustomerID = values[0];
            CustomerName = values[1];
            City = values[2];
            Phone = long.Parse(values[3]);
            WalletBalance = int.Parse(values[4]);
            MailID = values[5];

        }
        public void  WalletRecharge1(double recharge)
        {
            WalletBalance = WalletBalance + recharge;
            //return WalletBalance;
        }

        public void DeductBalance(double deductAmount)
        {
            WalletBalance = WalletBalance - deductAmount;
            //return WalletBalance;
        }
        
    }
}