#nullable disable
namespace DemoSortFraction.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(2, 8);
            Fraction f2 = new Fraction(1, 3);
            Fraction f3 = new Fraction(1, 1);
            Fraction f4 = new Fraction(12, 18);
            Fraction[] fractions = [f1, f2, f3, f4];
            Array.Sort(fractions);

            foreach (Fraction f in fractions)
            {
                Console.WriteLine(f);
            }

            Array.Sort(fractions, new NominatorComparer());
            Console.WriteLine("Nominator Comparer");
            foreach (Fraction f in fractions)
            {
                Console.WriteLine(f);
            }
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}