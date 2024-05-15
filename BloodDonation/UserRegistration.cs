using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation
{
    public class UserRegistration
    {
        //Donor Id (Auto Incremented which is start from UID1001)
        //Donor Name
        //Mobile Number
        //Blood Group
        //Age
        //LastDonationDate
        //Properties
        private static int s_donorID = 1000;
        public string DonorID { get; }
        public string DonorName { get; set; }
        public long Phone { get; set; }
        public BloodGroup BloodType { get; set; }
        public int Age { get; set; }
        public DateTime LastDonationDate { get; set; }



        //Parameterized Constructor
        public UserRegistration(string donorName, long phone, BloodGroup bloodGroup, int age, DateTime lastDonationDate)
        {
            s_donorID++;
            DonorID = "UID" + s_donorID;
            DonorName = donorName;
            Phone = phone;
            BloodType = bloodGroup;
            Age = age;
            LastDonationDate = lastDonationDate;
        }

        public UserRegistration(string user1)
        {
            string[] values = user1.Split(",");
            s_donorID = int.Parse(values[0].Remove(0,3));
            DonorID = values[0];
            DonorName = values[1];
            Phone = long.Parse(values[2]);
            BloodType = Enum.Parse<BloodGroup>(values[3]);
            Age = int.Parse(values[4]);
            LastDonationDate = DateTime.ParseExact(values[5],"dd/MM/yyyy",null);
        }
    }
}