/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Der User wird aufgefordert die Seitenlänge einzugeben.
 * Es wird ein Quadrat aus Sternen abhängig der eingegebenen Zahl gezeichnet.
 *------------------------------------------------------------------------*/

#nullable disable
using System.Globalization;

namespace starSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n, k, m, p;
            string input = string.Empty, distance = " ";
            char star = '*';

           //Console.SetWindowSize(80,25);  Bei macOS nicht anwendbar!

            Console.Write("Geben sie die Seitenlänge an: ");
            input = Console.ReadLine();
            n = Convert.ToInt32(input);

            Console.Clear();

            for (m = 40 - n / 2; m >= 0; m--)
            {
                distance = distance + distance[0];
            }

            for (p = 0; p <= 12 - n / 2; p++)
            {
                Console.WriteLine();
            }

            for (i = 0; i <= n; i++)
            {
                Console.Write($"{distance}");

                for (k = 0; k <= n; k++)
                {
                    Console.Write($"{star} ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
