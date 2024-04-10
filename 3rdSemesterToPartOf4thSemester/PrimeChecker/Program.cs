/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Es wird eine Zahl eingelesen und überprüft ob diese Zahl
 * eine Primzahl ist.
 *------------------------------------------------------------------------*/

#nullable disable
namespace PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, output = string.Empty;
            int primeCandidate = 0, divider = 3, i;
            bool isPrime;

            //Eingabe(E)
            Console.Write("Geben sie eine Zahl ein: ");
            input = Console.ReadLine();
            primeCandidate = Convert.ToInt32(input);

            isPrime = primeCandidate == 2 || (primeCandidate > 2 && primeCandidate % 2 != 0);

            // Verarbeitung (V)
            while (isPrime && divider <= primeCandidate / 2)
            {
                if (primeCandidate % divider == 0)
                {
                    isPrime = false;
                }
                divider += 2;
            }

            for (i = 2; i <= 10000; i++)
            {
                bool isPrimeSecond = true;
                for (int j = 2; j * j <= i && isPrimeSecond; j++)
                {
                    if (i % j == 0)
                    {
                        isPrimeSecond = false;
                    }
                }

                if (isPrimeSecond)
                {
                    output += i + ",";
                }
            }

            //Ausgabe (A)
            Console.WriteLine($"{primeCandidate} ist {(isPrime ? "eine" : "keine")} Primzahl");
            Console.WriteLine($"Die Primzahlen sind {output}");

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
