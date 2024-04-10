/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Eine positive ganze Zahl soll in Binär Umgewandelt werden. 
 * Dazu verwendet das Program die Binärumwandlung.
 *------------------------------------------------------------------------*/

#nullable disable
namespace FindAllBits
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, binary = string.Empty;
            char numChar;
            uint n;
            double bits = 0, pot, result;
            bool isNum;

            // Eingabe
            Console.Write($"Geben sie eine Zahl zwischen 1 und {UInt32.MaxValue} ein (0 für Ende): ");
            input = Console.ReadLine();
            isNum = UInt32.TryParse(input, out n);

            // Verarbeitung
            while (isNum && n != 0)
            {
                if (n % 2 != 0)
                {
                    binary = binary + 1;
                }
                else if (n % 2 == 0)
                {
                    binary = binary + 0;
                }

                n = n / 2;
            }

            for (int i = 0; i <= binary.Length - 1; i++)
            {
                numChar = binary[i];
                n = Convert.ToUInt32(numChar) - 48;
                pot = Math.Pow(2, i);
                result = n * pot;
                bits = bits + result;
                Console.WriteLine($"{binary[i]} * 2 ^ {i} = {result}");
            }

            // Ausgabe
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine($"Demzimalzahl: {input, 26}");
            Console.WriteLine($"Summe aller Bitwerte: {bits, 18}");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}