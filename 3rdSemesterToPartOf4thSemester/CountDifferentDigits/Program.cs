#nullable disable


namespace CountDifferentDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, output = string.Empty;
            int[] digits = new int[10];
            input = GetUserInput();
            digits = GetArray(input);
            output = GetUniqueDigitsString(digits);
            
            Console.WriteLine($"Eingegebene Ziffern im Array: {input}");
            Console.WriteLine($"Eindeutige Ziffern im Array: {output}");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        private static string GetUserInput()
        {
            string input, output = string.Empty;
            int i = 0;
            do
            {
                Console.Write($"{i + 1}. Ziffer [0-9] eingeben: ");
                input = Console.ReadLine();
                if (input.Length >= 2 || input[0] == '-')
                {
                    Console.WriteLine("Fehleingabe, Ziffer muss zwischen 0 und 9 liegen!");
                }
                else
                {
                    output += input[0];
                    i++;
                }
            } while (i < 10);
            return output;
        }

        private static int[] GetArray(string input)
        {
            int[] digits = new int[10];
            for (int i = 0; i < input.Length; i++)
            {
                digits[i] = input[i];
            }
            return digits;
        }

        private static string GetUniqueDigitsString(int[] digits)
        {

            string output = string.Empty;
            Array.Sort(digits);
            for (int i = 0; i < digits.Length; i++)
            {
                char digit = (char)digits[i];
                if (!output.Contains(digit))
                {
                    output += digits[i] - 48;
                }
            }
            return output;
        }
    }
}
