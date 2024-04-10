/*-------------------------------------------------------------------------
*               HTBLA-Leonding / Class: 3ABIF
*--------------------------------------------------------------------------
*               Hoheneder Daniel
*--------------------------------------------------------------------------
*Description: Einlesen von 3 Zahlenwerten und dann ermitteln und ausgeben
* welche der Zahlen die größte und welche die kleinste ist. 
*--------------------------------------------------------------------------
*/

using System;

namespace MaxOf3Values
{

    class Program
    {
        static void Main(string[] args)
        {
            double num1, num2, num3, max = 0, min = 0;

            Console.WriteLine("Welcome to Max of 3 Values!");
            Console.WriteLine("===========================");

            //Eingabe
            Console.Write("Enter the first number:  ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the second number: ");
            num2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the third number:  ");
            num3 = Convert.ToDouble(Console.ReadLine());

            //Verarbeitung
            if(num1 >= num2 && num1 >= num3)
            {
                max = num1;
                if(num2 >= num3)
                {
                    min = num3;
                }
                else if(num2 <= num3)
                {
                    min = num2;
                }

            }
            else if(num2 >= num1 && num2 >= num3)
            {
                max = num2;
                if (num1 >= num3)
                {
                    min = num3;
                }
                else if (num1 <= num3)
                {
                    min = num1;
                }

            }
            else if(num3 >= num1 && num3 >= num2)
            {
                max = num3;
                if (num2 >= num1)
                {
                    min = num1;
                }
                else if (num2 <= num1)
                {
                    min = num2;
                }

            }

            Console.WriteLine();

            //Ausgabe
            Console.WriteLine($"The Max of 3 Values is: {max}");
            Console.WriteLine($"The Min of 3 Values is: {min}");
            Console.WriteLine();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
