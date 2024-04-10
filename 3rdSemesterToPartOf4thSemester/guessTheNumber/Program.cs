/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Das Spiel Zahlenraten basiert auf einer zufällig
 * generierten Zahl die der User herausfinden muss.
 *------------------------------------------------------------------------*/

#nullable disable

namespace guessTheNumber
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int guessNumber = random.Next(1, 101);
            int i = 1, n;
            string input;
            bool isNumberCorrect = false;

            Console.WriteLine("Versuche meine Zahl zu erraten <1-100>!");
            Console.WriteLine("Spielabbruch mit 'e' oder 'E'");
            
            //Eingabe (E) & Verarbeitung (V)
            do
            {
                Console.Write($"{i}. Versuch: ");
                input = Console.ReadLine();
                n = Convert.ToInt32(input);

                if (n < guessNumber)
                {
                    Console.WriteLine("Gesuchte Zahl ist größer.");
                }
                else if (n > guessNumber)
                {
                    Console.WriteLine("Gesuchte Zahl ist kleiner.");
                }
                else if (n == guessNumber)
                {
                    isNumberCorrect = true;
                }
                i++;
            }while (isNumberCorrect != true && (input != "e" || input != "E"));

            //Ausgabe (A)
            if (i <= 5)
            {
                Console.WriteLine("Tolle Leistung!");
            }
            else if (i >= 6 && i <=10)
            {
                Console.WriteLine("Schon ganz gut!");
            }
            else if (i >10)
            {
                Console.WriteLine("Endlich geschafft!");
            }
        }
    }
}