/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Turmrechnen mit einer vom User eingegebenen Zahl.
 *------------------------------------------------------------------------*/

#nullable disable

namespace towerCalculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n, i = 0, a;
            string input;

            //Eingabe (E)
            Console.WriteLine("Pyramid of Numbers");
            Console.WriteLine("==================");
            Console.WriteLine();
            Console.Write("Please enter number: ");
            input = Console.ReadLine();
            n = Convert.ToInt32(input);
            Console.WriteLine();

            //Verarbeitung (V) & Ausgabe (A)
            while (n != 0)
            {
                for (i = 2; i <= 9; i++)
                {
                    a = n * i;
                    Console.WriteLine($"{n} * {i} = {a}");
                    n = a;
                }
                for (i = 2; i <= 9; i++)
                {
                    a = n / i;
                    Console.WriteLine($"{n} / {i} = {a}");
                    n = a;
                }
                Console.Write("Please enter number[0 = end]: ");
                input = Console.ReadLine();
                n = Convert.ToInt32(input);
            }

        }
    }
}