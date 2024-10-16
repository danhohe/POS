#nullable disable
namespace DemoGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            Point<int> intPoint = new Point<int>();
            Point<double> doublePoint = new Point<double>();

            Console.WriteLine($"Typ von X: {doublePoint.X.GetType().Name}");

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}