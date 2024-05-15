using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Transactions;

namespace ECommerceApplication
{
    public class Operation
    {

        public static CustomList<CustomerDetails> customerDetailList = new CustomList<CustomerDetails>();
        public static CustomList<OrderDetails> orderDetailList = new CustomList<OrderDetails>();
        public static CustomList<ProductDetails> productDetailList = new CustomList<ProductDetails>();


        static CustomerDetails currentCustomer;


        public static void AddDefaultDatas()
        {
            CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", 9885858588, 50000, "ravi@mail");
            customerDetailList.Add(customer1);
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", 9888475757, 60000, "baskaran@mail");
            customerDetailList.Add(customer2);

            Console.WriteLine("DEFAULT DATAS FOR CUSTOMER DETAILS");
            foreach (CustomerDetails customer in customerDetailList)
            {
                Console.WriteLine($"|  {customer.CustomerID,-10}  |  {customer.CustomerName,-15}  |  {customer.City,-15}  |  {customer.Phone,-10}  |  {customer.WalletBalance,-10}  |  {customer.MailID,-15}");
            }


            ProductDetails product1 = new ProductDetails("Mobile (Samsung)", 10, 10000, 3);
            productDetailList.Add(product1);
            ProductDetails product2 = new ProductDetails("Tablet (Lenova)", 5, 15000, 2);
            productDetailList.Add(product2);
            ProductDetails product3 = new ProductDetails("Camera (Sony)", 3, 10000, 4);
            productDetailList.Add(product3);
            ProductDetails product4 = new ProductDetails("iPhone", 5, 10000, 6);
            productDetailList.Add(product4);
            ProductDetails product5 = new ProductDetails("Laptop (Lenova 13)", 3, 10000, 3);
            productDetailList.Add(product5);
            ProductDetails product6 = new ProductDetails("HeadPhone (Boat)", 5, 10000, 2);
            productDetailList.Add(product6);
            ProductDetails product7 = new ProductDetails("Speaker (Boat)", 4, 10000, 2);
            productDetailList.Add(product7);

            Console.WriteLine("DEFAULT DATAS FOR PRODUCT DETAILS");
            foreach (ProductDetails product in productDetailList)
            {
                Console.WriteLine($"|  {product.ProductID,-10}  |  {product.ProductName,-20}  |  {product.Stock,-10}  |  {product.Price,-10}  |  {product.ShippingDuration,-10}");
            }


            OrderDetails order1 = new OrderDetails("CID1001", "PID2001", 2000, DateTime.Now, 2, OrderStatus.Ordered);
            orderDetailList.Add(order1);
            OrderDetails order2 = new OrderDetails("CID1002", "PID2002", 2000, DateTime.Now, 2, OrderStatus.Ordered);
            orderDetailList.Add(order2);

            Console.WriteLine("DEFAULT DATAS FOR ORDER DETAILS");
            foreach (OrderDetails order in orderDetailList)
            {
                Console.WriteLine($"|  {order.CustomerID,-10}  |  {order.ProductID,-10}  |  {order.TotalPrice,-10}  |  {order.PurchaseDate,-10}  |  {order.Quantity,-10}  |  {order.OrderStatus,-10}");
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("\n\t\t\tCUSTOMER REGISTRATION\t\t\t");
            int choice;
            bool flag = true;

            do
            {
                Console.Write("\t\t\t\tSYNC CART\t\t\t\t");
                Console.Write("E-Commerce Application for Buying Consumer Electronics Products");
                Console.WriteLine("\n1.Registration\n2.Login\n3.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Exit();
                            flag = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            } while (flag);
        }
        public static void Registration()
        {
            Console.WriteLine("Customer Registration ");
            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter City name: ");
            string city = Console.ReadLine();
            Console.Write("Enter Mobile Number: ");
            long phone = long.Parse(Console.ReadLine());
            Console.Write("Enter your wallet balance: ");
            double walletBalance = double.Parse(Console.ReadLine());
            Console.Write("Enter Email ID: ");
            string mailID = Console.ReadLine();

            CustomerDetails customer = new CustomerDetails(customerName, city, phone, walletBalance, mailID);
            customerDetailList.Add(customer);
            Console.WriteLine("Your registered Customer ID is " + customer.CustomerID);
        }

        public static void Login()
        {
            //	If the customer selects 2 from main menu, Login option will be selected.
            Console.Write("Enter your LoginID: ");
            string loginID = Console.ReadLine();
            //Get the CustomerID and validate the CustomerID.
            bool flag = true;
            foreach (CustomerDetails customer in customerDetailList)
            {
                if (customer.CustomerID == loginID)
                {
                    Console.WriteLine("Login Successful..!!");
                    flag = false;
                    currentCustomer = customer;
                    //Else the following sub menu option “a to e” shown.
                    SubMenu();
                    break;

                }
            }
            //If the CustomerID doesn’t match, show “Invalid customerID”. 
            if (flag)
            {
                Console.WriteLine("Invalid CustomerID");
            }


        }
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                Console.WriteLine("1.Purchase\n2.OrderHistory\n3.CancelOrder\n4.WalletBalance\n5.WalletRecharge\n6.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Purchase();
                            break;
                        }
                    case 2:
                        {
                            OrderHistory();
                            break;
                        }
                    case 3:
                        {
                            CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            WalletBalance();
                            break;
                        }
                    case 5:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 6:
                        {
                            flag = false;
                            Exit();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (flag);
        }
        public static void Purchase()
        {
            foreach (ProductDetails product in productDetailList)
            {
                Console.WriteLine($"|  {product.ProductID,-10}  |  {product.ProductName,-15}  |  {product.Stock,-10}  |  {product.Price,-10}  |  {product.ShippingDuration,-10}");
            }
            Console.Write("Enter the Product ID: ");
            string productID = Console.ReadLine().ToUpper();
            bool flag = true;

            foreach (ProductDetails product in productDetailList)
            {
                if (productID == product.ProductID)
                {
                    flag = false;
                    Console.WriteLine("Enter the No of product need to purchase: ");
                    int noOfProduct = int.Parse(Console.ReadLine());
                    double deliveryCharge = 50.0;

                    if (noOfProduct <= product.Stock)
                    {
                        double totalPrice = (noOfProduct * product.Price) + deliveryCharge;

                        if (totalPrice <= currentCustomer.WalletBalance)
                        {

                            currentCustomer.DeductBalance(totalPrice);
                            product.Stock += noOfProduct;
                            OrderDetails ordered = new OrderDetails(currentCustomer.CustomerID, productID, totalPrice, DateTime.Now, noOfProduct, OrderStatus.Ordered);
                            orderDetailList.Add(ordered);
                            Console.WriteLine($"Order placed Successfully. Order ID is {ordered.OrderID} \n Your Product will be delivered on {ordered.PurchaseDate.AddDays(product.ShippingDuration)}");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Wallet Balance.Please recharge your wallet and do purchase again");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Required count not available");
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid Product ID");
            }

        }

        public static void OrderHistory()
        {
            foreach (OrderDetails order in orderDetailList)
            {
                if (currentCustomer.CustomerID == order.OrderID)
                {
                    Console.Write($"| {order.OrderID,-10}  |  {order.CustomerID,-10}  |  {order.ProductID,-10}  |  {order.TotalPrice,-10}  |  {order.PurchaseDate,-15}  |  {order.Quantity,-10}  |  {order.OrderStatus,-10}");
                }
            }
        }
        public static void CancelOrder()
        {
            bool flag = true;
            foreach (OrderDetails order in orderDetailList)
            {
                if (currentCustomer.CustomerID == order.OrderID)
                {
                    flag = false;
                    Console.Write($"| {order.OrderID,-10}  |  {order.CustomerID,-10}  |  {order.ProductID,-10}  |  {order.TotalPrice,-10}  |  {order.PurchaseDate,-15}  |  {order.Quantity,-10}  |  {order.OrderStatus,-10}");
                }
            }
            if (flag)
            {
                Console.WriteLine("NO order placed");
            }
            if (!flag)
            {
                Console.WriteLine("Enter the OrderID to cancel the order: ");
                string orderID = Console.ReadLine().ToUpper();

                bool flag1 = true;
                foreach (OrderDetails order in orderDetailList)
                {
                    if (orderID == order.OrderID && currentCustomer.CustomerID == order.CustomerID && order.OrderStatus == OrderStatus.Ordered)
                    {
                        foreach (ProductDetails product in productDetailList)
                        {
                            if (product.ProductID == order.ProductID)
                            {
                                flag1 = false;
                                product.Stock = product.Stock + order.Quantity;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Product ID");
                            }
                        }
                        order.OrderStatus = OrderStatus.Cancelled;
                        Console.WriteLine($"Order: {order.OrderID} Cancelled successfully");
                    }

                }
                if (flag1)
                {
                    Console.WriteLine("Invalid orderID");
                }
            }
        }

        public static void WalletBalance()
        {
            Console.WriteLine("Your Current wallet Balance is :" + currentCustomer.WalletBalance);
        }
        public static void WalletRecharge()
        {
            //1.Ask the customer whether he wish to recharge the wallet. 
            Console.WriteLine("Are you wish to recharge the wallet: ");
            string answer = Console.ReadLine();
            if (answer == "Yes")
            {
                Console.WriteLine("Enter the amount to recharge: ");
                int rechargeAmount = int.Parse(Console.ReadLine());
                if (rechargeAmount > 0)
                {
                    currentCustomer.WalletRecharge1(rechargeAmount);
                }
                else
                {
                    Console.WriteLine("Please enter valid amount to recharge");
                }
            }
            else
            {
                Console.WriteLine("Enter valid update");
            }
        }
        public static void Exit()
        {
            Console.WriteLine("EXIT");
        }
    }
}