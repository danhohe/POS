/*-------------------------------------------------------------------------
*               HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*               Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Grad Celsius vom benutzer einlesen und in Fahrenheit
* umrechnen. Den User informieren ob das Ergebnis über, gleich oder unter
* NULL ist. Anschließend die Resultate formatiert ausgeben.
*--------------------------------------------------------------------------
*/

using System;

namespace temperatureSelection
{
    class Program
    {
        public static void Main()
        {
            double celsius, fahrenheit;

            Console.WriteLine("Umrechnung Celsius -> Fahrenheit");
            Console.WriteLine("================================");

            Console.WriteLine();

            // INPUT
            Console.Write("Eingabe Grad Celsius: ");
            celsius = Convert.ToDouble(Console.ReadLine());

            // PROCESS
            fahrenheit = (9.0/5 * celsius) + 32;

            // OUTPUT
            Console.Write("Das Ergebnis ist:             ");

            if (fahrenheit < 0)
            {
                Console.WriteLine("Ist kleiner 0");
            }
            else if (fahrenheit >= 0)
            {
                Console.WriteLine("Ist größer oder gleich 0");
            }

            Console.WriteLine();

            Console.WriteLine($"Celsius:{celsius,20:n2}");
            Console.WriteLine($"Fahrenheit:{fahrenheit,17:n2}");

            Console.WriteLine();

            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();
        }
    }
}