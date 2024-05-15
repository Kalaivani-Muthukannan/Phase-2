using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBill
{
    public class EbBill
    {
        //Properties
        private static int s_meterID = 1001;
        public string EbID { get; }
        public string UserName { get; set; }
        public long Phone { get; set; }
        public string MailID { get; set; }
        public int Units { get; set; }


        //parameterized Constructor
        public EbBill(string userName, long phone, string mailID, int units)
        {
            s_meterID++;

            EbID = "EB" + s_meterID;
            UserName = userName;
            Phone = phone;
            MailID = mailID;
            Units = units;

        }


        //Methods
        public int EBBillGen(int a)
        {
            return a * 5;
        }

    }
}