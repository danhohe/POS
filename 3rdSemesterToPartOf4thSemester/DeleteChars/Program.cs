/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: 
 *------------------------------------------------------------------------*/
#nullable disable
namespace DeleteChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, deleteChars, output = string.Empty;
            bool hasCharToBeDeleted;

            Console.Write("Eingabetext: ");
            input = Console.ReadLine();
            Console.Write("Eliminatortext: ");
            deleteChars = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                hasCharToBeDeleted = false;
                for (int j = 0; j < deleteChars.Length; j++)
                {
                    if (input[i] == deleteChars[j])
                    {
                        hasCharToBeDeleted = true;
                    }
                }
                if (!hasCharToBeDeleted)
                {
                    output += input[i];
                }
            }
            Console.WriteLine($"{output}");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
