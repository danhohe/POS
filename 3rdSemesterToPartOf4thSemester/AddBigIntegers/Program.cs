/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Reads two big numbers and add them.
 *------------------------------------------------------------------------*/

#nullable disable

namespace AddBigIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string number1, number2, result;

            Console.WriteLine("Addieren von sehr großen Zahlen (Integer)");
            Console.WriteLine("=========================================");

            // Input (I)
            number1 = ReadBigInteger("Geben sie die erste Zahl ein: ");
            number2 = ReadBigInteger("Geben sie die zweite Zahl ein: ");

            // Processing (P)
            result = AddBigIntegers(number1, number2);

            // Output (O)
            Console.WriteLine($"Summe der beiden Zahlen:");
            Console.WriteLine($"{result}");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static string AddBigIntegers(string number1, string number2)
        {
            string result = string.Empty;
            int maxNumber = Math.Max(number1.Length, number2.Length) + 1;
            bool carry = false;

            number1 = AddLeadingCharacters(number1, '0', maxNumber - number1.Length);
            number2 = AddLeadingCharacters(number2, '0', maxNumber - number2.Length);

            for (int i = number1.Length - 1; i >= 0; i--)
            {
                int sum = number1[i] - '0' + number2[i] - '0' + (carry ? 1 : 0);
                
                if (sum < 10)
                {
                    result = sum.ToString() + result;
                    carry = false;
                }
                else
                {
                    result = (sum % 10).ToString() + result;
                    carry = true;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="chr"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static string AddLeadingCharacters(string number, char chr, int count)
        {
            string result = number;
            int length = number.Length + count;
            while (result.Length < length)
            {
                result = chr + result;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static string ReadBigInteger(string prompt)
        {
            string result;
            bool validInput;

            do
            {
                Console.Write($"{prompt}");
                result = Console.ReadLine();
                validInput = IsBigNumber(result);
                if (!validInput)
                {
                    Console.WriteLine("Ungültige Eingabe!");
                }
            } while(!validInput);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsBigNumber(string number)
        {
            bool result = number.Length > 0;
            int idx = 0;

            while (idx < number.Length && result)
            {
                result = char.IsDigit(number[idx++]);
            }

            return result;
        }
    }
}
