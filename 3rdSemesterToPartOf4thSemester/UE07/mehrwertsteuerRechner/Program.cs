/*--------------------------------------------------------------------------
*              HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*              Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Den Verkaufspreis sowie die Steuerbelastung bei 10% berechnen
* und ausgeben sowie bei 5% und yusätzlich die Ersparnis bekanntgeben.
*--------------------------------------------------------------------------
*/

using System;

namespace taxCalculator
{
    class Program
    {
        public static void Main()
        {
            double oldPrice, newPrice, tax, savings;
            double midTax = 0.10;
            double highTax = 0.20;
            double lowTax = 0.05;
            string answer;

            Console.WriteLine("Steuerrechner");
            Console.WriteLine("=============");

            Console.Write("Aktueller Verkaufspreis: ");
            oldPrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            tax = oldPrice * midTax;
            newPrice = oldPrice - tax;
            Console.Write("Nettopreis: ");
            Console.WriteLine($"{newPrice,30:n2}");
            Console.Write("Derzeitige Mehrwertsteuer: ");
            Console.WriteLine($"{tax,15:n2}");
            Console.WriteLine();

            Console.WriteLine("Werte bei 5% Steuer");
            Console.WriteLine("-------------------");
            Console.WriteLine();

            tax = oldPrice * lowTax;
            newPrice = oldPrice - tax;
            savings = oldPrice - newPrice;
            Console.Write("Mehrwertsteuer: ");
            Console.WriteLine($"{tax,26:n2}");
            Console.Write("Zukünftiger Verkaufspreis: ");
            Console.WriteLine($"{newPrice,15:n2}");
            Console.Write("Ersparnis:");
            Console.WriteLine($"{savings, 32:n2}");

            Console.WriteLine();

            Console.WriteLine("Ist das Produkt ein Grundnahrungsmittel?");
            Console.WriteLine("Bitte mit ´y´ für Ja oder ´n´ für Nein antworten");
            answer = Console.ReadLine().ToLower();

            Console.WriteLine();


            if (answer == "y")
            {
                tax = oldPrice * midTax;
                newPrice = oldPrice - tax;
                Console.Write("Nettopreis: ");
                Console.WriteLine($"{newPrice, 30:n2}");
                Console.Write("Derzeitige Mehrwertsteuer: ");
                Console.WriteLine($"{tax, 15:n2}");
            }
            else if (answer == "n")
            {
                tax = oldPrice * highTax;
                newPrice = oldPrice - tax;
                Console.Write("Nettopreis: ");
                Console.WriteLine($"{newPrice, 30:n2}");
                Console.Write("Derzeitige Mehrwertsteuer: ");
                Console.WriteLine($"{tax, 15:n2}");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe");
            }

            Console.WriteLine();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}