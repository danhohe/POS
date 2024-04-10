/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Es wird ein String und ein Char (Splitzeichen) eingelesen 
 * der String wird bei jedem im String vorkommenden Splitzeichen getrennt
 * und in einzelnen Zeilen ausgegeben.
 *------------------------------------------------------------------------*/

#nullable disable
namespace SplitString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            char split;

            Console.WriteLine("SplitString");
            Console.WriteLine("===========");
            Console.WriteLine();
            Console.Write("Eingabetext: ");
            input = Console.ReadLine();
            Console.Write("Splitzeichen: ");
            split = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("*** Ausgabetext ***");
            
            for (int i = 0; i <= input.Length - 1; i++)
            {
                if(input[i] == split)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write($"{input[i]}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}