/*-------------------------------------------------------------------------
*               HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*               Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: User fragen welche Währung er eingeben möchte, in die anderen
* Währungen umrechnen und anschließend formatiert ausgeben.
*--------------------------------------------------------------------------
*/

using System;
#nullable disable

namespace currencyTranslation
{

    class Program
    {
        static void Main()
        {
            double inputValue, dollar = 0, franken = 0, euro = 0;
            string currency;

            Console.WriteLine("Currency Translator");
            Console.WriteLine("===================");

            Console.WriteLine();

            Console.Write("Eingabe der Ausgangswährung (D=Dollar, E=Euro, F=Franken): ");
            currency = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Betrag: ");
            inputValue = Convert.ToDouble(Console.ReadLine());

            switch (currency)
            {
                case "f" or "F":
                    franken = inputValue;
                    dollar = inputValue * 1.10798;
                    euro = inputValue * 1.05432;
                    break;

                case "d" or "D":
                    dollar = inputValue;
                    franken = inputValue * 0.90224;
                    euro = inputValue * 0.95132;
                    break;

                case "e" or "E":
                    euro = inputValue;
                    franken = inputValue * 0.948;
                    dollar = inputValue * 1.05086;
                    break;

                default:
                    franken = 0;
                    dollar = 0;
                    euro = 0;
                    break;
            }

            Console.WriteLine();

            Console.WriteLine($"Dollar: {dollar, 20:n2}");
            Console.WriteLine($"Franken: {franken, 19:n2}");
            Console.WriteLine($"Euro: {euro, 22:n2}");

            Console.WriteLine();

            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();
        }
    }
}
