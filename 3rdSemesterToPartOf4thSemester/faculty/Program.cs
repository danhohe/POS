/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Hier wird die Fakultät einer vom User eingegebenen Zahl 
 * ermittelt.
 *------------------------------------------------------------------------*/

#nullable disable

namespace guessTheNumber
{
    class Program
    {
        public static void Main(string[] args)
        {
            int i, n, result = 1;
            string input;

            //Eingabe (E)
            Console.WriteLine("Fakultätsberechnung");
            Console.WriteLine("===================");
            Console.WriteLine();
            Console.Write("Bitte Wert eingeben: ");
            input = Console.ReadLine();
            n = Convert.ToInt32(input);

            //Verarbeitung (V)
            for(i = n; i >= 1; i--)
            {
                result = result * n;
                n--;
            }

            //Ausgabe (A)
            Console.WriteLine($"{input}! ergibt {result:n0}");

        }
    }
}