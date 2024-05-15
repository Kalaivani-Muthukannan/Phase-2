using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation
{
    public enum BloodGroup
    {
        A_Positive, B_Positive, O_Positive, AB_Positive
    }
    public class Donation
    {
        //•Donation ID (Auto increment - DID1001)
        //Donor Id
        //Donation Date
        //Weight
        //Blood Pressure
        //Hemoglobin Count (above 13.5)
        //Blood Group – (Enum – A_Positive, B_Positive, O_Positive, AB_Positive)

        //Properties

        private static int s_DonationID = 1000;
        public string DonationID { get; }
        public string DonorID { get; set; }
        public DateTime DonationDate { get; set; }
        public double Weight { get; set; }
        public int BloodPressure { get; set; }
        public double HemoglobinCount { get; set; }
        public BloodGroup BloodGroup { get; set; }


        //Parameterized Constructor

        public Donation(string donorID, DateTime donationDate, double weight, int bloodPressure, double hemoglobinCount, BloodGroup bloodGroup)
        {
            s_DonationID++;
            DonationID = "DID" + s_DonationID;
            DonorID = donorID;
            DonationDate = donationDate;
            Weight = weight;
            BloodPressure = bloodPressure;
            HemoglobinCount = hemoglobinCount;
            BloodGroup = bloodGroup;

        }

        public Donation(string donation1)
        {
            string [] values = donation1.Split(",");
            s_DonationID = int.Parse(values[0].Remove(0,3));
            DonationID = values[0];
            DonorID = values[1];
            DonationDate = DateTime.Parse(values[2]);
            Weight = double.Parse(values[3]);
            BloodPressure = int.Parse(values[4]);
            HemoglobinCount = double.Parse(values[5]);
            BloodGroup = Enum.Parse<BloodGroup>(values[6]);

        }
    }
}