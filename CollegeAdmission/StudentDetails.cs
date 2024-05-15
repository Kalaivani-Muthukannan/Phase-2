using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum Gender
    {
        Select, Male, Female, Transgender
    }
    public class StudentDetails
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
        public StudentDetails(string studentName, string fatherName, DateTime dob, Gender gender, int physics, int chemistry, int maths)
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

        public bool IsEligibility(double cutoff)
        {
            double average = (double)(Physics + Chemistry + Maths) / 3;
            if (average >= cutoff)
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