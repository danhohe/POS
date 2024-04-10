#nullable disable
namespace DemoString2.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool contains = false;
            string a = "abcdefghijklmnopqrstuvwxyz";
            string b = "klmnopqrs";
            int idxA = 0, idxB;

            while ( contains == false && idxA <= a.Length - b.Length)
            {
                idxB = 0;
                contains = true;
                while (contains && idxB < b.Length)
                {
                    contains = a[idxA + idxB] == b[idxB];
                    idxB ++;
                }
                idxA++;
            }
            
            if (contains)
            {
                Console.WriteLine($"{b} ist in {a} enthalten");
            }

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}