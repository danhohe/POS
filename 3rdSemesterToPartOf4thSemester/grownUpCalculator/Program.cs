/*-------------------------------------------------------------------------
*               HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*               Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Mittels Verzweigungen ermitteln und ausgeben wann oder ob 
* der Benutzer Volljährig ist. Höfliche Bemerkungen bei gewissen Alterstufen
* ausgeben.
*--------------------------------------------------------------------------
*/

namespace grownUpCalculator
{
    class Program
    {
        static void Main()
        {
            int age, diff;
            const int GROWN_UP_AGE = 18;

            Console.Write("How old are you?     ");
            age = Convert.ToInt32(Console.ReadLine());

            diff = GROWN_UP_AGE - age;
            //first instruction
            if (diff > 0)
            {
                Console.WriteLine($"Difference: {diff}");
            }
            // second instruction
            if (age == 25 || age == 50)
            {
                Console.WriteLine("Congratulations for your round birthday");
            }
            // third instruction
            if (diff > 0)
            {
                Console.WriteLine($"In approximately {diff} years you will be grown-up");
            }
            else if (age >= 18 && age <= 20)
            {
                Console.WriteLine("You are grown up");
            }
            else
            {
                Console.WriteLine("You are too old");
            }


            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();
        }
    }
}