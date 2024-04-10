#nullable disable
namespace BabySpeech
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, output = string.Empty;

            Console.Write("Eingabetext: ");
            input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u')
                {
                    output += "b" + input[i] + "b";
                }
                else if (input[i] == 'A' || input[i] == 'E' || input[i] == 'I' || input[i] == 'O' || input[i] == 'U')
                {
                    output += "B" + Char.ToLower(input[i]) + "b";
                }
                else
                {
                    output += input[i];
                }
            }

            Console.WriteLine($"{output}");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}