using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public enum OrderStatus
    {
        Purchased, Cancelled
    }
    public class OrderDetail
    {
        //OrderID (Auto increment – OID3000)
        //UserID
        //MedicineID
        //MedicineCount
        //TotalPrice
        //OrderDate
        //OrderStatus {Enum – Purchased, Cancelled}

        private static int s_OrderID = 3000;
        public string OrderID { get; }
        public string UserID { get; set; }
        public string MedicalID { get; set; }
        public int MedicineCount { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }

        //Parameterized Constructor

        public OrderDetail(string userID, string medicalID, int medicineCount, double totalPrice, DateTime orderDate, OrderStatus orderStatus)
        {
            s_OrderID++;
            OrderID = "OID" + s_OrderID;
            UserID = userID;
            MedicalID = medicalID;
            MedicineCount = medicineCount;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
        }

        public OrderDetail(string order1)
        {
            string[] value = order1.Split(",");
            s_OrderID = int.Parse(value[0].Remove(0,3));
            OrderID = value[0];
            UserID = value[1];
            MedicalID = value[2];
            MedicineCount = int.Parse(value[3]);
            TotalPrice = double.Parse(value[4]);
            OrderDate = DateTime.ParseExact(value[5],"dd/MM/yyyy",null);
            OrderStatus = Enum.Parse<OrderStatus>(value[6]);
        }
    }
}