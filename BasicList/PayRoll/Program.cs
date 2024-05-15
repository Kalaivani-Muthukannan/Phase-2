using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using PayRoll;
namespace Assignment;
class Program
{
    public static List<PayRollBill> payRollBillsList=new List<PayRollBill>();
    public static void Main(string[] args)
    {
    
        bool flag=true;
        do
        {
            Console.Write("-----PRESS----- \n1.Registration\n2.Login\n3.Exit\n");
            int n=int.Parse(Console.ReadLine());

            switch(n)
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
                    flag = false;
                    Console.WriteLine("EXIT");
                    break;
                }
            }



        }while(flag == true);

        
    }

    
    
    public static void LoginDetails()
    {
        Console.WriteLine("EMPLOYEE LOGIN");
        Console.Write("Enter your EmployeeID: ");
        string employeeID = Console.ReadLine();

        foreach (PayRollBill employee in payRollBillsList)
        {
            if (employee.EmployeeID == employeeID)
            {
                Console.WriteLine("Login successful..!!");
                Console.WriteLine(" \n1.Calculate Salary \n2.Display Details \n3.Exit\n");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        {

                            employee.salryCalculation();
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Emoloyee Name: " + employee.EmployeeName);
                            Console.Write("Employee Gender: " + employee.Gender);
                            Console.Write("Employee Role: " + employee.Role);
                            Console.Write("Employee Location: " + employee.WorkLocation);
                            Console.Write("Employee Date of Joining: " + employee.DateOfJoining);
                            Console.Write("Employee's No of Working days: " + employee.NoOfWrkDays);
                            Console.Write("Employee's NO of Lev Taken: " + employee.NoOfLevtaken);
                            Console.Write("Employee salary: " + employee.salryCalculation());

                            break;
                        }
                    case 3:
                        {

                            Console.Write("EXIT");
                            break;
                        }
                    default:
                        {

                            Console.WriteLine("Invalid input");
                            break;
                        }
                }

            }
        }
    }

    public static void RegistrationDetails()
    {
        Console.Write("Enter Employee Name: ");
        string employeeName=Console.ReadLine();
        Console.Write("Enter Gender: ");
        Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
        Console.Write("Enter your Role: ");
        string role=Console.ReadLine();
        Console.Write("Enter your WorkLocation: ");
        WorkLocation workLocation=Enum.Parse<WorkLocation>(Console.ReadLine(),true);
        Console.Write("Enter your TeamName: ");
        string teamName=Console.ReadLine();
        Console.Write("Enter your DateOfJoining: ");
        DateTime DOJ = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy",null);
        Console.Write("Enter the No of Working days: ");
        int noOfWrkDays = int.Parse(Console.ReadLine());
        Console.Write("Enter the No of leave taken: ");
        int noOfLevTaken = int.Parse(Console.ReadLine());
        
        PayRollBill employee = new PayRollBill(employeeName,gender,role,workLocation,teamName,DOJ,noOfWrkDays,noOfLevTaken);
        payRollBillsList.Add(employee);
        Console.WriteLine("Registration Successfull..!!!");
        Console.WriteLine("Your Registration ID is "+employee.EmployeeID);
    }
}

