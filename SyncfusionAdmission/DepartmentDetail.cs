using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncfusionAdmission
{
    public class DepartmentDetail
    {
        private static int s_departmentID = 100;
        public string DepartmentID { get; }
        public string DepartmentName { get; set; }
        public int NoOfSeats { get; set; }

        public DepartmentDetail(string departmentName, int noOfSeats)
        {
            s_departmentID++;
            DepartmentID = "DID" + s_departmentID;
            DepartmentName = departmentName;
            NoOfSeats = noOfSeats;
        }

        public DepartmentDetail(string department)
        {
            string [] values = department.Split(",");
            s_departmentID = int.Parse(values[0].Remove(0,3));
            DepartmentID = values[0];
            DepartmentName = values[1];
            NoOfSeats = int.Parse(values[2]);
        }
    }
}