using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class UserDetail
    {
        //UserID (Auto increment – UID1000)
        //UserName
        //Age
        //City
        //PhoneNumber
        //Balance

        private static int s_UserID = 1000;
        public string UserID { get; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public long Phone { get; set; }
        public double Balance { get; set; }

        //Parameterized Constructor

        public UserDetail(string userName, int age, string city, long phone, double balance)
        {
            s_UserID++;
            UserID = "UID" + s_UserID;
            UserName = userName;
            Age = age;
            City = city;
            Phone = phone;
            Balance = balance;

        }

        public UserDetail(string user1)
        {
            string[] value = user1.Split(",");
            s_UserID = int.Parse(value[0].Remove(0,3));
            UserID = value[0];
            UserName = value[1];
            Age = int.Parse(value[2]);
            City = value[3];
            Phone = long.Parse(value[4]);
            Balance = double.Parse(value[5]);

        }

        public void DeductBalance(double deductAmount)
        {
            Balance = Balance - deductAmount;
        }


    }
}