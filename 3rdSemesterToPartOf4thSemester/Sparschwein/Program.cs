/*--------------------------------------------------------------------------
*              HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*              Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Eingabe von ganzen Zahlen, um mit denen zu berechnen wie viel
*Geld mit den Münzen angesammelt wurde. Ergebnis formatiert ausgeben.
*--------------------------------------------------------------------------
*/

using System.Text;

namespace piggyBank
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int halfEuro, euro, twoEuro, fiveEuro, tenEuro;
            double savings;

            Console.WriteLine("Piggy Bank");
            Console.WriteLine("==========");

            Console.WriteLine();

            Console.Write("Wie viele 50 Cent Stücke haben sie?          ");
            halfEuro = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Wie viele 1 Euro Stücke haben sie?           ");
            euro = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Wie viele 2 Euro Stücke haben sie?           ");
            twoEuro = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Wie viele 5 Euro Scheine haben sie?          ");
            fiveEuro = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Wie viele 10 Euro Scheine haben sie?         ");
            tenEuro = Convert.ToInt32(Console.ReadLine());

            
            savings = (0.5 * halfEuro) + euro + (2 * twoEuro) + (5 * fiveEuro) + (10 * tenEuro);

            Console.WriteLine();
            Console.WriteLine($"Ihr Sparschwein enthält: {savings, 24:n2} €");
            Console.WriteLine();

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}