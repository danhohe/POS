#nullable disable

using System.Diagnostics.Contracts;

namespace BusinessRun
{
    class Program
    {
        static void Main(string[] args)
        {
            RunApp();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        private static void RunApp()
        {
            
            PrintHeader();
            Runner[] runners = ReadFromCsvFile("BusinessRun.csv");
        }

        private static Runner[] ReadFromCsvFile(string csv)
        {
            string[] lines = File.ReadAllLines(csv);
            Runner[] result = new Runner[lines.Length];

            return result;
        }

        private static void PrintHeader()
        {
            Console.WriteLine("***********************************************************");
            Console.WriteLine("* Busines-Run - Die zuverlässige Software für Läufer      *");
            Console.WriteLine("* von Daniel Hoheneder                                    *");
            Console.WriteLine("***********************************************************");

        }
    }
}
