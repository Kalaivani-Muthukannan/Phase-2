using System;
namespace ECommerceApplication;
class Program
{
    public static void Main(string[] args)
    {
       
        FileHandling.Create();
        //Operation.AddDefaultDatas();
        FileHandling.ReadFromCSV();
        Operation.MainMenu();
        FileHandling.WriteToCSV();
    }
}
