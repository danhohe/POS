/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Es werden die Vokale einer Usereingabe extrahiert und in der
 * richtigen Reihenfolge und groß oder kleinschreibung ausgegeben.
 *------------------------------------------------------------------------*/
#nullable disable

using System.Globalization;

namespace FilterVocal
{
    class Program
    {
        static int n;
        static void Main(string[] args)
        {
            string input, output = string.Empty;

            Console.WriteLine("Vokale aus Text extrahieren");
            Console.WriteLine("===========================");
            Console.Write("Text: ");
            input = Console.ReadLine();
            output = FilterVocals(input);
            Console.WriteLine($"Der Text '{input}' enthält {n} Vokale: {output}");

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
        private static string FilterVocals(string text)
        {
            string output = string.Empty, vocals = string.Empty;
            char currentChar;
            for (int i = 0; i < text.Length; i++)
            {
                currentChar = Char.ToLower(text[i]);

                if ("aeiou".Contains(Char.ToLower(text[i])) && !vocals.Contains(Char.ToLower(text[i])))
                {
                    vocals += currentChar;
                    output += text[i];
                    n++;
                }
            }
            return output;
        }
    }
}
