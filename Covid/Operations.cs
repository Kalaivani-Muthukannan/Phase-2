using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Covid
{
    public class Operations
    {
        public static List<BeneficiaryClass> beneficiaryClassList = new List<BeneficiaryClass>();
        public static List<VaccineClass> vaccineClassList = new List<VaccineClass>();
        public static List<VaccinationClass> vaccinationClassList = new List<VaccinationClass>();

        static BeneficiaryClass currentBenificier;

        public static void AddDefaultData()
        {
            BeneficiaryClass beneficiary = new BeneficiaryClass("Ravichandran" , 21, Gender.Male, 8484888, "Chennai");
            beneficiaryClassList.Add(beneficiary);

            BeneficiaryClass beneficiary1 = new BeneficiaryClass("Baskaran" ,22, Gender.Male, 8484747, "Chennai");
            beneficiaryClassList.Add(beneficiary1);

            foreach(BeneficiaryClass benifit in beneficiaryClassList)
            {
                Console.WriteLine($"{benifit.RegistrationNum,-10}  |  {benifit.Name,-15}  |  {benifit.Phone,-10}  |  {benifit.Gender,-15}  |  {benifit.Phone,-10}  |  {benifit.City,-15}");
            }

            VaccineClass vaccine = new VaccineClass(VaccineName.Covisheild, 50);
            vaccineClassList.Add(vaccine);

            VaccineClass vaccine1 = new VaccineClass(VaccineName.Covaccine, 50);
            vaccineClassList.Add(vaccine1);

            foreach(VaccineClass vaccine2 in vaccineClassList)
            {
                Console.WriteLine($"{vaccine2.VaccineName,-10}  |  {vaccine2.NoOfDoseAvailable,-10}");
            }

            VaccinationClass vaccination = new VaccinationClass("BID1001" , "CID2001", 1, new DateTime(2021,11,11));
            vaccinationClassList.Add(vaccination);

            VaccinationClass vaccination1 = new VaccinationClass("BID1001" , "CID2001", 1, new DateTime(2022,03,11));
            vaccinationClassList.Add(vaccination1);

            VaccinationClass vaccination2 = new VaccinationClass("BID1002" , "CID2002", 1, new DateTime(2021,04,04));
            vaccinationClassList.Add(vaccination2);

            foreach(VaccinationClass vaccination3 in vaccinationClassList)
            {
                Console.WriteLine($"{vaccination2.VaccinationID,-10}  |  {vaccination2.RegistrationNum,-10}  |  {vaccination2.VaccineID}  |  {vaccination2.DoseNumber}  |  {vaccination2.VaccinatedDate}");
            }
        }

        public static void Mainmenu()
        {
            Console.WriteLine("-----COVID VACCINATION ONLINE APPLICATION------");
            int choice;
            bool flag = true;

            do
            {
                Console.WriteLine("\n1.Beneficiary Registration\n2.Login\n3.Get vaccine info");
                choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                    {
                        BeneficiaryRegistration();
                        break;
                    }
                    case 2:
                    {
                        Login();
                        break;
                    }
                    case 4:
                    {
                        GetVaccineInfo();
                        break;
                    }
                    case 3:
                    {
                        Exit();
                        break;
                    }
                }
            }while(flag);

        }

        public static void BeneficiaryRegistration()
        {
            Console.WriteLine("Beneficiary Registration");
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);

            Console.Write("Enter Mobile Number: ");
            long phone = long.Parse(Console.ReadLine());

            Console.Write("Enter your City: ");
            string city = Console.ReadLine();

            BeneficiaryClass beneficiary = new BeneficiaryClass(name, age, gender, phone, city);
            beneficiaryClassList.Add(beneficiary);

            Console.WriteLine("Your Beneficiary Registrartion Number is "+ currentBenificier.RegistrationNum);
        }

        public static void Login()
        {
            Console.WriteLine("Enter the Login ID:");
            string loginID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (BeneficiaryClass benificier in beneficiaryClassList)
            {
                if (benificier.RegistrationNum == loginID)
                {
                    Console.WriteLine("Login Successfull");
                    flag = false;
                    currentBenificier = benificier;
                    SubMenu();
                    break;
                }

            }
            if (flag)
            {
                Console.WriteLine("Login unsuccessfull");
            }

        }

        public static void Exit()
        {
            Console.WriteLine("EXIT");
        }

        public static void SubMenu()
        {
           bool flag = true;
            do
            {
                Console.WriteLine("1.Show My Details\n2.Take Vaccination\n3.My Vaccination History\n4.Next Due Date\n6.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            ShowMyDetails();
                            break;
                        }
                    case 2:
                        {
                            TakeVaccination();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Take Admission");
                            MyVaccinationHistory();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Cancel Admission");
                            NextDueDate();
                            break;
                        }
                    case 5:
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

        public static void ShowMyDetails()
        {
            foreach(BeneficiaryClass benifit in beneficiaryClassList)
            {
                if(currentBenificier.RegistrationNum == benifit.RegistrationNum)
                {
                    Console.WriteLine($"{benifit.RegistrationNum,-10}  |  {benifit.Name,-15}  |  {benifit.Phone,-10}  |  {benifit.Gender,-15}  |  {benifit.Phone,-10}  |  {benifit.City,-15}");
                }
            }

        }
        public static void TakeVaccination()
        {
           Console.WriteLine("Vaccine Details:");
            foreach (VaccineClass vaccine in vaccineClassList)
            {
                Console.WriteLine($"{vaccine.VaccineID,-10}  |  {vaccine.VaccineName,-10}  |  {vaccine.NoOfDoseAvailable,-5}");
            }
            // Ask the user to select a vaccine by using vaccine ID . 
            Console.Write("Enter the VaccineID you want: ");
            string vaccineID = Console.ReadLine().ToUpper();
            bool flag = true;
            bool temp = true;
            int tempDoseNum = 0;
            // find the ID is valid
            foreach (VaccinationClass vaccination in vaccinationClassList)
            {
                if (currentBenificier.RegistrationNum == vaccination.RegistrationNum)
                {
                    temp = false;
                    tempDoseNum = vaccination.DoseNumber;
                }
            }
            if (temp)
            {
                tempDoseNum = 0;
            }
            foreach (VaccineClass vaccine in vaccineClassList)
            {
                if (vaccineID == vaccine.VaccineID)
                {
                    if (tempDoseNum < 3)
                    {
                        if (tempDoseNum == 0)
                        {
                            foreach (BeneficiaryClass beneficiary in beneficiaryClassList)
                            {
                                if (currentBenificier.Age > 14)
                                {
                                    tempDoseNum++;
                                    vaccine.NoOfDoseAvailable--;
                                }
                            }

                        }
                        else if (tempDoseNum == 1 || tempDoseNum == 2)
                        {
                            foreach (VaccinationClass vaccination1 in vaccinationClassList)
                            {
                                if (vaccineID == vaccination1.VaccineID && currentBenificier.RegistrationNum == vaccination1.RegistrationNum)
                                {
                                    DateTime lastDate = vaccination1.VaccinatedDate;
                                    DateTime endDate = lastDate.AddDays(30);
                                    if (endDate < DateTime.Today)
                                    {
                                        vaccine.NoOfDoseAvailable--;
                                        tempDoseNum++;
                                    }
                                    else if (endDate >= DateTime.Today)
                                    {
                                        Console.WriteLine("You can take vaccination on " + endDate.AddDays(1));
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You choosed different vaccine ID");
                                }
                            }
                        }
                        VaccinationClass vaccination = new VaccinationClass(currentBenificier.RegistrationNum, vaccineID, tempDoseNum, DateTime.Today);
                        vaccinationClassList.Add(vaccination);
                        Console.WriteLine($"Successfully vaccinated, Your Vaccination ID is : {vaccination.VaccinationID}");
                    }
                    else
                    {
                        Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive");
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid VaccineID");
            }

        }
        public static void MyVaccinationHistory()
        {
            bool flag = true;
            // Show the vaccination details of the current beneficiary if he had completed first/ second/ third vaccinations.
            Console.WriteLine("Vaccination Details:");
            foreach (VaccinationClass vaccination in vaccinationClassList)
            {
                if (currentBenificier.RegistrationNum == vaccination.RegistrationNum)
                {
                    flag = false;
                    Console.WriteLine($"{vaccination.VaccinationID}  |  {vaccination.RegistrationNum}  |  {vaccination.VaccineID}  |  {vaccination.DoseNumber}  |  {vaccination.VaccinatedDate.ToString("dd/MM/yyyy")}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No Vaccination history");
            }
        }
        public static void NextDueDate()
        {
           bool flag = true;
            DateTime tempDate = DateTime.Today;
            DateTime nextEligibleDate = DateTime.Today;
            // Show the next due date for the current beneficiary by finding his details from his vaccination history. 
            foreach (VaccinationClass vaccination in vaccinationClassList)
            {
                if (currentBenificier.RegistrationNum == vaccination.RegistrationNum)
                {
                    flag = false;
                    if (vaccination.DoseNumber == 3)
                    {
                        // If he completed the third dose, display “You have completed all vaccination.
                        // Thanks for your participation in the vaccination drive.”
                        Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive.");
                    }
                    else
                    {
                        // If either first or second dose of vaccine completed means Add 30 days to find the next due date to vaccine.
                        tempDate = vaccination.VaccinatedDate;
                    }
                }
            }
            nextEligibleDate = tempDate.AddDays(30);
            Console.WriteLine($"The Next eligible Date is {nextEligibleDate.ToString("dd/MM/yyyy")}");
            if (flag)
            {
                // If he didn’t take any dose already. Then show “you can take vaccine now”.
                Console.WriteLine("You can take vaccination now");
            } 
        }

        public static void GetVaccineInfo()
        {
            Console.WriteLine("Vaccine Details :");
            foreach (VaccineClass vaccine in vaccineClassList)
            {
                Console.WriteLine($"{vaccine.VaccineID,-10}  |  {vaccine.VaccineName,-10}  |  {vaccine.NoOfDoseAvailable,-5}");
            }
        }

    }
}