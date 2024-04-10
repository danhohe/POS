/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Es wird vom User die Distanz sowie die Geschwindigkeit von 
 * beiden Fahrzeugen eingegeben. Anschließend wird berechnet wo und nach
 * Zeit sich die Fahrzeuge treffen.
 *------------------------------------------------------------------------*/
#nullable disable
namespace LinearMotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            int distance, velocityA, velocityB, i = 0;
            double moveA, moveB, totalMovePerMinute, totalTimeRequired, hour, min, sec, timeWarp, positionA = 0, positionB = 0, doubleDistance, meetingPlace;

            Console.WriteLine("Begegnung zweier entgegenfahrender Fahrzeuge");
            Console.WriteLine("============================================");
            Console.WriteLine();
            Console.Write("Entfernung [Ganzzahl in km]: ");
            input = Console.ReadLine();
            distance = Convert.ToInt32(input);
            Console.Write("Geschwindigkeit des Fahrzeugs A [Ganzzahl in km/h]: ");
            input = Console.ReadLine();
            velocityA = Convert.ToInt32(input);
            Console.Write("Geschwindigkeit des Fahrzeugs B [Ganzzahl in km/h]: ");
            input = Console.ReadLine();
            velocityB = Convert.ToInt32(input);
            Console.WriteLine();
            
            positionB = distance;
            doubleDistance = distance;
            moveA = velocityA / 60.0; // km/min
            moveB = velocityB / 60.0; // km/min
            totalMovePerMinute = moveA + moveB;
            totalTimeRequired = doubleDistance / (moveA + moveB);

            while (doubleDistance >= 0)
            {
                Console.Write($"Minute: {i,5} Position A: {positionA,5:n2} Position B: {positionB,5:n2} Distanz {doubleDistance,5:n2}");
                Console.WriteLine();
                i++;
                positionA = positionA + moveA;
                positionB = positionB - moveB;
                doubleDistance = doubleDistance - totalMovePerMinute;
            }

            Console.WriteLine();

            timeWarp = totalTimeRequired / 60;
            hour = (int)timeWarp;
            timeWarp = (timeWarp - hour) * 60;
            min = (int)timeWarp;
            sec = (timeWarp - min) * 60;
            meetingPlace = moveA * totalTimeRequired;
            
        
        //    Console.WriteLine($"Fahrzeug 1: {moveA:n2} Fahrzeug 2: {moveB:n2} Weg pro Minute: {totalMovePerMinute:n2} zeitpunkt: {totalTimeRequired:n2}"); //Ausgabe zur Überprüfung einzelner Werte
        //    Console.WriteLine($"{hour}:{min}:{sec}");
        //    Console.WriteLine();
            Console.WriteLine($"Treffpunkt in {meetingPlace:n2}km nach {hour} Stunden, {min} Minuten und {sec:n2} Sekunden");
        
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}