/*-------------------------------------------------------------------------
*               HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*               Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Es werden mehrere Parameter von verschiedenen Artikeln
* erfragt und eingelesen. Es wird auch gefragt ob noch weitere Artikel
* eingegeben werden. Am Ende wird eine Rechnung formatiert ausgegeben.
*--------------------------------------------------------------------------
*/

#nullable disable
namespace shoppingCart
{

    class Program
    {
        static void Main(string[] args)
        {
            string article, present, input;
            int idx = 0, amount;
            double netPrice = 0, amountPrice, fullPrice = 0, presentPrice = 0, price, articlePrice, tax;

            Console.WriteLine("*****************");
            Console.WriteLine("* Shopping Cart *");
            Console.WriteLine("*****************");
            Console.WriteLine();
            Console.WriteLine();

            //Eingabe
            do
            {
                Console.WriteLine($"Eingabe von Produkt Nr. {++idx}");
                Console.Write("Netto-Stückpreis: ");
                price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Stückzahl: ");
                amount = Convert.ToInt32(Console.ReadLine());
                Console.Write("Geschenkoption((j)a/(n)ein)? ");
                present = Console.ReadLine();

                //Verarbeitung
                amountPrice = price * amount;
                Console.WriteLine($"=> Nettopreis = {amountPrice:n2} EUR");
                if (present == "j")
                {
                    presentPrice = 2.50 * amount;
                    Console.WriteLine($"=> zuzügl. Geschenksoption = {presentPrice:n2} EUR");
                }
                articlePrice = amountPrice + presentPrice;
                netPrice = netPrice + articlePrice;
                Console.Write("Ein weiteres Produkt eingeben ((j)a/(n)ein)? ");
                article = Console.ReadLine();
            } while (article == "j");

            Console.Write("Lieferung nach de oder at? ");
            input = Console.ReadLine();
            if (input == "de")
            {
                fullPrice = netPrice * 1.19;
            }
            else if (input == "at")
            {
                fullPrice = netPrice * 1.20;              
            }

            //Ausgabe
            Console.WriteLine();
            Console.WriteLine("=================================================");
            Console.WriteLine("Ihre Einkaufsrechnung");
            Console.WriteLine("=================================================");
            Console.WriteLine();
            Console.WriteLine($"Nettopreis gesamt:{netPrice, 27:n2} EUR");
            if (fullPrice <= 29.00)
            {
                Console.WriteLine("Versandkosten:                           5.90 EUR");
                fullPrice = fullPrice + 5.90;
                
            }
            Console.WriteLine($"Gesamtpreis:{fullPrice, 33:n2} EUR");
            Console.WriteLine("=================================================");
            switch (input)
            {
                case "at":
                    tax = fullPrice / 6;
                    Console.WriteLine($"Darin enthalten sind 20,00% MWSt:{tax, 12:n2} EUR");
                    break;
                case "de":
                    tax = (fullPrice / 119) * 19;
                    Console.WriteLine($"Darin enthalten sind 19,00% MWSt:{tax, 12:n2} EUR");
                    break;
            }
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}

