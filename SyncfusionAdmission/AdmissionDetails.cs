using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionAdmission
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

        public AdmissionDetails(string admission)
        {
            string [] values = admission.Split(",");
            s_admission_ID= int.Parse(values[1].Remove(0,3));
            AdmissionID = values[0];
            StudentID = values[1];
            DepartmentID = values[2];
            AdmissionDate = DateTime.ParseExact(values[3],("dd/MM/yyyy"),null);
            AdmissionStatus = Enum.Parse<AdmissionStatus>(values[4]);
        }


    }
}