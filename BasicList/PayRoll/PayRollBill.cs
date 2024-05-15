using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRoll
{

    public enum Gender
    {
        Male, Female, Gender
    }

    public enum WorkLocation
    {
        Chennai, Kenya
    }
    public class PayRollBill
    {
        private int s_EmpID = 1000;
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Gender Gender { get; set; }
        public string Role { get; set; }
        public WorkLocation WorkLocation { get; set; }
        public string TeamName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int NoOfWrkDays { get; set; }
        public int NoOfLevtaken { get; set; }


        //parameterized Constructor
        public PayRollBill(string employeeName, Gender gender, string role, WorkLocation workLocation, string teamName, DateTime dateOfJoining, int noOfWrkDays, int noOfLevTaken)
        {
            s_EmpID++;
            EmployeeID = "SF" + s_EmpID;
            EmployeeName = employeeName;
            Gender = gender;
            Role = role;
            WorkLocation = workLocation;
            TeamName = teamName;
            DateOfJoining = dateOfJoining;
            NoOfWrkDays = noOfWrkDays;
            NoOfLevtaken = noOfLevTaken;

        }

        public double salryCalculation()
        {

            double salary = (NoOfWrkDays - NoOfLevtaken) * 500;
            Console.Write("Salary of this month: " + salary);
            return salary;

        }

    }
}