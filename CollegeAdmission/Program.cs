using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.Mail;
using System.Xml.Schema;
namespace CollegeAdmission;
class Program
{

    static List<StudentDetails> studentDetailsList = new List<StudentDetails>();
    static List<DepartmentDetail> departmentDetailsList = new List<DepartmentDetail>();
    static List<AdmissionDetails> admissionDetailsList = new List<AdmissionDetails>();

    static StudentDetails currentStudent;

    public static void Main(string[] args)
    {

        defaultValues();
        bool flag = true;
        do
        {
            Console.WriteLine("\t\t\tWELCOME TO SYNCFUSION COLLEGE OF ENGINEERING AND TECHNOLOGY..!\t\t\t");
            Console.Write("-----PRESS-----\n1.Student Registration\n2.Student Login\n3.Department wise seat Availibility\n4.Exit\n");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
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
                        Exit();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        } while (flag == true);
    }



    public static void RegistrationDetails()
    {
        Console.Write("Enter the Student Name: ");
        string studentName = Console.ReadLine();
        Console.Write("Enter the Father Name: ");
        string fatherName = Console.ReadLine();
        Console.Write("Enter the Date of Birth (dd/MM/yyyy): ");
        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
        Console.Write("Enter Gender:");
        Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
        Console.Write("Enter your Physics Mark: ");
        int physics = int.Parse(Console.ReadLine());
        Console.Write("Enter your Chemistry Mark: ");
        int chemistry = int.Parse(Console.ReadLine());
        Console.Write("Enter your Maths Mark: ");
        int maths = int.Parse(Console.ReadLine());

        StudentDetails student = new StudentDetails(studentName, fatherName, dob, gender, physics, chemistry, maths);
        studentDetailsList.Add(student);
        Console.WriteLine("Student Registered successfully and StudentID is " + student.StudentID);
    }


    public static void LoginDetails()
    {
        Console.WriteLine("STUDENT LOGIN");
        Console.Write("Enter your student ID:");
        string studentID = Console.ReadLine();

        foreach (StudentDetails student in studentDetailsList)
        {
            if (student.StudentID == studentID)
            {
                Console.WriteLine("Login Successfull !!!");
                currentStudent = student;
                Console.WriteLine("\n.1.Check Eligibility\n2.Show Details\n3.Take Admission\n4.Cancel Admission\n5.Show Admission Details\n6.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            if (student.IsEligibility(75))
                            {
                                Console.WriteLine("Student is eligible for admission");

                            }
                            else
                            {
                                Console.WriteLine("Student is not eligible for admission");
                            }
                            break;
                        }
                    case 2:
                        {
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {

                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            ShowAdmissionDetails();
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("Student ID could not found..!!");
            }
        }

    }
    public static void Exit()
    {
        Console.WriteLine("EXIT");
    }


    private static void CancelAdmission()
    {
        Console.WriteLine("AdmissionID  StudentID  DepartmentID AdmissionDate  AdmissionStatus");
        foreach (AdmissionDetails admission in admissionDetailsList)
        {
            if (admission.StudentID == currentStudent.StudentID && admission.AdmissionStatus == AdmissionStatus.Booked)
            {
                Console.WriteLine($"{admission.AdmissionID}  {admission.StudentID}  {admission.DepartmentID}  {admission.AdmissionDate.ToString("dd/MM/yyyy")} {admission.AdmissionStatus}");
                admission.AdmissionStatus = AdmissionStatus.Cancelled;
            }
        }
    }

    public static void ShowAdmissionDetails()
    {
        Console.WriteLine("AdmissionID  StudentID  DepartmentID AdmissionDate AdmissionStatus");
        foreach (AdmissionDetails admission in admissionDetailsList)
        {
            if (admission.StudentID == currentStudent.StudentID)
            {
                Console.WriteLine($"{admission.AdmissionID}  {admission.StudentID}  {admission.DepartmentID}  {admission.AdmissionDate.ToString("dd/MM/yyyy")} {admission.AdmissionStatus}");

            }
        }

    }

    public static void TakeAdmission()
    {
        Console.WriteLine();
    }

    public static void ShowDetails()
    {
        Console.WriteLine("Student Name: " + currentStudent.StudentName);
        Console.WriteLine("Father Name: " + currentStudent.FatherName);
        Console.WriteLine("Date of Birth: " + currentStudent.DOB);
        Console.WriteLine("Gender: " + currentStudent.Gender);
        Console.WriteLine("Physics Mark: " + currentStudent.Physics);
        Console.WriteLine("Chemistry Mark :" + currentStudent.Chemistry);
        Console.WriteLine("Maths Mark: " + currentStudent.Maths);
    }

    public static void defaultValues()
    {
        StudentDetails student1 = new StudentDetails("Ravichnndran", "Ettaparajan", new DateTime(1999 / 11 / 11), Gender.Male, 95, 95, 95);
        studentDetailsList.Add(student1);
        StudentDetails student2 = new StudentDetails("Baskaran", "sethurajan", new DateTime(1999 / 11 / 11), Gender.Male, 95, 95, 95);
        studentDetailsList.Add(student2);

        DepartmentDetail department1 = new DepartmentDetail("EEE", 29);
        departmentDetailsList.Add(department1);
        DepartmentDetail department2 = new DepartmentDetail("CSE", 29);
        departmentDetailsList.Add(department2);
        DepartmentDetail department3 = new DepartmentDetail("MECH", 30);
        departmentDetailsList.Add(department3);
        DepartmentDetail department4 = new DepartmentDetail("ECE", 30);
        departmentDetailsList.Add(department4);

        AdmissionDetails admission1 = new AdmissionDetails(studentDetailsList[0].StudentID, departmentDetailsList[0].DepartmentID, new DateTime(2022, 05, 11), AdmissionStatus.Booked);
        admissionDetailsList.Add(admission1);
        AdmissionDetails admission2 = new AdmissionDetails(studentDetailsList[1].StudentID, departmentDetailsList[1].DepartmentID, new DateTime(2022, 05, 12), AdmissionStatus.Booked);
        admissionDetailsList.Add(admission2);
    }
}

