using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("ECommerceApplication"))
            {
                Console.WriteLine("Creating Folder");
                Directory.CreateDirectory("ECommerceApplication");
            }
            if (!File.Exists("ECommerceApplication/CustomerDetails.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("ECommerceApplication/CustomerDetails.csv").Close();
            }
            if (!File.Exists("ECommerceApplication/OrderDetails.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("ECommerceApplication/OrderDetails.csv").Close();
            }
            if (!File.Exists("ECommerceApplication/ProductDetails.csv"))
            {
                Console.WriteLine("Creating File");
                File.Create("ECommerceApplication/ProductDetails.csv").Close();
            }
        }
        public static void WriteToCSV()
        {
            string[] customer = new string[Operation.customerDetailList.Count];
            for (int i = 0; i < Operation.customerDetailList.Count; i++)
            {
                customer[i] = Operation.customerDetailList[i].CustomerID + "," + Operation.customerDetailList[i].CustomerName + "," + Operation.customerDetailList[i].City + "," + Operation.customerDetailList[i].Phone + "," + Operation.customerDetailList[i].WalletBalance + "," + Operation.customerDetailList[i].MailID;
            }
            File.WriteAllLines("ECommerceApplication/CustomerDetails.csv", customer);

            string[] order = new string[Operation.orderDetailList.Count];
            for (int i = 0; i < Operation.orderDetailList.Count; i++)
            {
                order[i] = Operation.orderDetailList[i].OrderID + "," + Operation.orderDetailList[i].CustomerID + "," + Operation.orderDetailList[i].ProductID + "," + Operation.orderDetailList[i].TotalPrice + "," + Operation.orderDetailList[i].PurchaseDate.ToString("dd/MM/yyyy")+ "," + Operation.orderDetailList[i].Quantity + "," + Operation.orderDetailList[i].OrderStatus;
            }
            File.WriteAllLines("ECommerceApplication/OrderDetails.csv", order);

            string[] product = new string[Operation.productDetailList.Count];
            for (int i = 0; i < Operation.productDetailList.Count; i++)
            {
                product[i] = Operation.productDetailList[i].ProductID + "," + Operation.productDetailList[i].ProductName + "," + Operation.productDetailList[i].Stock + "," + Operation.productDetailList[i].Price + "," + Operation.productDetailList[i].ShippingDuration;
            }
            File.WriteAllLines("ECommerceApplication/ProductDetails.csv", product);
        }

        public static void ReadFromCSV()
        {
            string[] customer = File.ReadAllLines("ECommerceApplication/CustomerDetails.csv");
            foreach (string customer1 in customer)
            {
                CustomerDetails customer2 = new CustomerDetails(customer1);
                Operation.customerDetailList.Add(customer2);
            }

            string[] order = File.ReadAllLines("ECommerceApplication/OrderDetails.csv");
            foreach (string order1 in order)
            {
                OrderDetails order2 = new OrderDetails(order1);
                Operation.orderDetailList.Add(order2);
            }

            string[] product = File.ReadAllLines("ECommerceApplication/ProductDetails.csv");
            foreach (string product1 in product)
            {
                ProductDetails product2 = new ProductDetails(product1);
                Operation.productDetailList.Add(product2);
            }
        }
    }
}