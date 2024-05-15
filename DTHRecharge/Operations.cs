using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DTHRecharge
{
    public class Operations
    {
        static List<UserRegistration> userRegistrationsList = new List<UserRegistration>();
        static List<PackDetails> packDetailsList = new List<PackDetails>();
        static List<RechargeHistory> rechargeHistoryList = new List<RechargeHistory>();

        static UserRegistration currentUser;
        public static void AddDefaultData()
        {
            PackDetails pack1 = new PackDetails("Pack1", 150, 28, 50);
            packDetailsList.Add(pack1);
            PackDetails pack2 = new PackDetails("Pack2", 300, 56, 75);
            packDetailsList.Add(pack2);
            PackDetails pack3 = new PackDetails("Pack3", 500, 28, 200);
            packDetailsList.Add(pack3);
            PackDetails pack4 = new PackDetails("Pack4", 1500, 365, 200);
            packDetailsList.Add(pack4);

            foreach (PackDetails pack in packDetailsList)
            {
                Console.WriteLine($"|  {pack.PackID,-10}  |  {pack.PackName,-15}  | {pack.Price,-10}  |  {pack.Validity,-10}  |  {pack.NoOfChannels,-10}");
            }

            UserRegistration register1 = new UserRegistration("John", 9746646466, "john@gmail.com", 500);
            userRegistrationsList.Add(register1);
            UserRegistration register2 = new UserRegistration("Merlin", 9782136543, "merlin@gmail.com", 150);
            userRegistrationsList.Add(register2);

            foreach (UserRegistration register in userRegistrationsList)
            {
                Console.WriteLine($" {register.UserName,-15}  |  {register.Phone,-10}  |  {register.MailID,-15}  |  {register.WalletBalance,-10}");
            }


            RechargeHistory recharge1 = new RechargeHistory("UID1001", "RC150", new DateTime(30 / 11 / 2021), 150, new DateTime(27 / 12 / 2021), 50);
            rechargeHistoryList.Add(recharge1);
            RechargeHistory recharge2 = new RechargeHistory("UID1001", "RC150", new DateTime(30 / 11 / 2021), 150, new DateTime(27 / 12 / 2021), 50);
            rechargeHistoryList.Add(recharge2);

            foreach (RechargeHistory history in rechargeHistoryList)
            {
                Console.WriteLine($"{history.RechargeID}  {history.UserID}  |  {history.PackID}  |  {history.RechargeDate}  |  {history.RechargeAmount}  |  {history.ValidTill}  |  {history.NoOfChannels}");
            }

        }

        public static void MainMenu()
        {
            Console.WriteLine("\n\t\t\tDTH REGISTRATION\t\t\t");
            int choice;
            bool flag = true;

            do
            {
                Console.Write("\t\t\tApplication for Online DTH");
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
            //UserName
            //Mobile Number
            //Mail ID
            //Wallet Balance

            Console.WriteLine("USER REGISTRATION");
            Console.WriteLine("Enter User name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter Mobile Number: ");
            long phone = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter MailID: ");
            string mailID = Console.ReadLine();
            Console.WriteLine("Enter your Wallet Balance: ");
            double walletBalance = double.Parse(Console.ReadLine());

            UserRegistration user = new UserRegistration(userName, phone, mailID, walletBalance);
            userRegistrationsList.Add(user);
            Console.WriteLine("Your registered User ID is " + user.UserID);
        }

        public static void Login()
        {
            Console.WriteLine("Enter your UserID: ");
            string userID = Console.ReadLine();
            bool flag = true;
            foreach (UserRegistration user in userRegistrationsList)
            {
                if (userID == user.UserID)
                {
                    Console.WriteLine("Login Successfull!");
                    flag = false;
                    currentUser = user;
                    Submenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid UserID");
            }

        }
        public static void Submenu()
        {
            bool flag = true;
            do
            {
                Console.WriteLine("1.Current Pack\n2.Pack Recharge\n3.Wallet Recharge\n4.View Pack Recharge History\n5.Show Wallet Balance\n6.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            CurrentPack();
                            break;
                        }
                    case 2:
                        {
                            PackRecharge();
                            break;
                        }
                    case 3:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 4:
                        {
                            ViewPackRechargeHistory();
                            break;
                        }
                    case 5:
                        {
                            ShowWalletBalance();
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
        public static void CurrentPack()
        {
            Console.WriteLine("CurrentPack");
            //Displays recent pack detail of current user (User ID, Pack ID, Recharge Amount, Valid Till, Number of channels)
            bool flag = true;
            foreach (RechargeHistory recharge in rechargeHistoryList)
            {
                if (DateTime.Today <= recharge.ValidTill)
                {
                    if (currentUser.UserID == recharge.UserID)
                    {
                        flag = false;
                        Console.WriteLine($"  {recharge.UserID}  |  {recharge.PackID}  |  {recharge.RechargeAmount}  |  {recharge.ValidTill.ToString("yyyy/MM/dd")}  |  {recharge.NoOfChannels}");
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid validity entered");
            }

        }
        public static void PackRecharge()
        {
            //List the available pack details and ask the user to choose a pack and recharge.
            foreach (PackDetails pack in packDetailsList)
            {
                Console.WriteLine($"|  {pack.PackID,-10}  |  {pack.PackName,-15}  | {pack.Price,-10}  |  {pack.Validity,-10}  |  {pack.NoOfChannels,-10}");
            }
            Console.WriteLine("Choose the pack to recharge: ");
            string packID = Console.ReadLine();
            bool flag = true;
            DateTime tempdate = DateTime.Now;
            foreach (PackDetails pack1 in packDetailsList)
            {
                //Based on the pack choose, check the wallet balance.
                //If the user has sufficient balance, then permit and do recharge.
                if (packID == pack1.PackID && currentUser.WalletBalance >= pack1.Price)
                {
                    flag = false;

                    foreach (RechargeHistory recharge in rechargeHistoryList)
                    {
                        if (recharge.UserID == currentUser.UserID)
                        {
                            tempdate = recharge.ValidTill;
                        }
                    }
                    
                    
                    DateTime date = DateTime.Today;
                    DateTime validityDate = DateTime.Today;
                    int validTill = pack1.Validity;
                    
                    //If pack ends today. recharge tomorrow
                    if (tempdate == DateTime.Today)
                    {
                       date = DateTime.Today.AddDays(1);
                       validityDate = date.AddDays(validTill);
                    }
                    // if pack ends next month
                    else if (tempdate > DateTime.Today)
                    {
                        date = tempdate.AddDays(1);
                        validityDate = date.AddDays(validTill);

                    }
                    // if the pack ends yesterday, recharge today
                    else if (tempdate < DateTime.Today)
                    {
                        date = DateTime.Today;
                        validityDate = date.AddDays(validTill);
                        // RechargeHistory history = new RechargeHistory(currentUser.UserID, packID, date2, pack1.Price, date2.AddDays(pack1.Validity), pack1.NoOfChannels);
                        // rechargeHistoryList.Add(history);
                        
                    }
                    RechargeHistory history = new RechargeHistory(currentUser.UserID, packID, date, pack1.Price, validityDate, pack1.NoOfChannels);
                    rechargeHistoryList.Add(history);
                }
                else
                {
                    //If insufficient balance in wallet, ask them to recharge his wallet.
                    Console.WriteLine("Insufficient Balance in your Wallet. Recharge your wallet and recharge pack");
                    break;
                }
                
            }
             
             if (flag)
            {
                Console.WriteLine("Invalid Pack Recharge");
            }
        }
        
        
        public static void WalletRecharge()
        {
            //Ask for the amount to be recharged from the user and update the wallet balance.

            Console.WriteLine("Are you sure that you want to recharge: ");
            string choice = Console.ReadLine().ToUpper();

            if(choice == "Yes")
            {
            Console.WriteLine("Enter the amount to Recharge your Wallet: ");
            double rechargeAmount = double.Parse(Console.ReadLine());
                if(rechargeAmount > 0)
                {
                double walletBalance = currentUser.WalletBalance + rechargeAmount;
                Console.WriteLine("Your Wallet Balance is " + walletBalance);
                }
                else
                {
                    Console.WriteLine("Enter valid amount to recharge");
                }
            }
        }
        public static void ViewPackRechargeHistory()
        {
            //List the history of recharge details of current user (UserID, PackID, Recharge Amount, Valid Till)
            bool flag = true;
            foreach (RechargeHistory history in rechargeHistoryList)
            {
                if (currentUser.UserID == history.UserID)
                {
                    flag = false;
                    Console.WriteLine($"|  {history.UserID}  |  {history.PackID}  |  {history.RechargeAmount}  |  {history.ValidTill}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No pack History found");
            }
        }
        public static void ShowWalletBalance()
        {
            Console.WriteLine($" Your Current wallet Balance is " + currentUser.WalletBalance);
        }
        public static void Exit()
        {
            Console.WriteLine("Exit");
        }

    }
}