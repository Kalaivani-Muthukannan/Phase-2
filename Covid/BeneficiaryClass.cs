using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Covid
{
    public enum Gender
    {
        Male, Female, Others
    }
    public class BeneficiaryClass
    {
        private int s_RegistrationNum = 1000;
        public string RegistrationNum { get; set; }
        
        
        public string Name { get; set; }
        public int Age { get; set; }
        public  Gender Gender { get; set; }
        public long Phone { get; set; }
        public string City { get; set; }


        public BeneficiaryClass(string name, int age, Gender gender, long phone, string city)
        {
            s_RegistrationNum ++;
            RegistrationNum = "BID" + s_RegistrationNum;
            Name = name;
            Age = age;
            Gender = gender;
            Phone = phone;
            City = city;
        }
        
        
        
        
    }
}