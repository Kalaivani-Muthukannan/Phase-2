using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public enum OrderStatus
    {
        Default, Ordered, Cancelled
    }
    public class OrderDetails
    {
        private static int s_orderID = 1000;
        public string OrderID { get; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }



        //parameterized constructor
        public OrderDetails(string customerID, string productID, double totalPrice, DateTime purchaseDate, int quantity, OrderStatus orderStatus)
        {
            s_orderID++;
            OrderID = "OID" + s_orderID;
            CustomerID = customerID;
            ProductID = productID;
            TotalPrice = totalPrice;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            OrderStatus = orderStatus;
        }

        public OrderDetails(string order1)
        {
            string [] values = order1.Split(",");
            s_orderID = int.Parse(values[0].Remove(0,3));
            OrderID = values[0];
            CustomerID = values[1];
            ProductID = values[2];
            TotalPrice = int.Parse(values[3]);
            PurchaseDate = DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
            Quantity = int.Parse(values[5]);
            OrderStatus = Enum.Parse<OrderStatus>(values[6]);
        }
    }
}