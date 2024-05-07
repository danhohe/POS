#nullable disable
namespace DemoVector.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector a, b, c;
            a = new Vector();
            b = new Vector(3, 4);
            c = new Vector(10, 20);

            Console.WriteLine($"Vector: {a}");
            Console.WriteLine($"Vector: {b}");
            Console.WriteLine($"Vector: {c}");

            c.Add(b);

            Console.WriteLine($"Vector: {c}");

            Vector d = Vector.Add(b, c);
            Console.WriteLine($"Vector: {d}");

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}