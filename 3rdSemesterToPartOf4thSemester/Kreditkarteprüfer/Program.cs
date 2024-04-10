/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Es wird die eingegebene Kreditkartennummer überpüft ob 
 * diese gültig ist.
 *------------------------------------------------------------------------*/

#nullable disable
using System.Globalization;

namespace CreditCardCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int i, n, j = 0, sum1 = 0, sum2 = 0, result;
            int[] digits = new int[16];
            bool isDigit, isValidNumber = false;
            
            Console.WriteLine("Kreditkartenprüfer");
            Console.WriteLine("==================");

            for (i = 0; i <= digits.Length - 1; i++)
            {
                Console.Write($"Geben sie die {i + 1}. Ziffer ein: ");
                input = Console.ReadLine();
                isDigit = Int32.TryParse(input, out digits[i]);
            }
            do
            {
                if(j == 0 || j % 2 == 0)
                {
                    n = digits[j] * 2;
                    sum1 = (n % 10) + ((n / 10) % 10);
                }
                else
                {
                    sum2 = sum2 + digits[j];
                }
                j++;
            }while (j < digits.Length - 1);

            result = sum1 + sum2 + digits[15];

            if (result % 10 == 0)
            {
                isValidNumber = true;
            }

            Console.WriteLine($"Die eingegebene Kreditkartennummer {(isValidNumber ? "ist gültig" : "ist ungültig")}");

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}