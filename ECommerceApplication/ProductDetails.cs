using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public class ProductDetails
    {
        private static  int s_productID = 2000;
        public string ProductID { get; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int ShippingDuration { get; set; }

        //Parameterized Constructor

        public ProductDetails(string productName, int stock, double price,int shippingDuration)
        {
            s_productID++;
            ProductID = "PID" + s_productID;
            ProductName = productName;
            Stock =stock;
            Price = price;
            ShippingDuration = shippingDuration;

        }

        public ProductDetails(string product1)
        {
            string [] values = product1.Split(",");
            s_productID = int.Parse(values[0].Remove(0,3));
            ProductID = values[0];
            ProductName = values[1];
            Stock =int.Parse(values[2]);
            Price = double.Parse(values[3]);
            ShippingDuration = int.Parse(values[4]);

        }
        
    }
}