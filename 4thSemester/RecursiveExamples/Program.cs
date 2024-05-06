#nullable disable

namespace RecursiveExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            RunApp();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        private static void RunApp()
        {
            int a = 0, b = 0;
            string input = string.Empty;
            bool isNumber = false;
            Console.Write("Geben sie eine Zahl zur Berechnung mit den verschiedenen Funktionen oder ein Wort für die Palindromerkennung ein: ");
            input = Console.ReadLine();
            isNumber = Int32.TryParse(input, out a);
            if (isNumber)
            {
                Console.Write("Bitte geben sie eine zweite Zahl für den Addierer und Multiplizierer sowie den Euklidischen Algorithmus: ");
                input = Console.ReadLine();
                Int32.TryParse(input, out b);
                Console.WriteLine("Fakultät: " + FacultyRecursive(a));
                Console.WriteLine("Addierer: " + AddRecursive(a, b));
                Console.WriteLine("Multiplizierer: " + MultiplyRecursive(a, b));
                Console.WriteLine("ggt: " + EuklidicAlgorithm(a, b));
                Console.WriteLine("Primzahl: " + CheckIsNumberPrime(a));
                Console.WriteLine("Rekursive Funktion: " + RecursiveFunction(a));
            }
            else
            {
                Console.WriteLine("Palindrom: " + DetectPalindrom(input));
            }

        }

        private static long RecursiveFunction(int a)
        {
            if (a == 1)
            {
                return 1;
            }
            else
            {
                return RecursiveFunction(a - 1) + 2 * a - 1;
            }
        }

        private static bool DetectPalindrom(string input)
        {
            if (input == string.Empty || input.Length == 1)
            {
                return true;
            }
            else if (input[0] != input[input.Length - 1])
            {
                return false;
            }
            else
            {
                return DetectPalindrom(input.Substring(1, input.Length - 2));
            }
        }

        private static bool CheckIsNumberPrime(int a, int n = 2)
        {
            if (a <= 2)
            {
                return (a == 2);
            }
            else if (a % n == 0)
            {
                return false;
            }
            else if (n > a / 2)
            {
                return true;
            }
            else
            {
                return CheckIsNumberPrime(a, n + 1);
            }

        }

        private static long EuklidicAlgorithm(int a, int b)
        {
            
            if (a == b)
            {
                return a;
            }
            else if (a > b)
            {
                return EuklidicAlgorithm(a - b, b);
            }
            else
            {
                return EuklidicAlgorithm(a, b - a);
            }
        }

        private static long MultiplyRecursive(int a, int b)
        {
            //multiplier
            //nicht rekursiv
            if (a == 0 || b == 0)
            {
                return 0;
            }
            else if(a == 1)
            {
                return b;
            }
            else if(b == 1)
            {
                return a;
            }
            //multiplier
            //rekursiv
            else
            {
                return a + MultiplyRecursive(a, b - 1);
            }
        }

        private static long AddRecursive(int a, int b)
        {
            //Adder
            //nicht rekursiv
            if (a == 0 && b == 0)
            {
                return 0;
            }
            else if (a == 0 && b != 0)
            {
                return b;
            }
            else if (a != 0 && b == 0)
            {
                return a;
            }
            //Adder
            //rekursiv
            else
            {
                return AddRecursive(a + 1, b - 1);
            }
        }

        private static long FacultyRecursive(int a)
        {
            //nicht rekursiv
            if (a == 0 || a == 1)
            {
                return 1;
            }
            //rekursiv
            else
            {
                return a * FacultyRecursive(a - 1);
            }
        }
    }
}
