using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BloodDonation
{
    public class Operations
    {
        public static List<UserRegistration> userRegistrationList = new List<UserRegistration>();
        public static List<Donation> donationList = new List<Donation>();
        static UserRegistration currentdonor;


        public static void AddDefaultDatas()
        {
            UserRegistration donor1 = new UserRegistration("Ravichandran", 8484848, BloodGroup.O_Positive, 30, new DateTime(2022, 08, 25));
            userRegistrationList.Add(donor1);

            UserRegistration donor2 = new UserRegistration("Baskaran", 4747447, BloodGroup.AB_Positive, 30, new DateTime(2022, 09, 30));
            userRegistrationList.Add(donor2);

            foreach (UserRegistration user in userRegistrationList)
            {
                Console.WriteLine($"|  {user.DonorID,-10}  |  {user.DonorName,-15}  |  {user.Phone,-10}  |  {user.BloodType,-15}  |  {user.Age,-10}  |  {user.LastDonationDate}");
            }


            Donation donation1 = new Donation("DID1001", new DateTime(2022, 06, 10), 73, 120, 14, BloodGroup.O_Positive);
            donationList.Add(donation1);
            Donation donation2 = new Donation("DID1002", new DateTime(2022, 10, 10), 74, 120, 14, BloodGroup.O_Positive);
            donationList.Add(donation2);
            Donation donation3 = new Donation("DID1003", new DateTime(2022, 06, 10), 73, 120, 14, BloodGroup.AB_Positive);
            donationList.Add(donation3);

            foreach (Donation donation in donationList)
            {
                Console.WriteLine($"|  {donation.DonationID,-10}  |  {donation.DonationDate,-15}  |  {donation.Weight,-10}  |  {donation.BloodPressure,-10}  |  {donation.HemoglobinCount,-10}  |  {donation.BloodGroup,-15}");
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("\n\t\t\tApplication For Blood Bank Management\t\t\t");
            int choice;
            bool flag = true;

            do
            {
                Console.WriteLine("\n1.Registration\n2.Login\n3.FetchDonorDetails\n4.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            FetchDonorDetails();
                            break;
                        }
                    case 4:
                        {
                            Exit();
                            flag = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }

            } while (flag);

        }

        public static void Registration()
        {
            Console.Write("Enter the Donor Name: ");
            string donorName = Console.ReadLine();
            Console.Write("Enter the Mobile NUmber: ");
            long phone = long.Parse(Console.ReadLine());
            Console.Write("Enter Blood Group:");
            BloodGroup bloodGroup = Enum.Parse<BloodGroup>(Console.ReadLine(), true);
            Console.Write("Enter the Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter the Last Donation (dd/MM/yyyy): ");
            DateTime donation = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            UserRegistration donor = new UserRegistration(donorName, phone, bloodGroup, age, donation);
            userRegistrationList.Add(donor);
            Console.WriteLine("Donor details Registered successfully and Donor ID is " + donor.DonorID);


        }
        public static void Login()
        {
            Console.WriteLine("Enter the Login ID:");
            string loginID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (UserRegistration user in userRegistrationList)
            {
                if (user.DonorID == loginID)
                {
                    Console.WriteLine("Login Successfull");
                    flag = false;
                    currentdonor = user;
                    SubMenu();
                    break;
                }

            }
            if (flag)
            {
                Console.WriteLine("Login unsuccessfull");
            }
        }


        public static void SubMenu()
        {
            bool flag = true;
            do
            {

                Console.WriteLine("1.DonorBlood\n2.DonationHistory\n3.NextEligibleDate\n4.Cancel Admission\n5.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            DonateBlood();
                            break;
                        }
                    case 2:
                        {
                            DonationHistory();
                            break;
                        }
                    case 3:
                        {
                            NextEligibleDate();
                            break;
                        }
                    case 4:
                        {
                            flag = false;
                            Exit();
                            break;

                        }
                    default:
                        {
                            break;
                        }
                }
            } while (flag);
        }
        public static void DonateBlood()
        {
            Console.Write("Enter your Weight: ");
            double weight = double.Parse(Console.ReadLine());
            Console.Write("Enter Your Blood Pressure: ");
            int bloodPressure = int.Parse(Console.ReadLine());
            Console.Write("Enter your Hemoglobin: ");
            double hemoglobin = double.Parse(Console.ReadLine());

            bool flag = true;
            if (weight > 50 && bloodPressure < 130 && hemoglobin > 13)
            {

                if (currentdonor.LastDonationDate.AddMonths(6) < DateTime.Now)
                {
                    currentdonor.LastDonationDate = DateTime.Now;
                    Donation donations = new Donation(currentdonor.DonorID, DateTime.Now, weight, bloodPressure, hemoglobin, currentdonor.BloodType);
                    donationList.Add(donations);
                    Console.WriteLine("You donated blood successfully and your donation ID is " + currentdonor.DonorID);
                    Console.WriteLine("The next eligible date for donation is " + DateTime.Now.AddMonths(6).ToString("dd/MM/yyyy"));
                }
                else
                {
                    string nextEligibleDate = currentdonor.LastDonationDate.AddMonths(6).ToString("dd/MM/yyyy");
                    Console.WriteLine("You donated recently and your next eligible datefor donation is " + nextEligibleDate);
                }
                if (flag)
                {
                    Console.WriteLine("Invalid Donor ID");
                }
            }
        }
        public static void DonationHistory()
        {
            bool flag = true;
            foreach (Donation donor in donationList)
            {
                if (currentdonor.DonorID == donor.DonationID)
                {
                    flag = false;
                    Console.WriteLine($" {currentdonor.DonorID}  | {currentdonor.DonorName}  |  {currentdonor.Phone}  |  {currentdonor.Age}  |  {currentdonor.BloodType}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No donor history");
            }
        }
        public static void NextEligibleDate()
        {
            DateTime lastEligibleDate = currentdonor.LastDonationDate;
            DateTime calculateDay = DateTime.Now;
            //DateTime temporaryDate = DateTime.Now;
            foreach (Donation donate in donationList)
            {
                if (donate.DonorID == currentdonor.DonorID)
                {
                    calculateDay = donate.DonationDate;
                }
            }
            //DateTime DonateOnDate = temporaryDate.AddMonths(6);
            //DateTime nextEligibleDate = DonateOnDate.AddDays(1);
            string eligibleDate = calculateDay.AddMonths(6).ToString("dd/MM/yyyy");
            Console.WriteLine("Your Next eligible date for donation is " + eligibleDate);
        }
        public static void FetchDonorDetails()
        {
            //Ask for “Blood Group” and check blood group in the Donation details and it should display the donor’s name and phone number and native place.
            Console.WriteLine("Enter your blood group: ");
            BloodGroup bloodGroup = Enum.Parse<BloodGroup>(Console.ReadLine(), true);
            
            bool flag = true;
            foreach (UserRegistration user in userRegistrationList)
            {
                if (bloodGroup == user.BloodType)
                {
                    flag = false;
                    Console.WriteLine($" The donor name is {user.DonorName} and his/her phone number is {user.Phone} ");
                    break;
                }

            }
            if (flag)
            {
                Console.WriteLine("Invalid Blood group");
            }
        }
        public static void Exit()
        {
            Console.WriteLine("EXIT");
        }
    }
}
