using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public class DepartmentDetail
    {
        private static int s_department_ID = 100;
        public string DepartmentID { get; }
        public string DepartmentName { get; set; }
        public int NoOfSeats { get; set; }

        public DepartmentDetail(string departmentName, int noOfSeats)
        {
            s_department_ID++;
            DepartmentID = "DID" + s_department_ID;
            DepartmentName = departmentName;
            NoOfSeats = noOfSeats;
        }

    }
}