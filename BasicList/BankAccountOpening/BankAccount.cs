using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccountOpening
{
    public enum Gender{
        Male, Female, Transgender
    }
    public class BankAccount
    {
        // Feild
        private static int s_CustomerID=1000;

        public string CustomerID{get;}

        public string CustomerName { get; set; }
        public double Balance { get; set; }
        public Gender Gender { get; set; }
        public long Phone { get; set; }
        public string MailID { get; set; }
        public DateTime DOB { get; set; }

        //Contructor
        // parameterized Constructor
        public BankAccount(string customerName,Gender gender,long phone,string mailID,DateTime dob,double balance)
        {
            s_CustomerID++;
            CustomerID="HDFC"+s_CustomerID;
            //assign values to properties
            CustomerName=customerName;
            Balance=balance;
            Gender=gender;
            Phone=phone;
            MailID=mailID;
            DOB=dob;

        }
        //Destructor
        ~BankAccount()
        {
            Console.WriteLine("Destructor called");
        }

        //Methods

        public static void Deposit(double balAmt, double depAmt)
        {
            double d = balAmt + depAmt;

        }
        public void WithDraw(double balAmt, double withAmt)
        {
            double w = Math.Abs(balAmt - withAmt);

        }














    }
}