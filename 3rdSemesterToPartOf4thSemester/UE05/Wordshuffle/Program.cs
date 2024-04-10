/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 *Description:
 *Eingabe von 3 Wörter und dann in allen möglichen gemischten Kombination 
 *ausgeben 
 *--------------------------------------------------------------------------
*/

using System;

namespace wordshuffle
{
    class Program
    {
        public static void Main()
        {
            string word1, word2, word3;

            Console.WriteLine($"WORDSHUFFLE");
            Console.WriteLine($"===========");

            Console.WriteLine();

            Console.Write("enter the first word: ");
            word1 = Console.ReadLine();

            Console.WriteLine();

            Console.Write("enter the second word: ");
            word2 = Console.ReadLine();

            Console.WriteLine();

            Console.Write("enter the third word: ");
            word3 = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Shuffling words  ... six possible combinations:");

            Console.WriteLine();

            Console.WriteLine($"{word1}, {word2}, {word3}");
            Console.WriteLine($"{word1}, {word3}, {word2}");
            Console.WriteLine($"{word2}, {word3}, {word1}");
            Console.WriteLine($"{word2}, {word1}, {word3}");
            Console.WriteLine($"{word3}, {word1}, {word2}");
            Console.WriteLine($"{word3}, {word2}, {word1}");

            Console.WriteLine();
            Console.WriteLine("press any key to exit...");

            Console.ReadKey();
        }
    }
}
