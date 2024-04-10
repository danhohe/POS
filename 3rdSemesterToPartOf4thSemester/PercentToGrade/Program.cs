/*-------------------------------------------------------------------------
*               HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*               Hoheneder Daniel
*--------------------------------------------------------------------------
*Description:
*--------------------------------------------------------------------------
*/ 

using System;

namespace PercentToGrade
{

    class Program
    {
        static void Main(string[] args)
        {
            double percent;


            Console.WriteLine("Percent to Grade!");
            Console.WriteLine();
            Console.Write("Bitte geben sie die Prozente ein, die Sie erreicht haben: ");
            percent = Convert.ToDouble(Console.ReadLine());

            if (percent >= 88)
            {
                Console.WriteLine("Sie haben die Note Sehr Gut erreicht.");
            }
            else if(percent < 88 && percent >= 75)
            {
                Console.WriteLine("Sie haben die Note Gut erreicht.");
            }
            else if (percent < 75 && percent >= 63)
            {
                Console.WriteLine("Sie haben die Note Befriedigend erreicht.");
            }
            else if (percent < 63 && percent >= 50)
            {
                Console.WriteLine("Sie haben die Note Genügend erreicht.");
            }
            else if (percent < 50 && percent >= 0)
            {
                Console.WriteLine("Sie haben leider ein Nicht Genügend.");
            }
            else if (percent < 0)
            {
                Console.WriteLine("Error");
            }

            Console.WriteLine();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
