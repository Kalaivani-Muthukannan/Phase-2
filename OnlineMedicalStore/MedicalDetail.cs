using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class MedicalDetail
    {
        //MedicineID (Auto increment – MD2000)
        //MedicineName
        //AvailableCount
        //Price
        //DateOfExpiry

        private static int s_medicalID = 2000;
        public string MedicalID { get; }
        public string MedicineName { get; set; }
        public int AvailableCount { get; set; }
        public double Price { get; set; }
        public DateTime DateOfExpiry { get; set; }

        //Parameterized Constructor
        public MedicalDetail(string medicineName, int availableCount, double price, DateTime dateOfExpiry)
        {
            s_medicalID++;
            MedicalID = "MD" + s_medicalID;
            MedicineName = medicineName;
            AvailableCount = availableCount;
            Price = price;
            DateOfExpiry = dateOfExpiry;
        }

        public MedicalDetail(string medical1)
        {
            string[] value = medical1.Split(",");
            s_medicalID = int.Parse(value[0].Remove(0,2));
            MedicalID = value[0];
            MedicineName = value[1];
            AvailableCount = int.Parse(value[2]);
            Price = double.Parse(value[3]);
            DateOfExpiry = DateTime.ParseExact(value[4],"dd/MM/yyyy",null);
        }

    }
}