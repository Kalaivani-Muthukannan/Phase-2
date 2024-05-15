using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTHRecharge
{
    public class UserRegistration
    {
        //UserID (Auto Incremented which is start from UID1001)
        //UserName
        //MobileNumber
        //EmailID
        //WalletBalance

        //Properties
        private static int s_userID = 1001;
        public string UserID { get;}
        public string UserName { get; set; }
        public long Phone { get; set; }
        public string MailID { get; set; }
        public double WalletBalance { get; set; }

        // Parameterized Constructor

        public UserRegistration(string userName, long phone, string mailID, double walletBalance)
        {
            s_userID++;
            UserID = "UID" + s_userID;
            UserName = userName;
            Phone = Phone;
            MailID = mailID;
            WalletBalance = walletBalance;
        }









    }
}