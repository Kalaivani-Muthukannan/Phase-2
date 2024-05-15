using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using BankAccountOpening;
namespace Assignment;
class Program
{
    public static List<BankAccount> banklist = new List<BankAccount>();
    public static void Main(string[] args)
    {

        int  n = int.Parse(Console.ReadLine());
        do
        {

            Console.WriteLine("----\n1. Registration\n2. Login \n3.Exit----");
           

            switch (n)
            {
                case 1:
                    string option = "";
                    do
                    {
                        RegistrationDetails();
                        Console.WriteLine("Do you want to continue?");
                        option = Console.ReadLine();

                    } while (option == "yes");
                    break;

                case 2:
                    LoginDetails();
                    break;
                case 3:
                    Console.WriteLine("EXIT");
                    break;
            }
        } while (n != 3);

    }


    // Registration Method
    public static void RegistrationDetails()
    {
        Console.WriteLine("Bank Registration Form");
        Console.Write("Customer name: ");
        string customerName = Console.ReadLine();
        Console.Write("Gender: ");
        Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
        Console.Write("Phone: ");
        long phone = long.Parse(Console.ReadLine());
        Console.Write("Mail ID: ");
        string mailID = Console.ReadLine();
        Console.Write("Date of Birth DD/MM/YYYY: ");
        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("Balance: ");
        double balance = double.Parse(Console.ReadLine());

        BankAccount bankInfo = new BankAccount(customerName, gender, phone, mailID, dob, balance);
        Console.WriteLine("You have registered successfully!");
        Console.WriteLine("Yout Bank Id: " + bankInfo.CustomerID);
        Console.WriteLine("Customer Name: " + bankInfo.CustomerName + "\nGender: " + bankInfo.Gender + "\nBalance:" + bankInfo.Balance);
        Console.WriteLine("DateOfBirth: " + bankInfo.DOB + "\nPhone Number:" + bankInfo.Phone + "\nMailID: " + bankInfo.MailID);
        banklist.Add(bankInfo);

    }
    // Login Details
    public static void LoginDetails()
    {
        Console.WriteLine("Login:  ");
        Console.WriteLine("Enter your LoginID :");
        string loginID = Console.ReadLine().ToUpper();
        bool flag = true;

        foreach (BankAccount customer in banklist)
        {
            if (customer.CustomerID == loginID)
            {
                Console.WriteLine("Login Successfull..!!");
                Console.WriteLine("1.Deposit \n2.Withdraw \n3.Check Balance \n4.Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Enter the amount to deposit: ");
                        double depositAmount = double.Parse(Console.ReadLine());
                        double depositBalance = Deposit(depositAmount, customer.Balance);
                        Console.WriteLine("The Balance Amount is " + depositBalance);
                        break;
                    case 2:
                        Console.WriteLine("Enter the amount to withdraw: ");
                        double withDrawAmt = double.Parse(Console.ReadLine());
                        double wdAmt = WithDraw(withDrawAmt, customer.Balance);
                        if (withDrawAmt > customer.Balance)
                        {
                            Console.WriteLine("Insufficient balance in your Account..!");
                        }
                        else
                        {
                            Console.WriteLine("Current Balance :" + wdAmt);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Current Balance : " + customer.Balance);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice..!");
                        break;
                }
                flag = false;
            }
            if (flag)
            {
                Console.WriteLine("Invalid Customer ID");
                break;
            }

        }
    }

    


}




