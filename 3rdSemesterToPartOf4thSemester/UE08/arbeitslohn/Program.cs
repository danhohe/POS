/*--------------------------------------------------------------------------
*              HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*              Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Namen, Stunden und Stundenlohn einlesen und anschließend
*Formatiert ausgeben.
*--------------------------------------------------------------------------
*/

using System;

namespace arbeitslohn
{
    class Program
    {
        public static void Main()
        {
            string name;
            double workingHours, earningsPerHour, earnings;

            Console.WriteLine("Berechnen sie hier ihren Arbeitslohn");
            Console.WriteLine("====================================");

            Console.WriteLine();

            Console.Write("Geben sie ihren Namen ein: ");
            name = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Geben sie ihre gearbeiteten Stunden ein: ");
            workingHours = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Geben sie ihren Stundenlohn ein: ");
            earningsPerHour = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            earnings = workingHours * earningsPerHour;

            Console.WriteLine($"{name} hat in {workingHours} Stunden {earnings}€ verdient!");

            Console.WriteLine();

            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();
        
        }
    }
}