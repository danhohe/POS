#nullable disable
namespace DemoString.ConApp
{
    class Program
    {
        static void Main (string[] args)
        {
            string input, reverseString = string.Empty;
            Console.Write("Geben Sie einen Text ein: ");
            input = Console.ReadLine();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                reverseString = reverseString + input [i];
                Console.Write(input[i]);
            }
            Console.ReadKey();
        }
    }
}
