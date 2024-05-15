using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid
{
    public class VaccinationClass
    {
        private int s_vaccinationID = 3000;
        public string VaccinationID { get; set; }
        
        
        public string RegistrationNum { get; set; }
        public string VaccineID { get; set; }
        public int DoseNumber { get; set; }
        public DateTime VaccinatedDate { get; set; }

        public VaccinationClass(string registrationNum, string vaccineID, int doseNumber, DateTime vaccinatedDate)
        {
            s_vaccinationID ++;
            VaccinationID = "VID" + s_vaccinationID;
            RegistrationNum = registrationNum;
            DoseNumber = DoseNumber;
            VaccinatedDate = vaccinatedDate;

        }
        
        
        
        
        
        
        
        
        
    }
}