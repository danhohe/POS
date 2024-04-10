/*--------------------------------------------------------------------------
*              HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*              Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Abfrage welche Ausgangswährung eingegeben wird, dann einlesen
*des Betrags, Umrechnung in die anderen beiden Währungen, Ausgabe der 
*Ergebnisse
*--------------------------------------------------------------------------
*/
#nullable disable
namespace currencyCalculator
{

    class Program
    {
        static void Main(string[] args)
        {
            double euroSum, dollarSum, switzSum;
            string option;

            Console.WriteLine("Currency Calculator");
            Console.WriteLine("===================");

            Console.WriteLine("Bitte die Ausgangswährung wie folgt auswählen:");
            Console.WriteLine("D = Dollar");
            Console.WriteLine("E = Euro");
            Console.WriteLine("F = Franken");
            Console.WriteLine();
            option = Console.ReadLine();
            Console.WriteLine();

            // dollar: 1 --> euro: 0.9430
            // dollar 1 --> franken: 0.9042
            // euro 1 --> dollar: 1.0605
            // euro 1 --> franken: 0.9591
            // franken 1 --> euro 1.0415
            // franken 1 --> dollar: 1.1038

            if (option == "f" || option == "F")
            {
                Console.Write("Eingabe des Betrages in Franken: ");
                switzSum = Convert.ToInt32(Console.ReadLine());

                dollarSum = switzSum * 1.1038;
                euroSum = switzSum * 1.0415;

                Console.WriteLine($"Dollar: {dollarSum:n2} USD");
                Console.WriteLine($"Euro: {euroSum:n2} EUR");
            }
            else if (option == "d" || option == "D")
            {
                Console.Write("Eingabe des Betrages in Dollar: ");
                dollarSum = Convert.ToInt32(Console.ReadLine());

                switzSum = dollarSum * 0.9042;
                euroSum = dollarSum * 0.9430;

                Console.WriteLine($"Franken: {switzSum:n2} CHF");
                Console.WriteLine($"Euro: {euroSum:n2} EUR");
            }
            else if (option == "e" || option == "E")
            {
                Console.Write("Eingabe des Betrages in Euro: ");
                euroSum = Convert.ToInt32(Console.ReadLine());

                dollarSum = euroSum * 1.0605;
                switzSum = euroSum * 0.9591;

                Console.WriteLine($"Dollar: {dollarSum:n2} USD");
                Console.WriteLine($"Franken: {switzSum:n2} CHF");
            }
            else
            {
                Console.WriteLine("Keine gültige Währung gewählt!");
            }


            Console.WriteLine("press any key to exit...");
            Console.ReadKey();

        }
    }
}
  