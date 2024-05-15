using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum AdmissionStatus
    {
        Select, Booked, Cancelled
    }
    public class AdmissionDetails
    {
        private static int s_admission_ID = 3000;
        public string AdmissionID { get; }
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus { get; set; }

        public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus admissionStatus)
        {
            s_admission_ID++;
            AdmissionID = "AID" + s_admission_ID;
            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
        }

    }
}