/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Es sollen die Zeichen samt dezimal und hex Code ausgegeben
 * werden.
 *------------------------------------------------------------------------*/
#nullable disable
namespace AsciiTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string hexValue;
            char character;

            Console.WriteLine("Druckbare Zeichen des ASCII-Codes:");
            Console.WriteLine("----------------------------------");
            for (int i = 32; i < 128; i++)
            {
                character = (char)i;
                hexValue = i.ToString("X4");
                Console.WriteLine($"Zeichen: {character} Code: {i} (dez) {hexValue} (hex)");
            }
            Console.WriteLine("---------------------------------");

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}