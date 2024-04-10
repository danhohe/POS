/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Die Usereingabe soll ggespeichert, erhalten und umgekehrt 
 * wieder ausgegeben werden.
 *------------------------------------------------------------------------*/

#nullable disable
namespace StringReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, output = string.Empty;

            // Eingabe
            Console.WriteLine("String Reverse");
            Console.WriteLine("==============");
            Console.WriteLine();
            Console.Write("Geben sie einen Text ein: ");
            input = Console.ReadLine();

            // Verarbeitung
            for ( int i = input.Length - 1; i >= 0; i--)
            {
                output = output + input[i];
            }

            // Ausgabe
            Console.WriteLine($"{output}");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}