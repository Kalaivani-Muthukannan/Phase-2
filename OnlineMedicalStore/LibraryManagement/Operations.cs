using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Transactions;

namespace LibraryManagement
{
    public class Operations
    {
        static List<UserDetails> userDetailsList = new List<UserDetails>();
        static List<BookDetails> bookDetailsList = new List<BookDetails>();
        static List<BorrowDetails> borrowDetailsList = new List<BorrowDetails>();

        static UserDetails currentUser;

        public static void AddDefaultDatas()
        {
            UserDetails user1 = new UserDetails("Ravichandran", Gender.Male, Department.EEE, 9938388333, "ravi@gmail.com", 100);
            userDetailsList.Add(user1);
            UserDetails user2 = new UserDetails("PriyaDharshini", Gender.Female, Department.CSE, 9944444455, "priya@gmail.com", 105);
            userDetailsList.Add(user2);

            foreach (UserDetails user in userDetailsList)
            {
                Console.WriteLine($"{user.UserID,-10}  |  {user.UserName,-15}  |  {user.Gender,-15}  |  {user.Department,-10}  |  {user.Phone,-15}  |  {user.WalletBalance,-10}");
            }

            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            bookDetailsList.Add(book1);

            BookDetails book2 = new BookDetails("HTML", "Author2", 5);
            bookDetailsList.Add(book2);

            BookDetails book3 = new BookDetails("CSS", "Author1", 3);
            bookDetailsList.Add(book3);

            BookDetails book4 = new BookDetails("JS", "Author1", 3);
            bookDetailsList.Add(book4);

            BookDetails book5 = new BookDetails("TS", "Author3", 2);
            bookDetailsList.Add(book5);

            foreach (BookDetails book in bookDetailsList)
            {
                Console.WriteLine($"{book.BookID,-15}  |  {book.BookName,-15}  |  {book.AuthorName,-10}  |  {book.BookCount,-10}");

            }
            BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", new DateTime(2023, 09, 10), 2, Status.Borrowed, 0);
            borrowDetailsList.Add(borrow1);

            BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", new DateTime(2023, 09, 12), 1, Status.Borrowed, 0);
            borrowDetailsList.Add(borrow2);

            BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", new DateTime(2023, 09, 14), 1, Status.Returned, 16);
            borrowDetailsList.Add(borrow3);

            BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", new DateTime(2024, 04, 11), 2, Status.Borrowed, 0);
            borrowDetailsList.Add(borrow4);

            BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", new DateTime(2023, 09, 09), 1, Status.Returned, 20);
            borrowDetailsList.Add(borrow5);

            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                Console.WriteLine($"|  {borrow.BorrowID,-10}  |  {borrow.BookID,-10}   |   {borrow.UserID}    |  {borrow.BorrowedDate,-15}  |  {borrow.BorrowedBookCount,-10}  |  {borrow.Status,-15}  |  {borrow.PaidFineAmount,-10}");
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("\n\t\t\tSYNCFUSION LIBRARY\t\t\t");
            Console.WriteLine("Online Library Management");
            int choice;
            bool flag = true;

            do
            {
                Console.WriteLine("\n1.Registration\n2.Login\n3.Exit");
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
            Console.WriteLine("User Registration");

            Console.Write("Enter the user Name: ");
            string userName = Console.ReadLine();

            Console.Write("Enter Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            Console.Write("Enter the Department: ");
            Department department = Enum.Parse<Department>(Console.ReadLine(), true);

            Console.Write("Enter the Mobile Number: ");
            long phone = long.Parse(Console.ReadLine());

            Console.Write("Enter the MailID: ");
            string mailID = Console.ReadLine();

            Console.Write("Enter the walletBalance: ");
            double walletBalance = double.Parse(Console.ReadLine());

            UserDetails details = new UserDetails(userName, gender, department, phone, mailID, walletBalance);
            userDetailsList.Add(details);

            Console.WriteLine("Registration Successfull and your User ID is " + details.UserID);

        }

        public static void UserLogin()
        {
            Console.WriteLine("Enter the Login ID:");
            string loginID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (UserDetails user in userDetailsList)
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
                //Console.WriteLine("Submenu");
                Console.WriteLine("1.Borrow Book\n2.Show Borrowed History\n3.Return Book\n4.Wallet Recharge\n5.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            BorrowBook();
                            break;
                        }
                    case 2:
                        {
                            ShowBorrowedHistory();
                            break;
                        }
                    case 3:
                        {
                            ReturnBook();
                            break;
                        }
                    case 4:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 5:
                        {
                            flag = false;
                            Console.WriteLine("Check");
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (flag);
        }

        public static void BorrowBook()
        {
            foreach (BookDetails book in bookDetailsList)
            {
                Console.WriteLine($"|  {book.BookID,-10}  |  {book.BookName,-15}  |  {book.AuthorName,-15}  |  {book.BookCount,-10}  ");
            }

            Console.Write("Enter the book ID to borrow: ");
            string bookID = Console.ReadLine();

            bool flag = true;
            foreach (BookDetails detail in bookDetailsList)
            {
                if (bookID == detail.BookID)
                {
                    flag = false;
                    Console.Write("Count: ");
                    int count = int.Parse(Console.ReadLine());

                    if (count <= detail.BookCount)
                    {
                        int tempcount = 0;
                        foreach (BorrowDetails borrow in borrowDetailsList)
                        {
                            if (currentUser.UserID == borrow.UserID && borrow.Status == Status.Borrowed)
                            {
                                tempcount = count + borrow.BorrowedBookCount;
                            }
                        }
                        if (count <= 3)
                        {
                            if (count + tempcount <= 3)
                            {
                                BorrowDetails borrow1 = new BorrowDetails(bookID, currentUser.UserID, DateTime.Now, count, Status.Borrowed, 0);
                                borrowDetailsList.Add(borrow1);
                                detail.BookCount = detail.BookCount - count;
                                Console.WriteLine("Book borrowed successfully");
                            }
                            else
                            {
                                Console.WriteLine($"You already borrowed books count is {tempcount} and requested count is {count}, which exceeds 3");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have borrowed 3 books already");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Books are not availble for selected count.");
                        foreach (BorrowDetails borrow in borrowDetailsList)
                        {
                            if (bookID == borrow.BookID && borrow.Status == Status.Borrowed)
                            {
                                DateTime avaiDate = borrow.BorrowedDate.AddDays(15);
                                Console.WriteLine("The book not avaiable currently. The book will available on " + borrow.BorrowedDate.AddDays(15).ToString("yyyy/MM/dd"));
                                break;
                            }
                        }
                    }
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid");
            }
        }

        public static void ShowBorrowedHistory()
        {
            bool flag = true;
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                if (currentUser.UserID == borrow.UserID)
                {
                    flag = false;
                    Console.WriteLine($"{borrow.UserID}  |  {borrow.BookID}  |  {borrow.BorrowedDate}  |  {borrow.BorrowedBookCount}  |  {borrow.Status}  |  {borrow.PaidFineAmount}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No order borrowed");
            }

        }

        public static void ReturnBook()
        {
            bool flag = true;
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                if (currentUser.UserID == borrow.UserID && borrow.Status == Status.Borrowed)
                {
                    flag = false;
                    Console.WriteLine($"  {borrow.BorrowID}  |  {borrow.UserID}  |  {borrow.BookID}  |  {borrow.BorrowedDate}  |  {borrow.BorrowedBookCount}  |  {borrow.Status}  |  {borrow.PaidFineAmount}");
                }
            }
            if (flag)
            {
                Console.WriteLine("No book borrowed");
            }
            if (!flag)
            {
                Console.WriteLine("Enter the borrow ID to return: ");
                string borrowID = Console.ReadLine();

                foreach (BorrowDetails borrow in borrowDetailsList)
                {
                    if (borrow.BorrowID == borrowID && currentUser.UserID == borrow.UserID)
                    {
                        //Console.WriteLine(borrow.BorrowedDate.AddDays(15).ToString("yyyy/MM/dd"));
                        //DateTime day = borrow.BorrowedDate.AddDays(15);
                        DateTime calculateDays = borrow.BorrowedDate.AddDays(15);


                        if (calculateDays < DateTime.Today)
                        {
                            int daysToCalculate = (DateTime.Today - borrow.BorrowedDate).Days;
                            int totalFineAmount = (1 * daysToCalculate) - 15;
                            Console.WriteLine("Fine Amount: " + totalFineAmount);

                            Console.WriteLine("Enter the Book Id to return: ");
                            string bookID = Console.ReadLine().ToUpper();

                            if (totalFineAmount <= currentUser.WalletBalance)
                            {
                                currentUser.WalletBalance = currentUser.WalletBalance - totalFineAmount;
                                borrow.Status = Status.Returned;
                                borrow.PaidFineAmount = totalFineAmount;
                                foreach (BookDetails book in bookDetailsList)
                                {
                                    if (book.BookID == borrow.BookID)
                                    {
                                        book.BookCount = book.BookCount + borrow.BorrowedBookCount;
                                    }
                                }
                                Console.WriteLine("Book returned Successfully");
                            }
                            else
                            {
                                Console.Write("Insufficient balance. Please recharge and proceed");
                            }
                        }
                        else
                        {
                            borrow.Status = Status.Borrowed;
                            foreach (BookDetails details in bookDetailsList)
                            {
                                if (details.BookID == borrow.BookID)
                                {
                                    details.BookCount = details.BookCount + borrow.BorrowedBookCount;
                                }
                            }
                            Console.WriteLine("Book returned Successfully");

                        }
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Invalid");
                }
            }
        }

        public static void WalletRecharge()
        {
            Console.WriteLine("Are you sure that you want to update: ");
            string choice = Console.ReadLine();
            if (choice == "Yes")
            {
                Console.WriteLine("Enter the amount to recharge: ");
                int rechargeAmount = int.Parse(Console.ReadLine());
                if (rechargeAmount > 0)
                {
                    currentUser.WalletRecharge1(rechargeAmount);
                }
                else
                {
                    Console.WriteLine("Invalid Recharge Amount");
                }
            }
        }

        public static void Exit()
        {
            Console.WriteLine("EXIT");
        }
    }
}