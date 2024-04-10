/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 *Description:
 *Eingabe des Namens und des Wohnortes und anschließend formtierte Ausgabe 
 *der eingegebenen Daten
 *--------------------------------------------------------------------------
*/

using System;


namespace Visitenkarte
{
    class Program
    {
        public static void Main()
        {
            string firstName, address;
            
            Console.WriteLine("BusinessCard");

            // EINGABE
            Console.Write("Please enter your first name: ");
            firstName = Console.ReadLine();

            Console.Write("and now your address: ");
            address = Console.ReadLine();

            // AUSGABE
            Console.WriteLine("******************************");
            Console.WriteLine($"*  {firstName}");
            Console.WriteLine("******************************");
            Console.WriteLine($"*  {address}");
            Console.WriteLine("******************************");

            Console.WriteLine();

            Console.WriteLine("******************************");
            Console.Write($"* {firstName,-27}");
            Console.WriteLine("*");
            Console.WriteLine("******************************");
            Console.Write($"* {address,-27}");
            Console.WriteLine("*");
            Console.WriteLine("******************************");

            Console.WriteLine("Enter any key to exit...");
            Console.ReadKey();

        }
    }

}