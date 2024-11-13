#nullable disable
namespace WorldClock.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WorldClock");

            ConsoleClock c1 = new ConsoleClock(0, "Vienna", ConsoleColor.Blue);
            ConsoleClock c2 = new ConsoleClock(-6, "New York", ConsoleColor.Red);
            ConsoleClock c3 = new ConsoleClock(6, "Tokyo", ConsoleColor.Cyan);

            Logic.WorldClock.Instance.AddObserver(c1);
            Logic.WorldClock.Instance.AddObserver(c2);
            Logic.WorldClock.Instance.AddObserver(c3);

            Console.ReadLine();

            Logic.WorldClock.Instance.RemoveObserver(c1);
            Logic.WorldClock.Instance.RemoveObserver(c2);
            Logic.WorldClock.Instance.RemoveObserver(c3);

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}