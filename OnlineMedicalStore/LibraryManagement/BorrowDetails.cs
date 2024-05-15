using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public enum Status
    {
        Default, Borrowed, Returned
    }
    public class BorrowDetails
    {
        //BorrowID (Auto Increment – LB2000)
        //BookID 
        //UserID
        //BorrowedDate – ( Current Date and Time )
        //BorrowBookCount 
        //Status –  ( Enum - Default, Borrowed, Returned )
        //PaidFineAmount

        private static int s_BorrowID = 2000;
        public string BorrowID { get; }
        public string BookID { get; set; }
        public string UserID { get; set; }
        public DateTime BorrowedDate { get; set; }
        public int BorrowedBookCount { get; set; }
        public Status Status { get; set; }
        public double PaidFineAmount { get; set; }

        //Parameterized  Constructor

        public BorrowDetails(string bookID, string userID, DateTime borrowedDate, int borrowedBookCount, Status status, double paidFineAmount)
        {
            s_BorrowID++;
            BorrowID = "LB" + s_BorrowID;
            BookID = bookID;
            UserID = userID;
            BorrowedDate = borrowedDate;
            BorrowedBookCount = borrowedBookCount;
            Status = status;
            PaidFineAmount = paidFineAmount;
        }

    }
}