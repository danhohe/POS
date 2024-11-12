#nullable disable
namespace DemoThread
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Synchron");
            IncrementCounter();
            Console.WriteLine($"Counter: {Counter.Value}");

            DecrementCounter();
            Console.WriteLine($"Counter: {Counter.Value}");
            
            Thread t1 = new Thread((IncrementCounter));
            Thread t2 = new Thread((DecrementCounter));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine($"Async");
            Console.WriteLine($"Counter: {Counter.Value}");


            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        public static void IncrementCounter()
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                Counter.Increment();
            }
        }

        public static void DecrementCounter()
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                Counter.Decrement();
            }
        }
    }
}