using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    
    public enum Gender
    {
        Select, Male, Female
    }

    public enum Department
    {
        Select , ECE, EEE, CSE
    }
    public class UserDetails
    {
        private static int s_UserID = 3000;
        public string UserID { get; set; }
        
        
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public long Phone { get; set; }
        public string MailID { get; set; }
        public double WalletBalance { get; set; }
        
        

        //parameterized constructor
        public UserDetails(string userName, Gender gender, Department department, long phone, string mailID, double walletBalance)
        {
            s_UserID++;
            UserID = "SF" + s_UserID;
            UserName = userName;
            Gender = gender;
            Department = department;
            Phone = phone;
            MailID = mailID;
            WalletBalance = walletBalance;
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