using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTHRecharge
{
    public class RechargeHistory
    {
        //RechargeID (Auto increment which is start from RP101)
        //UserID
        //PackID
        //RechargeDate (Current Date)
        //RechargeAmount
        //ValidTill (Date Time)
        //NumberOfChannels

        private static int s_rechargeID = 100;
        public string RechargeID { get; }
        public string UserID { get; set; }
        public string PackID { get; set; }
        public DateTime RechargeDate { get; set; }
        public double RechargeAmount { get; set; }
        public DateTime ValidTill { get; set; }
        public int NoOfChannels { get; set; }

        //Paremeterized Constructor

        public RechargeHistory(string userID, string packID, DateTime rechargeDate, double rechargeAmount, DateTime validTill, int noOfChannels)
        {
            s_rechargeID++;
            RechargeID = "RP" + s_rechargeID;
            UserID = userID;
            PackID = packID;
            RechargeDate = rechargeDate;
            RechargeAmount = rechargeAmount;
            ValidTill = validTill;
            NoOfChannels = noOfChannels;
        }
    }
}