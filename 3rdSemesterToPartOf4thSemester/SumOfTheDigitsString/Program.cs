#nullable disable
namespace SumOfTheDigitsString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int n = 0;
            
            Console.Write("Eingabetext: ");
            input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= '0' && input[i] <= '9')
                {
                    n += (int)input[i] - 48;
                }
                else
                {
                    n += (int)input[i];
                }
            }

            Console.WriteLine($"{n}");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}