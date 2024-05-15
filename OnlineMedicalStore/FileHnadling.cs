using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class FileHnadling
    {
        public static void Create()
        {
            if(!Directory.Exists("OnlineMedicalStore"))
            {
                Console.WriteLine("Creating Folder");
                Directory.CreateDirectory("OnlineMedicalStore");
            }
            else
            {
                Console.WriteLine("Folder already Exixts");
            }
            if(!File.Exists("OnlineMedicalStore/UserDetail.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("OnlineMedicalStore/UserDetail.csv").Close();
            }
            else
            {
                Console.WriteLine("File already Exixts");
            }
            if(!File.Exists("OnlineMedicalStore/OrderDetail.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("OnlineMedicalStore/OrderDetail.csv").Close();
            }
            else
            {
                Console.WriteLine("File already Exixts");
            }
            if(!File.Exists("OnlineMedicalStore/MedicalDetail.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("OnlineMedicalStore/MedicalDetail.csv").Close();
            }
            else
            {
                Console.WriteLine("File already Exixts");
            }
        }

        public static void WriteToCSV()
        {
            string[] user = new string[Operations.userDetailsList.Count];
            for(int i=0;i< Operations.userDetailsList.Count;i++)
            {
                user[i]=Operations.userDetailsList[i].UserID+","+Operations.userDetailsList[i].UserName+","+Operations.userDetailsList[i].Age+","+Operations.userDetailsList[i].City+","+Operations.userDetailsList[i].Phone+","+Operations.userDetailsList[i].Balance;
            } 
            File.WriteAllLines("OnlineMedicalStore/UserDetail.csv",user);

            string[] order = new string [Operations.orderDetailsList.Count];
            for(int i =0;i< Operations.orderDetailsList.Count;i++)
            {
                order[i] = Operations.orderDetailsList[i].OrderID+","+Operations.orderDetailsList[i].UserID+","+Operations.orderDetailsList[i].MedicalID+","+Operations.orderDetailsList[i].MedicineCount+","+Operations.orderDetailsList[i].TotalPrice+","+Operations.orderDetailsList[i].OrderDate+","+Operations.orderDetailsList[i].OrderStatus;
            }
            File.WriteAllLines("OnlineMedicalStore/OrderDetail.csv",order);

            string [] medical = new string[Operations.medicalDetailsList.Count];
            for(int i=0;i<Operations.medicalDetailsList.Count;i++)
            {
                medical[i] = Operations.medicalDetailsList[i].MedicalID+","+Operations.medicalDetailsList[i].MedicineName+","+Operations.medicalDetailsList[i].AvailableCount+","+Operations.medicalDetailsList[i].Price+","+Operations.medicalDetailsList[i].DateOfExpiry;
            }
            File.WriteAllLines("OnlineMedicalStore/MedicalDetail.csv",medical);
        }

        public static void ReadToCSV()
        {
            string[] user = File.ReadAllLines("OnlineMedicalStore/UserDetail.csv");
            foreach(string user1 in user)
            {
                UserDetail user2 = new UserDetail(user1);
                Operations.userDetailsList.Add(user2);
            }

            string[] order = File.ReadAllLines("OnlineMedicalStore/OrderDetail.csv");
            foreach(string order1 in order)
            {
                OrderDetail order2 = new OrderDetail(order1);
                Operations.orderDetailsList.Add(order2);
            }

            string[] medical = File.ReadAllLines("OnlineMedicalStore/MedicalDetail.csv");
            foreach(string medical1 in medical)
            {
                MedicalDetail medical2 = new MedicalDetail(medical1);
                Operations.medicalDetailsList.Add(medical2);
            }


        }
    }
}