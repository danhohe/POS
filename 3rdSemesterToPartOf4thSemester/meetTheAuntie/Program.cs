/*-------------------------------------------------------------------------
*               HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*               Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Den Benutzer entscheiden lassen welche Eingabe er tätigen 
* möchte, die fehlenden Komponenten berechnen, anschließend formatiert und
* aufgeschlüssselt ausgeben.
*--------------------------------------------------------------------------
*/



namespace meetTheAunt
{

    class Program
    {
        static void Main(string[] args)
        {
            double distance = 0, speed = 0, travelTime = 0, remainingMin = 0, remainingSec = 0;
            int hour = 0, min = 0, sec = 0;
            string option;

            Console.WriteLine("Berechnung der Ankunftszeit bei der Tante");
            Console.WriteLine("=========================================");

            Console.WriteLine();

            // Abfrage was der User eingeben möchte
            Console.WriteLine("Wollen sie die Fahrtdauer oder die Geschwindigkeit vorgeben?");
            Console.Write("Bitte antworten sie mit time für die Fahrtdauer oder mit speed für die Geschwindigkeit: ");
            option = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Entfernung in km: ");
            distance = Convert.ToDouble(Console.ReadLine());

            // Verzweigung mit der jeweiligen Verarbeitung
            if (option == "speed")
            {
                Console.Write("Geschwindigkeit in km/h: ");
                speed = Convert.ToDouble(Console.ReadLine());

                travelTime = distance / speed;
                hour = (int)travelTime;
                remainingMin = (travelTime - hour) * 60;
                min = (int)remainingMin;
                remainingSec = (remainingMin - min) * 60;
                sec = (int)remainingSec;
            }
            else if (option == "time")
            {
                Console.Write("Wie viele volle Stunden fahren sie?  ");
                hour = Convert.ToInt32(Console.ReadLine());
                Console.Write("Wie viele Minuten fahren sie?  ");
                min = Convert.ToInt32(Console.ReadLine());
                Console.Write("Wie viele Sekunden fahren sie?  ");
                sec = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                travelTime = (double)hour + ((double)min / 60) + ((double)sec / 3600);
                speed = distance / travelTime;
                Console.WriteLine($"Die Fahrtgeschwindigkeit beträgt: {speed:n2} km/h");
            }
            else
            {
                Console.WriteLine("ungültige Eingabe!");
            }

            Console.WriteLine();

            hour = hour + 10; // Weil immer um 10 Uhr Abfahrt ist

            // Ausgabe
            Console.WriteLine($"Für die Strecke von {distance:n2} km benötigen sie {travelTime:n2} Stunden");
            Console.WriteLine($"Sie kommen um {hour:00}:{min:00}:{sec:00} an");
                
            Console.WriteLine();

            if (travelTime <= 2)
            {
                Console.WriteLine("Sie bekommen noch ein Mittagessen!");
            }
            else if (travelTime > 2 && travelTime < 9)
            {
                Console.WriteLine("Es gibt nur noch Kaffee und Kuchen!");
            }
            else if (travelTime >= 9)
            {
                Console.WriteLine("Es wird dunkel bevor sie ankommen!");
            }

            Console.WriteLine();
            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();
        }
    }
}