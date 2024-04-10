/*-------------------------------------------------------------------------
*               HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*               Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Das Programm stellt den Vorgang des Geldabhebens bei einem
* Bankomaten dar. Bei 3 falschen Pin eingaben wird die Karte einbehalten
* und es wird keine Auszahlung erfolgen. Wen der angeforderte Betrag nicht
* verfügbar ist wird ein anderer Betrag gefordert.
*--------------------------------------------------------------------------
*/

#nullable disable
namespace cashMachine
{

    class Program
    {
        static void Main(string[] args)
        {
            const string PIN_CODE = "1573";
            string pinInput;
            const int CASH_AVAILABLE = 100000, OVERDRAFT = 15000;
            int balance = 51035, idx = 1, amount = 0, fullBalance;
            bool isPinCorrect = false;

            Console.WriteLine("----------------");
            Console.WriteLine("| Cash Machine |");
            Console.WriteLine("----------------");


            fullBalance = balance + OVERDRAFT;
            do
            {
                Console.WriteLine("Bitte geben sie ihre 4 stellige Pin ein!");
                Console.Write($"{idx}. Versuch: ");
                pinInput = Console.ReadLine();
                if (PIN_CODE == pinInput)
                {
                    isPinCorrect = true;
                    idx = 4;
                }
                else
                {
                    Console.WriteLine("Falsche PIN!");
                    idx++;
                }
            } while (idx <= 3);

            Console.WriteLine();

            if (isPinCorrect)
            {
                idx = 1;
                
                Console.WriteLine($"Aktueller Kontostand: {balance} EUR");
                Console.WriteLine($"{OVERDRAFT} EUR Überziehungsrahmen");
                Console.WriteLine($"Zur Auszahlung verfügbarer Betrag: {fullBalance} EUR");
            }
            else if (isPinCorrect != true)
            {
                Console.WriteLine("Es wurden 3 falsche PIN Eingaben getätigt.");
                Console.WriteLine("Die Karte wird einbehalten. Bitte kontaktieren sie ihren Bankberater!");
            }
            Console.WriteLine();

            while (idx <= 2)
            {
                Console.Write("Bitte geben sie den Betrag ein den sie abheben möchten ein: ");
                amount = Convert.ToInt32(Console.ReadLine());

                if (isPinCorrect && ((amount <= CASH_AVAILABLE) && (amount <= fullBalance)))
                {
                    idx = 3;
                    Console.WriteLine();
                    Console.WriteLine($"Der Betrag von {amount} EUR wird ausgezahlt...");
                    fullBalance = balance - amount;
                }
                else
                {
                    Console.WriteLine("Der Betrag ist nicht verfügbar!");
                }

                idx++;
            }

            Console.WriteLine();

            if (isPinCorrect && (amount <= (balance + OVERDRAFT)))
            {
                Console.WriteLine($"Neuer Kontostand: {fullBalance} EUR");
            }

            Console.WriteLine();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
