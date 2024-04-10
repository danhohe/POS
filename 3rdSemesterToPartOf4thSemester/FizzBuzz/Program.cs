/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Das Programm stellt ein Spiel für das Lernen der Division 
 * dar. Es wird von 1 - 100 gezählt, wenn eine Zahl durch 3 teilbar ist 
 * wird Fizz und wenn sie durch 5 teilbar ist wird Buzz ausgegeben. Bei
 * einer Zhl die durch 5 und 3 teilbar ist wird Fizz Buzz ausgegeben.
 *------------------------------------------------------------------------*/
#nullable disable
namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            string fizz = "Fizz", buzz = "Buzz";

            Console.WriteLine("*****************************************");
            Console.WriteLine("* Ausgabe für Fizz-Buzz von 1 bis 100   *");
            Console.WriteLine("* Fizz, wenn durch 3 teilbar.           *");
            Console.WriteLine("* Buzz, wenn durch 5 teilbar.           *");
            Console.WriteLine("* FizzBuzz, wenn durch 3 und 5 teilbar. *");
            Console.WriteLine("*****************************************");

            // Verarbeitung & Ausgabe
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 != 0 && i % 5 != 0)
                {
                    Console.Write($"{i}, ");
                }
                else if (i % 3 == 0 && i % 5 != 0)
                {
                    Console.Write($"{fizz}, ");
                }
                else if (i % 3 != 0 && i % 5 == 0)
                {
                    Console.Write($"{buzz}, ");
                }
                else if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write($"{fizz + " " + buzz}, ");
                }
            }

            Console.WriteLine();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
