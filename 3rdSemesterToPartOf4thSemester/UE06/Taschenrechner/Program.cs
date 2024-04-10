/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 *Description:
 *Eingabe zweier Summanden die miteinander addiert werden und anschließend
 *die Rechnung sowie das Ergebnis rechtsbündig formatiert ausgeben.
 *--------------------------------------------------------------------------
*/

using System;

namespace calculator
{
    class Program
    {
        public static void Main()
        {
            double num1, num2, sum;

            Console.WriteLine("************************************");
            Console.WriteLine("* Calculator - Ihr Zahlenbegleiter *");
            Console.WriteLine("************************************");

            Console.WriteLine();

            // EINGABE (E)
            Console.Write("enter the first number: ");
            num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("enter the second number: ");
            num2 = Convert.ToDouble(Console.ReadLine());

            // VERARBEITUNG (V)
            sum = num1 + num2;

            Console.WriteLine();

            // AUSGABE (A)
            Console.WriteLine("Result:");
            Console.WriteLine("========");
            Console.WriteLine($"{num1, 30:n4}");
            Console.WriteLine($"+ {num2, 28:n4}");
            Console.WriteLine("------------------------------");
            Console.WriteLine($"{sum, 30:n4}");
            Console.WriteLine("==============================");

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}