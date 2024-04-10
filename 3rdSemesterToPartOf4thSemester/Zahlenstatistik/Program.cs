/*-------------------------------------------------------------------------
*               HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*               Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Der Benutzer gibt mehrere Zahlen getrennt durch die
* Eingabetaste ein. mit Eingabe der Zahl null wird die Eingabe beendet
* Anschließend wird die Summe, der größte Wert und der Mittelwert
* ausgegeben
*--------------------------------------------------------------------------
*/

#nullable disable

namespace Zahlenstatistik
{

    class Program
    {
        static void Main()
        {

            int sum = 0, max = Int32.MinValue, min = Int32.MaxValue, num, idx = 0, prvMax = 0;
            double average = 0;
            Console.WriteLine("Zahlenstatistik");
            Console.WriteLine("===============");

            //Eingabe (E)
            Console.WriteLine("Geben sie positive ganze Zahlen ein![0...Ende]");

            do
            {
                Console.Write($"Zahl {++idx}: ");
                num = Convert.ToInt32(Console.ReadLine());
                if (num != 0)
                {
                    //Verarbeitung (V)
                    sum = sum + num;
                    if (num > max)
                    {
                        prvMax = max;
                        max = num;
                    }
                    else if(num < max && num > prvMax)
                    {
                        num = prvMax;
                    }
                    if (num < min)
                    {
                        min = num;
                    }

                    average = sum / (double)idx;
                }
                else if(idx <= 1)
                {
                    Console.WriteLine("Es wurden keine Zahlen eingegeben!");
                }

            } while (num != 0);

            //Audgabe (A)
            if (idx > 1)
            {
                Console.WriteLine($"Sie haben {idx - 1} Zahlen eingegeben.");
                Console.WriteLine($"Die Summe der eingegebenen Zahlen ist {sum}");
                Console.WriteLine($"Der Maximalwert ist {max}");
                if (idx > 2)
                {
                    Console.WriteLine($"Die zweitgrößte Zahl ist {prvMax}");
                }
                else
                {
                    Console.WriteLine("Es gibt keine zweitgrößte Zahl, da weniger als zwei Zahlen eingegeben wurden!");
                }
                Console.WriteLine($"Der Minimalwert ist {min}");
                Console.WriteLine($"Der Durchschnittswert beträgt {average:n2}");

            }

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
