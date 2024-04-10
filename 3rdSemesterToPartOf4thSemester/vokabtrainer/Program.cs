/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Der Experte gibt ein englisches Wort ein und die dazugehörige
 * Übersetzung. Der Inhalt der Konsole wird anschließend gelöscht und der
 * Schüler wird aufgefordert die Übersetzung des Wortes einzugeben.
 * Stimmt das eingegebene Wort nicht mit der Lösung überein wird eine 
 * Fehlermeldung ausgegeben und erneut eine Eingabe angefordert.
 *------------------------------------------------------------------------*/

#nullable disable
using System.Collections;
using System.Runtime.InteropServices;

namespace vokabTrainer
{
    class Program
    {
        public static void Main(string[] args)
        {
            string englishInput, germanInput, studentInput;
            int i = 0;
            bool isAnswerCorrect = true;

            //Eingabe (E)
            Console.WriteLine("*------------------------------------*");
            Console.WriteLine("*            Vokabeltrainer          *");
            Console.WriteLine("*------------------------------------*");
            Console.WriteLine("*           Expertenabschnitt        *");
            Console.WriteLine("*------------------------------------*");
            Console.Write("Englisches Wort: ");
            englishInput = Console.ReadLine();
            Console.Write("Deutsche Übersetzung: ");
            germanInput = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("*------------------------------------*");
            Console.WriteLine("*            Schülerabschnitt        *");
            Console.WriteLine("*------------------------------------*");
            Console.WriteLine($"Gib die deutsche Übersetzung für {englishInput} ein:");

            //Verarbeitung (V)
            do
            {
                i++;
                Console.WriteLine();
                Console.Write($"Versuch {i}: ");
                studentInput = Console.ReadLine();
                if (studentInput == germanInput)
                {
                    isAnswerCorrect = false;
                }
                else
                {
                    Console.WriteLine("Leider Falsch bitte erneut versuchen");
                }
            }while (isAnswerCorrect && i < 10);

            //Ausgabe (A)
            switch (i)
            {
                case 1:
                    Console.WriteLine("Ausgezeichnet, sofort gewusst!");
                    break;
                case 10:
                    Console.WriteLine("Das war wohl nichts!!");
                    break;
                default:
                    break;
            }

            if (i == 2 || i == 3)
            {
                Console.WriteLine($"Gut gemacht, nur {i} Versuche!");
            }
            else if (i == 4 || i == 5)
            {
                Console.WriteLine("Ein bisschen üben, das wird schon.");
            }
            else if (i < 10 && i > 5)
            {
                Console.WriteLine("Üben, üben, üben!");
            }
            
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}