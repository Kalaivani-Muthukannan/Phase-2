using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SyncfusionAdmission
{
    public static class Operation
    {
        public static List<StudentsDetails> studentList = new List<StudentsDetails>();
        public static List<DepartmentDetail> departmentList = new List<DepartmentDetail>();
        public static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
        static StudentsDetails currentLoginStudent;

        public static void AddDefaultData()
        {
            Console.WriteLine("Adding Default data");
            //Create list for all class
            //Create objects
            //Add to list
            //Traverse and show added data

            StudentsDetails student1 = new StudentsDetails("Ravichandran", "Ettaparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            studentList.Add(student1);
            StudentsDetails student2 = new StudentsDetails("Baskaran", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            studentList.Add(student2);

            foreach (StudentsDetails students in studentList)
            {
                Console.WriteLine($"|  {students.StudentID,-10}  |  {students.StudentName,-15}  |  {students.FatherName,-15}  |   {students.DOB.ToString("dd/MM/yyyyy"),-10}  |  {students.Gender,-15}  |  {students.Physics,-10}  |  {students.Chemistry,-10}  |  {students.Maths,-10}");


            }

            DepartmentDetail department1 = new DepartmentDetail("EEE", 29);
            departmentList.Add(department1);
            DepartmentDetail department2 = new DepartmentDetail("CSE", 30);
            departmentList.Add(department2);
            DepartmentDetail department3 = new DepartmentDetail("Mech", 29);
            departmentList.Add(department3);
            DepartmentDetail department4 = new DepartmentDetail("ECE", 29);
            departmentList.Add(department4);

            foreach (DepartmentDetail departments in departmentList)
            {
                Console.WriteLine($"| {departments.DepartmentID,-10}  |  {departments.DepartmentName,-15}  |  {departments.NoOfSeats,-10}");
            }

            AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID, department1.DepartmentID, new DateTime(2022, 05, 11), AdmissionStatus.Booked);
            admissionList.Add(admission1);
            AdmissionDetails admission2 = new AdmissionDetails(student2.StudentID, department2.DepartmentID, new DateTime(2022, 05, 12), AdmissionStatus.Booked);
            admissionList.Add(admission2);

            foreach (AdmissionDetails admission in admissionList)
            {
                Console.WriteLine($"{admission.AdmissionID,-10}  |  {admission.DepartmentID,-10}  |  {admission.AdmissionDate,-15}  |  {admission.AdmissionStatus,-10}");
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("\n\t\t\tSYNCFUSION COLLEGE OF ENGINEERING AND TECHNOLOGY\t\t\t");
            int choice;
            bool flag = true;

            do
            {
                Console.WriteLine("\n1.Registration\n2.Login\n3.Exit");
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
        static void Registration()
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

            StudentsDetails student = new StudentsDetails(studentName, fatherName, dob, gender, physics, chemistry, maths);
            studentList.Add(student);
            Console.WriteLine("Student Registered successfully and StudentID is " + student.StudentID);

        }
        static void Login()
        {
            //get user ID
            //Traverse student list
            //Find user ID is present
            //if user ID not present show Invalid user ID
            //if ID present store current login cookie object globally
            //then show the submenu

            Console.WriteLine("Enter the Login ID:");
            string loginID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (StudentsDetails student in studentList)
            {
                if (student.StudentID == loginID)
                {
                    Console.WriteLine("Login Successfull");
                    flag = false;
                    currentLoginStudent = student;
                    SubMenu();
                    break;
                }

            }
            if (flag)
            {
                Console.WriteLine("Login unsuccessfull");
            }


        }

        static void SubMenu()
        {
            bool flag = true;
            do
            {
                //Console.WriteLine("Submenu");
                Console.WriteLine("1.Check eligibility\n2.Show Details\n3.Take Admission\n4.Cancel Admission\n5.Show Admission Details\n6.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            CheckEligibility();
                            break;
                        }
                    case 2:
                        {
                            //Console.WriteLine("Show Details");
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Take Admission");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Cancel Admission");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Show Admission details");
                            ShowAdmissionDetail();
                            break;
                        }
                    case 6:
                        {
                            flag = false;
                            Console.WriteLine("Check");
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (flag);
        }

        static void CheckEligibility()
        {
            bool eligible = currentLoginStudent.IsEligibile(75);
            if (eligible)
            {
                Console.WriteLine("You are eligible..!");
            }
            else
            {
                Console.WriteLine("You are eligible..!");
            }
        }

        static void ShowDetails()
        {

            Console.WriteLine($"| {currentLoginStudent.StudentName,-15}  |  {currentLoginStudent.FatherName,-15}  |  {currentLoginStudent.DOB,-15}  |  {currentLoginStudent.Gender,-15}  |  {currentLoginStudent.Physics,-10}  |  {currentLoginStudent.Chemistry,-10}  |  {currentLoginStudent.Maths,-10} ");

        }
        static void TakeAdmission()
        {

            //*•	Show the list of available departments and number of seats available by traversing the department details list

            foreach (DepartmentDetail departments in departmentList)
            {
                Console.WriteLine($"| {departments.DepartmentID,-10}  |  {departments.DepartmentName,-15}  |  {departments.NoOfSeats,-10}");
            }
            //•	Ask the student to pick one DepartmentID.
            Console.WriteLine("Enter department ID: ");
            string departmentID = Console.ReadLine().ToUpper();
            //   Validate the DepartmentID is present in the list.

            bool flag = false;
            foreach (DepartmentDetail department in departmentList)
            {
                if (department.DepartmentID == departmentID)
                {
                    flag = false;
                    //   If it is present, then check whether he is eligible to take admission.
                    bool temp = currentLoginStudent.IsEligibile(75);
                    if (temp)
                    {
                        //   If he is eligible, check whether seat available or not, 
                        if (department.NoOfSeats > 0)
                        {
                            //seats available then Check whether the student has already taken any admission by traversing admission details list. If he didn’t took any admission previously. 
                            bool admissionStatusflag = true;
                            foreach (AdmissionDetails admission in admissionList)
                            {
                                if (currentLoginStudent.StudentID == admission.StudentID && admission.AdmissionStatus == AdmissionStatus.Booked)
                                {
                                    admissionStatusflag = false;
                                }
                            }
                            //	Then, Reduce the seat count in department list and 
                            //  create admission details object by using StudentID, DepartmentID, AdmissionDate as Now, AdmissionStatus and Booked and add it to list.
                            if (admissionStatusflag)
                            {
                                department.NoOfSeats--;
                                AdmissionDetails admission = new AdmissionDetails(currentLoginStudent.StudentID, department.DepartmentID, DateTime.Now, AdmissionStatus.Booked);
                                admissionList.Add(admission);

                                //	Finally show “Admission took successfully. Your admission ID – SF3001”.
                                Console.WriteLine("Admission took successfully. Your addmision ID -" + admission.AdmissionID);
                            }
                            else
                            {
                                Console.WriteLine("You have already taken admission");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No seats availble.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not Eligible..!");
                    }


                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid Department ID");
            }
        }
        static void CancelAdmission()
        {
            //Show the current logged in student’s admission detail by traversing the list which AdmissionStatus Property is Booked. If fount then show it.
            bool flag = true;
            foreach (AdmissionDetails admission in admissionList)
            {
                if (currentLoginStudent.StudentID == admission.StudentID && admission.AdmissionStatus == AdmissionStatus.Booked)
                {
                    flag = false;
                    //Change the Admission status property to Cancelled.
                    admission.AdmissionStatus = AdmissionStatus.Cancelled;
                    //Return the seat to Department Details list

                    foreach (DepartmentDetail department in departmentList)
                    {
                        if (department.DepartmentID == admission.AdmissionID)
                        {
                            department.NoOfSeats++;
                        }
                    }
                    //Finally show admission cancelled successfully.
                    Console.WriteLine("Your admission cancelled successfully.");
                }
            }
            if (flag)
            {
                Console.WriteLine("You have not taken any admission..!");

            }






        }
        static void ShowAdmissionDetail()
        {
            bool flag = true;
            foreach (AdmissionDetails admission in admissionList)
            {
                if (admission.StudentID == currentLoginStudent.StudentID)
                {
                    Console.WriteLine($"{admission.AdmissionID,-10}  |  {admission.DepartmentID,-10}  |  {admission.AdmissionDate,-15}  |  {admission.AdmissionStatus,-10}");
                }
            }
            if (flag)
            {
                Console.WriteLine("Admission details not found");
            }
        }

        static void Exit()
        {
            Console.WriteLine("Exit...!");

        }
    }
}