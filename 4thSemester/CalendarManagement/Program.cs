#nullable disable
namespace CalendarManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFromCsv("CalendarDates.csv");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
