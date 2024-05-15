using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SyncfusionAdmission
{
    public enum Gender
    {
        Select, Male, Female, Transgender
    }
    public class StudentsDetails
    {
        private static int s_StudentID = 3000;
        public string StudentID { get; set; }


        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }

        //parameterized Constructor
        public StudentsDetails(string studentName, string fatherName, DateTime dob, Gender gender, int physics, int chemistry, int maths)
        {
            s_StudentID++;
            StudentID = "SF" + s_StudentID;
            StudentName = studentName;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }

        public StudentsDetails(string student)
        {
            string [] values = student.Split(",");
            StudentID = values[0];
            s_StudentID = int.Parse(values[0].Remove(0,2));
            StudentName = values[1];
            FatherName = values[2];
            DOB = DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            Gender = Enum.Parse<Gender>(values[4]);
            Physics = int.Parse(values[5]);
            Chemistry = int.Parse(values[6]);
            Maths = int.Parse(values[7]);
        }

        //Methods

        public double Average()
        {
            double average = (double)(Physics + Chemistry + Maths) / 3;
            return average;
        }
        public bool IsEligibile(double cutOff)
        {

            if (Average() >= cutOff)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}