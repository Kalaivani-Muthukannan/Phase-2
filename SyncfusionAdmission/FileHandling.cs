using System;
using System.Buffers;
using System.IO;

namespace SyncfusionAdmission
{
    public class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("SyncfusionAdmission"))
            {
                Console.WriteLine("Create Folder");
                Directory.CreateDirectory("SyncfusionAdmission");
            }

            //File for student info
            if (!File.Exists("SyncfusionAdmission/StudentsDetails.csv"))
            {
                Console.WriteLine("Creating File..");
                File.Create("SyncfusionAdmission/StudentsDetails.csv").Close();
            }

            //File for student department
            if (!File.Exists("SyncfusionAdmission/DepartmentDetail.csv"))
            {
                Console.WriteLine("Creating File..");
                File.Create("SyncfusionAdmission/DepartmentDetail.csv").Close();
            }

            //File for Admission Info
            if (!File.Exists("SyncfusionAdmission/AdmissionDetails.csv"))
            {
                Console.WriteLine("Creating File..");
                File.Create("SyncfusionAdmission/AdmissionDetails.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            string[] student = new string[Operation.studentList.Count];
            for (int i = 0; i < Operation.studentList.Count; i++)
            {
                student[i] = Operation.studentList[i].StudentID + "," + Operation.studentList[i].StudentName + "," + Operation.studentList[i].FatherName + "," + Operation.studentList[i].DOB.ToString("dd/MM/yyyy") + "," + Operation.studentList[i].Gender + "," + Operation.studentList[i].Physics + "," + Operation.studentList[i].Chemistry + "," + Operation.studentList[i].Maths;
            }
            File.WriteAllLines("SyncfusionAdmission/StudentsDetails.csv", student);

            //Department Info

            string[] department = new string[Operation.departmentList.Count];
            for (int i = 0; i < Operation.admissionList.Count; i++)
            {
                department[i] = Operation.departmentList[i].DepartmentID + "," + Operation.departmentList[i].DepartmentName + "," + Operation.departmentList[i].NoOfSeats;
            }
            File.WriteAllLines("SyncfusionAdmission/DepartmentDetail.csv", department);

            //AdmissionInfo

            string[] admission = new string[Operation.admissionList.Count];
            for (int i = 0; i < Operation.admissionList.Count; i++)
            {
                admission[i] = Operation.admissionList[i].AdmissionID + "," + Operation.admissionList[i].StudentID + "," + Operation.admissionList[i].DepartmentID + "," + Operation.admissionList[i].AdmissionDate.ToString("dd/MM/yyyy") + "," + Operation.admissionList[i].AdmissionStatus;
            }
            File.WriteAllLines("SyncfusionAdmission/AdmissionDetails.csv", admission);


        }

        public static void ReadFromCSV()
        {
            string[] students = File.ReadAllLines("SyncfusionAdmission/StudentsDetails.csv");
            foreach (string student in students)
            {
                StudentsDetails students1 = new StudentsDetails(student);
                Operation.studentList.Add(students1);
            }

            string[] departments = File.ReadAllLines("SyncfusionAdmission/DepartmentDetail.csv");
            foreach (string department in departments)
            {
                DepartmentDetail department1 = new DepartmentDetail(department);
                Operation.departmentList.Add(department1);
            }

            string[] admissions = File.ReadAllLines("SyncfusionAdmission/AdmissionDetails.csv");
            foreach (string admission in admissions)
            {
                AdmissionDetails admission1 = new AdmissionDetails(admission);
                Operation.admissionList.Add(admission1);
            }
        }

    }
}