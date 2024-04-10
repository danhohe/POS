/*--------------------------------------------------------------------------
 *              HTBLA-Leonding / Class: 3ABIF
 *--------------------------------------------------------------------------
 *              Hoheneder Daniel
 *--------------------------------------------------------------------------
 * Description: Das Programm errechnet zu einer vom User eingegeben Zahl 
 * eine ganzzahlige Schätzung des Logarithmus Dualis.
 *------------------------------------------------------------------------*/

#nullable disable
namespace starSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            int n, count = 0;
            bool isFinished = false;

            Console.Write("Geben sie eine ganze positive Zahl ein: ");
            input = Console.ReadLine();
            n = Convert.ToInt32(input);

            while(isFinished != true)
            {
                n = n / 2;
                

                if (n >= 1)
                {
                    count++;
                }
                else if (n == 0)
                {
                    isFinished = true;
                }
            }

            Console.WriteLine($"Ergebnis: {input} kann {count}x durch 2 dividiert werden!");

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}