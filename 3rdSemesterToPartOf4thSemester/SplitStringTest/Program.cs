#nullable disable
namespace SplitStringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, output1 = string.Empty, output2 = string.Empty;
            double x;
            Console.Write("Eingabetext: ");
            input = Console.ReadLine();
            x = input.Length - 1;

            for (int i = 0; i <= (int)x / 2; i++)
            {
                output1 += input[i];
            }
           
            for (int j = (int)x / 2 + 1; j < input.Length; j++)
            {
                output2 += input[j];
            }

            Console.WriteLine($"{output1}");
            Console.WriteLine($"{output2}");

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
