/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: 
 *------------------------------------------------------------------------*/
#nullable disable
namespace SearchString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, search;
            int i = 0, j = 0;
            bool isFound = false;

            Console.Write("Eingabetext: ");
            input = Console.ReadLine();
            Console.Write("Suchtext: ");
            search = Console.ReadLine();

            while (isFound == false && (i <= input.Length - search.Length))
            {
                j = 0;
                isFound = true;
                while(isFound && j < search.Length)
                {
                    isFound = Char.ToLower(input[i + j]) == Char.ToLower(search[j]);
                    j++;
                }
                i++;
            }
            i = i - search.Length - 1 + j;
            Console.WriteLine($"Der Suchtext wurde an der Position {i} gefunden!");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
