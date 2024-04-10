#nullable disable

namespace SimpleMethods
{
    class Program
    {
        static string input, userInput;
        static int choice, x, y;

        static void Main(string[] args)
        {
            Console.WriteLine("*************");
            Console.WriteLine("* Hauptmenü *");
            Console.WriteLine("*************");
            do
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Anzahl der Sterne: ");
                        WriteStars(GetIntParameter());
                        break;
                    case 2:
                        Console.Write("Wie oft soll die Ausgabe erfolgen: ");
                        WriteCharacters(GetIntParameter(), GetCharParameter());
                        break;
                    case 3:
                        Console.Write("Eingabetext: ");
                        Console.WriteLine($"Die Summe der Ziffern beträgt: {SumOfDigits(Console.ReadLine())}");
                        ToProceed();
                        break;
                    case 4:
                        Console.Write("Eingabetext: ");
                        userInput = Console.ReadLine();
                        Console.Write("Anfangsposition: ");
                        x = GetIntParameter();
                        Console.Write("Länge des Substring: ");
                        y = GetIntParameter();
                        Console.WriteLine($"Ausgabetext: {SubString(userInput, x, y)}");
                        ToProceed();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Bitte neu wählen!");
                        break;
                }
                PrintMenu();
                GetMenuChoice();
            } while (choice != 0);

            Console.WriteLine();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        private static string SubString(string userInput, int x, int y)
        {
            string output = string.Empty;
            if(y > userInput.Length)
            {
                y = userInput.Length;
            }
            else if(x > userInput.Length)
            {
                Console.WriteLine("Anfangsposition zu groß!");
                Console.Write("Neue Anfangposition: ");
                x = GetIntParameter();
            }
            for( int i = x; i < x + y; i++ )
            {
                output += userInput[i];
            }
            return output;
        }

        private static int SumOfDigits(string digitAndChars)
        {
            int sum = 0;
            for (int i = 0; i < digitAndChars.Length; i++)
            {
                if (digitAndChars[i] >= '0' && digitAndChars[i] <= '9')
                {
                    sum += digitAndChars[i] - 48;
                }
            }
            return sum;
        }

        private static string GetCharParameter()
        {
            bool isChar = false;
            Console.Write("Geben sie ein Zeichen ein: ");
            do
            {
                input = Console.ReadLine();
                if (input.Length == 1)
                {
                    isChar = true;
                }
                else
                {
                    Console.WriteLine("Bitte nur ein Zeichen eingeben!");
                }
            } while (isChar != true);
            return input;
        }

        private static void WriteCharacters(int n, string character)
        {
            string result = string.Empty;
            while (n > 0)
            {
                result += character;
                n--;
            }
            Console.WriteLine($"{result}");
            ToProceed();
        }

        private static int GetIntParameter()
        {
            int n;
            input = Console.ReadLine();
            Int32.TryParse(input, out n);
            return n;
        }

        private static void PrintMenu()
        {
            Console.WriteLine("1.WriteStars");
            Console.WriteLine("2.WriteCharacters");
            Console.WriteLine("3.SumOfDigits");
            Console.WriteLine("4.SubString");
            Console.WriteLine("0 = Ende");
        }

        private static void WriteStars(int v)
        {
            for (int i = 0; i < v; i++)
            {
                Console.Write("* ");
            }
            ToProceed();
        }

        private static int GetMenuChoice()
        {
            input = Console.ReadLine();
            Int32.TryParse(input, out choice);
            Console.Clear();
            return choice;
        }

        private static void ToProceed()
        {
            Console.WriteLine();
            Console.WriteLine("press any key to proceed...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}