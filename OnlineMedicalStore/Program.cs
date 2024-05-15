using System;
namespace OnlineMedicalStore;
class Program
{
    public static void Main(string[] args)
    {
        FileHnadling.Create();
        //Operations.AddDefaultData();
        
        FileHnadling.ReadToCSV();
        Operations.MainMenu();
        FileHnadling.WriteToCSV();

    }
}
