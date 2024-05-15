using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class Operations
    {
        public static CustomList<UserDetail> userDetailsList = new CustomList<UserDetail>();
        public static CustomList<OrderDetail> orderDetailsList = new CustomList<OrderDetail>();
        public static CustomList<MedicalDetail> medicalDetailsList = new CustomList<MedicalDetail>();
        static UserDetail currentUser;
        public static void AddDefaultData()

        {
            UserDetail user1 = new UserDetail("Ravi", 33, "Theni", 9877774440, 400);
            userDetailsList.Add(user1);
            UserDetail user2 = new UserDetail("Baskaran", 33, "Chennai", 8847757470, 500);
            userDetailsList.Add(user2);

            foreach (UserDetail usern in userDetailsList)
            {
                Console.WriteLine($"|  {usern.UserID,-10}  |  {usern.UserName,-15}  |  {usern.Age,-10}  |   {usern.City,-15}  |  {usern.Phone,-15}   |  {usern.Balance,-10}");
            }

            MedicalDetail medicine1 = new MedicalDetail("Paracitamol", 40, 5, new DateTime(2023, 12, 30));
            medicalDetailsList.Add(medicine1);
            MedicalDetail medicine2 = new MedicalDetail("Calpol", 10, 5, new DateTime(2023, 11, 30));
            medicalDetailsList.Add(medicine2);
            MedicalDetail medicine3 = new MedicalDetail("Gelucil", 3, 40, new DateTime(2024, 04, 30));
            medicalDetailsList.Add(medicine3);
            MedicalDetail medicine4 = new MedicalDetail("Metrogel", 5, 50, new DateTime(2024, 12, 30));
            medicalDetailsList.Add(medicine4);
            MedicalDetail medicine5 = new MedicalDetail("Povidin Iodin", 10, 50, new DateTime(2026, 10, 30));
            medicalDetailsList.Add(medicine5);

            foreach (MedicalDetail medical in medicalDetailsList)
            {
                Console.WriteLine($"|  {medical.MedicalID,-10}  |  {medical.MedicineName,-15}  |  {medical.AvailableCount,-15}  |  {medical.Price,-10}  |  {medical.DateOfExpiry,-10}");
            }

            OrderDetail order1 = new OrderDetail("UID1001", "MD2001", 3, 15, new DateTime(2023, 11, 13), OrderStatus.Purchased);
            orderDetailsList.Add(order1);
            OrderDetail order2 = new OrderDetail("UID1001", "MD2002", 2, 10, new DateTime(2023, 11, 13), OrderStatus.Cancelled);
            orderDetailsList.Add(order2);
            OrderDetail order3 = new OrderDetail("UID1001", "MD2003", 2, 100, new DateTime(2023, 11, 13), OrderStatus.Purchased);
            orderDetailsList.Add(order3);
            OrderDetail order4 = new OrderDetail("UID1002", "MD2004", 3, 120, new DateTime(2023, 11, 15), OrderStatus.Cancelled);
            orderDetailsList.Add(order4);
            OrderDetail order5 = new OrderDetail("UID1002", "MD2005", 5, 150, new DateTime(2023, 11, 15), OrderStatus.Purchased);
            orderDetailsList.Add(order5);
            OrderDetail order6 = new OrderDetail("UID1002", "MD2007", 3, 15, new DateTime(2023, 11, 15), OrderStatus.Purchased);
            orderDetailsList.Add(order6);

            foreach (OrderDetail order in orderDetailsList)
            {
                Console.WriteLine($"|  {order.OrderID,-10}  |  {order.UserID,-10}  |  {order.MedicalID,-10}  |  {order.MedicineCount,-10}  |  {order.TotalPrice,-10}  |  {order.OrderDate,-15}  |  {order.OrderStatus,-15}");
            }
        }
        public static void MainMenu()
        {
            Console.WriteLine("\n\t\t\t ONLINE MEDICINE PURCHASE \t\t\t");
            int choice;
            bool flag = true;

            do
            {
                Console.WriteLine("\n1.User Registration\n2.User Login\n3.Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            UserLogin();
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

        public static void UserRegistration()
        {
            Console.WriteLine("USER REGISTRATION");
            Console.Write("Enter the user name: ");
            string userName = Console.ReadLine();

            Console.Write("Enter the user Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter the user City name: ");
            string city = Console.ReadLine();

            Console.Write("Enter the user Phone number: ");
            long phone = long.Parse(Console.ReadLine());

            Console.Write("Enter the user Balance: ");
            double balance = double.Parse(Console.ReadLine());

            UserDetail user = new UserDetail(userName, age, city, phone, balance);
            userDetailsList.Add(user);

            Console.WriteLine("Registration Successful..!");
            Console.WriteLine("Your Registration ID is " + user.UserID);
        }

        public static void UserLogin()
        {
            Console.WriteLine("Enter the Login ID:");
            string loginID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (UserDetail user in userDetailsList)
            {
                if (user.UserID == loginID)
                {
                    Console.WriteLine("Login Successfull");
                    flag = false;
                    currentUser = user;
                    SubMenu();
                    break;
                }

            }
            if (flag)
            {
                Console.WriteLine("Login unsuccessfull");
            }
        }

        public static void SubMenu()
        {
            bool flag = true;
            do
            {
                Console.WriteLine("1.Show Medicine List\n2.Purchase Medicine\n3.Cancel Purchase\n4.Show Purchase History\n5.Recharge\n6.Show Wallet Balance\n7.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            ShowMedicine();
                            break;
                        }
                    case 2:
                        {
                            PurchaseMedicine();
                            break;
                        }
                    case 3:
                        {
                            CancelPurchase();
                            break;
                        }
                    case 4:
                        {
                            ShowPurchaseHistory();
                            break;
                        }
                    case 5:
                        {
                            Recharge();
                            break;
                        }
                    case 6:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 7:
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

        public static void ShowMedicine()
        {
            Console.WriteLine("Enter the Medical ID: ");
            string medicineID = Console.ReadLine().ToUpper();
            foreach (MedicalDetail detail in medicalDetailsList)
            {
                if (medicineID == detail.MedicalID)
                {
                    Console.WriteLine($"|  {detail.MedicalID,-10}  |  {detail.MedicineName,-15}   |   {detail.AvailableCount,-10}   |   {detail.Price,-10}   |   {detail.DateOfExpiry,-10}");
                    break;
                }
            }
        }
        public static void PurchaseMedicine()
        {
            foreach (MedicalDetail detail in medicalDetailsList)
            {
                Console.WriteLine($"|  {detail.MedicalID,-10}  | {detail.MedicineName,-15}  |  {detail.AvailableCount,-10}  |  {detail.Price,-10}  |  {detail.DateOfExpiry,-10}");
            }
            Console.WriteLine("Enter the Medicine ID: ");
            string medicineID = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter the number you want to buy: ");
            int count = int.Parse(Console.ReadLine());
            bool flag = true;
            foreach (MedicalDetail detail in medicalDetailsList)
            {
                if (medicineID == detail.MedicalID)
                {
                    flag = false;
                    if (count <= detail.AvailableCount)
                    {
                        double totalPrice = count * detail.Price;
                        if (detail.DateOfExpiry > DateTime.Now)
                        {
                            if (detail.Price <= currentUser.Balance)
                            {
                                currentUser.DeductBalance(totalPrice);
                                detail.AvailableCount = detail.AvailableCount - count;

                                OrderDetail order = new OrderDetail(currentUser.UserID, medicineID, count, totalPrice, DateTime.Now, OrderStatus.Purchased);
                                orderDetailsList.Add(order);

                                Console.WriteLine("Order placed successfully..! and your order ID is " + order.OrderID);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThe medicine expired!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The Medicine was expired or not available..!");
                        break;
                    }
                }
            }
            if (flag)
            {
                Console.Write("Invalid Medical ID");
            }
        }
        public static void CancelPurchase()
        {
            bool flag = true;
            foreach (OrderDetail order in orderDetailsList)
            {
                if (currentUser.UserID == order.UserID)
                {
                    flag = false;
                    Console.WriteLine($"|  {order.OrderID,-10}  |  {order.UserID,-10}  |  {order.MedicalID,-10}  |  {order.MedicineCount,-10}  |  {order.TotalPrice,-10}  |  {order.OrderDate}  |  {order.OrderStatus}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No order placed");
            }
            if (!flag)
            {
                Console.WriteLine("Enter the orderID to Cancel order: ");
                string orderID = Console.ReadLine().ToUpper();

                bool flag1 = true;
                foreach (OrderDetail order in orderDetailsList)
                {
                    if (orderID == order.OrderID && currentUser.UserID == order.UserID && order.OrderStatus == OrderStatus.Purchased)
                    {
                        flag1 = false;
                        foreach (MedicalDetail medicine in medicalDetailsList)
                        {
                            medicine.AvailableCount = medicine.AvailableCount + order.MedicineCount;
                        }
                        currentUser.Balance = currentUser.Balance + order.TotalPrice;
                        order.OrderStatus = OrderStatus.Cancelled;
                        Console.WriteLine($"{order.OrderID} was cancelled Successfully.");
                    }
                }
                if (flag1)
                {
                    Console.WriteLine("No purchase undertaken");
                }
            }
        }

        public static void ShowPurchaseHistory()
        {
            bool flag = true;
            foreach (OrderDetail order in orderDetailsList)
            {
                if (currentUser.UserID == order.UserID)
                {
                    flag = false;
                    Console.WriteLine($"|  {order.OrderID,-10}  |  {order.UserID,-10}  |  {order.MedicalID,-10}  |  {order.MedicineCount,-10}  |  {order.TotalPrice,-10}  |  {order.OrderDate}  |  {order.OrderStatus}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No order placed");
            }
        }
        public static void Recharge()
        {
            Console.WriteLine("Are you sure that you want to recharge: ");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Yes")
            {
                Console.WriteLine("Enter the amount to be recharged: ");
                double rechargeamount = int.Parse(Console.ReadLine());

                if (rechargeamount > 0)
                {
                    currentUser.Balance = currentUser.Balance + rechargeamount;
                    Console.WriteLine("The total balance in your Account is " + currentUser.Balance);
                }
                else
                {
                    Console.WriteLine("Invalid recharge Amount");
                }
            }
        }
        public static void ShowWalletBalance()
        {
            Console.WriteLine("Your Current Balance is " + currentUser.Balance);
        }
        public static void Exit()
        {
            Console.WriteLine("EXIT..!");
        }

    }
}