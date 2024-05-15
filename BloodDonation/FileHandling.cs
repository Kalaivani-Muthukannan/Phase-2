using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonation
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("BloodDonation"))
            {
                Console.WriteLine("Creating folder");
                Directory.CreateDirectory("BloodDonation");
            }
            if(!File.Exists("BloodDonation/UserRegistration.csv"))
            {
                 Console.WriteLine("Creating file");
                 File.Create("BloodDonation/UserRegistration.csv");
            }
            if(!File.Exists("BloodDonation/Donation.csv"))
            {
                 Console.WriteLine("Creating file");
                 File.Create("BloodDonation/Donation.csv");
            }

        }

        public static void WriteToCSV()
        {
            string [] user = new string [Operations.userRegistrationList.Count];
            for(int i =0;i<Operations.userRegistrationList.Count;i++)
            {
                user[i] = Operations.userRegistrationList[i].DonorID+","+Operations.userRegistrationList[i].DonorName+","+Operations.userRegistrationList[i].Phone+","+Operations.userRegistrationList[i].BloodType+","+Operations.userRegistrationList[i].Age+","+Operations.userRegistrationList[i].LastDonationDate.ToString("dd/MM/yyyy",null);
            }
            File.WriteAllLines("BloodDonation/UserRegistration.csv",user);

            string [] donation = new string [Operations.donationList.Count];
            for(int i =0;i<Operations.donationList.Count;i++)
            {
                donation[i] = Operations.donationList[i].DonationID+","+Operations.donationList[i].DonorID+","+Operations.donationList[i].DonationDate.ToString("dd/MM/yyyy")+","+Operations.donationList[i].Weight+","+Operations.donationList[i].BloodPressure+","+Operations.donationList[i].HemoglobinCount+","+Operations.donationList[i].BloodGroup;
            }
            File.WriteAllLines("BloodDonation/Donation.csv",donation);
        }

        public static void ReadToCSV()
        {
            string [] user = File.ReadAllLines("BloodDonation/UserRegistration.csv");
            foreach(string user1 in user)
            {
                UserRegistration user2 = new UserRegistration(user1);
                Operations.userRegistrationList.Add(user2); 
            }

            string [] donation = File.ReadAllLines("BloodDonation/Donation.csv");
            foreach(string donation1 in donation)
            {
                Donation donation2 = new Donation(donation1);
                Operations.donationList.Add(donation2); 
            }
        }
    }
}