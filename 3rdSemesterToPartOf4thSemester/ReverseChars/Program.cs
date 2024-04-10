#nullable disable
using System.Runtime.CompilerServices;

namespace ReverseChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, output = string.Empty;
            int n, count = 0, z;
            bool isStringReversed = false;

            Console.Write("Eingabetext: ");
            input = Console.ReadLine();
            Console.Write("Anzahl an Zeichen die miteinander getauscht werden sollen: ");
            int.TryParse(Console.ReadLine(), out n);

            z = n;

            if (n <= 0)
            {
                output = input;
            }
            else if (n > input.Length)
            {
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    output += input[i];
                    isStringReversed = true;
                }
            }

            while (!isStringReversed && z != 0)
            {
                for (int j = n - 1; j >= n - z; j--)
                {
                    while (j >= input.Length)
                    {
                        j = j - 1;
                    }
                    output += input[j];
                    count++;
                }
                n += z;
                if (count == input.Length)
                {
                    isStringReversed = true;
                }
            }
            Console.WriteLine($"{output}");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}