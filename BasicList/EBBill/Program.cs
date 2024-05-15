using System;
using System.Collections.Generic;
using EBBill;
namespace Assignment;
class Program
{
    public static List<EbBill> ebList = new List<EbBill>();
    public static void Main(string[] args)
    {

        int n;
        do
        {
            Console.WriteLine("-----Press-----\n1.Registration\n2.Login\n3.Exit");
            n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    {
                        RegistrationDetails();
                        break;
                    }
                case 2:
                    {
                        LoginDetails();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("EXIT");
                        break;
                    }

            }
        } while (n != 3);
    }


    public static void RegistrationDetails()
    {
        Console.WriteLine("Registration Form");
        Console.Write("Enter your User Name : ");
        string userName = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        long phone = long.Parse(Console.ReadLine());
        Console.Write("Enter MailID: ");
        string mailID = Console.ReadLine();
        Console.Write("Enter the Units: ");
        int units = int.Parse(Console.ReadLine());

        EbBill ebInfo = new EbBill(userName, phone, mailID, units);
        Console.WriteLine("You have Registered Successfully..!");
        Console.WriteLine("Your Meter ID: " + ebInfo.EbID);
        ebList.Add(ebInfo);
    }

    public static void LoginDetails()
    {
        Console.WriteLine("-----LOGIN-----");
        Console.WriteLine("Enter your Meter ID: ");
        string userID = Console.ReadLine();
        bool flag = true;

        foreach (EbBill customer in ebList)
        {
            if (customer.EbID == userID)
            {
                Console.WriteLine("WELCOME {i.UserName}!!");
                Console.WriteLine("PRESS\n1.Calculate Amount\n2.Use Details\n3.Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            Console.WriteLine("-----  EB Amount  -----");
                            Console.WriteLine($"Meter ID: +{customer.EbID}");
                            Console.WriteLine("User ID: " + customer.UserName);
                            Console.WriteLine("Unit: " + customer.Units);
                            int a = customer.EBBillGen(10);
                            Console.WriteLine($"Amount: {(customer.Units)}");
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("----- USER DETAIL -----");
                            Console.WriteLine("Meter ID: " + customer.EbID);
                            Console.WriteLine("User Name: " + customer.UserName);
                            Console.WriteLine("Phone Number: " + customer.Phone);
                            Console.WriteLine("Mail ID:" + customer.MailID);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("EXIT");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Option");
                            break;
                        }
                }
                flag = false;
            }
        }
        if (flag)
        {
            Console.WriteLine("Invalid Meter ID");
            //break;
        }
    }



}
