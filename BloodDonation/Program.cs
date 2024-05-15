using System;
namespace BloodDonation;
class Program
{
    public static void Main(string[] args)
    {
        FileHandling.Create();
        //Operations.AddDefaultDatas();
        FileHandling.ReadToCSV();
        Operations.MainMenu();
        FileHandling.WriteToCSV();
    }
}