#nullable disable

using System.Runtime.CompilerServices;

namespace DemoReskursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FibonaciRecursive(8));
            Console.WriteLine();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
        private static long FibonaciRecursive(int n)
        {
            //nicht rekursiv
            if (n <= 2 && n > 0)
            {
                return 1;
            }
            else if (n == 0)
            {
                return 0;
            }
            //rekursiv
            else
            {
                return FibonaciRecursive(n - 1) + FibonaciRecursive(n - 2);
            }
        }
    }
}