using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTHRecharge
{
    public class PackDetails
    {
        //PackID 
        //PackName
        //Price
        //Validity 
        //NoOfChannels

        public string PackID;
        public string PackName { get; set; }
        public double Price { get; set; }
        public int Validity { get; set; }
        public int NoOfChannels { get; set; }

        //Parameterized Constructor
        public PackDetails(string packName, double price, int validity, int noOfChannels)
        {
            PackID = "RC" + price;
            Price = price;
            Validity = validity;
            NoOfChannels = noOfChannels;
        }
    }
}