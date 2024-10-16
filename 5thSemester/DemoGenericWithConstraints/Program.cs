#nullable disable
using DemoGenericWithConstraints;

namespace DemoGenericWithConsraints
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 4, b = 5;

            Console.WriteLine($"{nameof(a)}: {a}, {nameof(b)}: {b}");

            Helper.Swap(ref a, ref b);

            Console.WriteLine($"{nameof(a)}: {a}, {nameof(b)}: {b}");

            
            string s1 = "Gerhard", s2 = "Gehrer";

            Console.WriteLine($"{nameof(s1)}: {s1}, {nameof(s2)}: {s2}");

            Helper.Swap(ref s1, ref s2);

            Console.WriteLine($"{nameof(s1)}: {s1}, {nameof(s2)}: {s2}");

            Helper.Sort(ref a, ref b);

            Console.WriteLine($"{nameof(a)}: {a}, {nameof(b)}: {b}");

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}