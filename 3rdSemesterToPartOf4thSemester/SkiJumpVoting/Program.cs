#nullable disable

namespace SkiJumpVoting
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            double resultDistance, resultPosture, resultAll;
            double[] postureGrades = new double[5];
            Console.WriteLine("Notenermittlung für Skispringer");
            Console.WriteLine("===============================");
            GetDistance(out x);
            GetPostureGrade(out postureGrades);
            resultDistance = SumDistancePoints(x);
            resultPosture = SumPosturePoints(postureGrades);
            resultAll = SumAllUp(resultDistance, resultPosture);
            Console.WriteLine();
            Console.WriteLine($"Weitenpunkte: {resultDistance} Haltungsnoten: {resultPosture} Gesamt: {resultAll}");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        private static double SumAllUp(double resultDistance, double resultPosture)
        {
            double result = 0;
            result = resultDistance + resultPosture;
            return result;
        }

        private static double SumPosturePoints(double[] postureGrades)
        {
            double result = 0;
            Array.Sort(postureGrades);
            for (int i = 1; i < postureGrades.Length - 1; i++)
            {
                result += postureGrades[i];
            } 
            return result;
        }

        private static double SumDistancePoints(int x)
        {
            double result = 0;
            if (x > 120)
            {
                result = 60 + ((x - 120) * 1.8); 
            }
            else if ( x == 120)
            {
                result = 60;
            }
            else if(x < 120)
            {
                result = 60 - ((120 - x) * 1.8);
            }
            return result;
        }

        private static void GetPostureGrade(out double[] postureGrades)
        {
            int i = 0;
            string input;
            double[] postures = new double[5];
            while (i < 5)
            {
                Console.Write($"Wertungsrichter {i + 1} [0-20]: ");
                input = Console.ReadLine();
                double.TryParse(input, out postures[i]);
                if(postures[i] <= 20 && postures[i] >= 0 && postures[i] % 0.5 == 0)
                {
                    i++;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe!");
                }
            }
            postureGrades = postures;
        }

        
        private static void GetDistance(out int x)
        {
            string input;
            Console.Write("Weite in Metern [0-200]: ");
            input = Console.ReadLine();
            Int32.TryParse(input, out x);
            Console.WriteLine();
        }
    }
}