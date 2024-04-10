/*-------------------------------------------------------------------------
*               HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*               Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Es wird anhand der eingegebenen Daten berechnet ob das 
* Fahrzeug sparsam, im Normbereich oder zu verschwenderisch ist.
*--------------------------------------------------------------------------
*/


using System;

namespace FuelCalculator
{

    class Program
    {
        static void Main(string[] args)
        {
            double distance, litres, average = 0;
            string fuelType;
            bool isReliable = false, isNorm = false, isWasteful = false;

            Console.WriteLine("Fuel Calculator");
            Console.WriteLine("===============");
            Console.WriteLine();
            //Eingabe
            Console.Write("Welchen Kraftstoff tanken Sie (Diesel/Benzin)? ");
            fuelType = Console.ReadLine();
            Console.Write("Wieviele Kilometer sind Sie gefahren? ");
            distance = Convert.ToDouble(Console.ReadLine());
            Console.Write("Wieviele Liter Kraftstoff haben Sie getankt? ");
            litres = Convert.ToDouble(Console.ReadLine());

            //Verarbeitug
            if ((((fuelType != "Diesel" && fuelType != "diesel") && (fuelType != "Benzin" && fuelType != "benzin")) || distance <= 0) || litres <= 0 )
            {
                Console.WriteLine("Üngültige Eingabe");
            }
            else
            {
                average = litres / (distance / 100);
                Console.WriteLine($"Der errechnete Durschnittsverbrauch liegt bei {average:n2}l / 100km.");

                if (fuelType == "Diesel" || fuelType == "diesel")
                {
                    if (average < 5)
                    {
                        isReliable = true;
                    }
                    else if (average >= 5 && average <= 6)
                    {
                        isNorm = true;
                    }
                    else if (average > 6)
                    {
                        isWasteful = true;
                    }
                }
                else if (fuelType == "Benzin" || fuelType == "benzin")
                {
                    if (average < 6)
                    {
                        isReliable = true;
                    }
                    else if (average >= 6 && average <= 7)
                    {
                        isNorm = true;
                    }
                    else if (average > 7)
                    {
                        isWasteful = true;
                    }
                }
            }
            //Ausgabe

            
            if (isReliable)
            {
                Console.WriteLine("Ihr Auto ist sparsam!");
            }
            else if (isNorm)
            {
                Console.WriteLine("Ihr Auto ist im Normbereich!");
            }
            else if (isWasteful)
            {
                Console.WriteLine("Ihr Auto verbraucht zu viel!");
            }
            Console.WriteLine();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
