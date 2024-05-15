using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid
{
    public enum VaccineName
    {
        Covisheild, Covaccine
    }
    public class VaccineClass
    {
        private int s_vaccineID = 2000;
        public string VaccineID { get; set; }
        public VaccineName VaccineName { get; set; }
        public int NoOfDoseAvailable { get; set; }

        public VaccineClass(VaccineName vaccineName, int noOfDoseAvailable)
        {
            s_vaccineID ++;
            VaccineID = "CID" + s_vaccineID;
            VaccineName = vaccineName;
            NoOfDoseAvailable = noOfDoseAvailable;
        }
        
    }
}