/*--------------------------------------------------------------------------
*              HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*              Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Eingabe einer Anzahal von Mehlsäcken sowie das Gewicht eines
*Mehlsacks. Anschließend berechnen und ausgeben wie viele Semmeln damit 
*erzeugt werden können.
*--------------------------------------------------------------------------
*/

using System;

namespace bäckerei
{
    class Program
    {
        public static void Main()
        {
            int numberOfBag, weightOfBag, numberOfSemmel;
            int weightOfSemmel = 50;

            Console.WriteLine("Mehlmengenrechner");
            Console.WriteLine("-----------------");

            Console.WriteLine();

            Console.Write("Anzahl der Mehlsäcke:");
            numberOfBag = Convert.ToInt32(Console.ReadLine());
            Console.Write("Gewicht des Mehlsacks in Gramm:");
            weightOfBag = Convert.ToInt32(Console.ReadLine());

            numberOfSemmel = (weightOfBag * numberOfBag) / weightOfSemmel;

            Console.WriteLine($"Mit {numberOfBag} Säcken Mehl a {weightOfBag}Gramm können {numberOfSemmel} Semmeln erzeugt werden!");

            Console.WriteLine();

            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();
        }
    }
}
