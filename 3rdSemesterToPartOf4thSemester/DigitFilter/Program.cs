/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Die Benutzereingabe wird nach Ziffern abgesucht und die 
 * Ziffern werden dann ausgegeben.
 *------------------------------------------------------------------------*/
#nullable disable
namespace DigitFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, output = string.Empty;

            Console.WriteLine("Digit Filter");
            Console.WriteLine("------------");

            Console.Write("Eingabetext: ");
            input = Console.ReadLine();

            for (int i = 0; i <= input.Length - 1; i++)
            {
                if(input[i] >= '0' && input[i] <= '9')
                {
                    output = output + input[i];
                }
            }

            Console.WriteLine($"{output}");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
