#nullable disable
namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {

            PrintHeader();

            StartProgram();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
        private static void StartProgram()
        {
            int r, c;
            int[,] array = null;
            string input = string.Empty;
            ConsoleColor defaultColor = Console.ForegroundColor;
            do
            {
                r = GetArrayDimension("Zeilen?         ");
                c = GetArrayDimension("Spalten?        ");
                array = CreateMatrix(r, c);
                CompareAndPrintMatrix(array);

                Console.ForegroundColor = defaultColor;
                Console.Write("Neue Matrix? (j=ja) ");
                input = Console.ReadLine();
            } while (input.ToLower() == "j");
        }
        private static void CompareAndPrintMatrix(int[,] array)
        {
            int[,] result = array;
            CompareVertically(result);
        }
        private static void CompareVertically(int[,] result)
        {
            for (int r = 0; r < result.GetLength(0); r++)
            {
                if (r % 2 == 0)
                {
                    CompareHorizontally(result, r);
                }
                else
                {
                    for (int c = 0; c < result.GetLength(1); c += 2)
                    {
                        switch (result[r - 1, c].CompareTo(result[r + 1, c]))
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write($"A   ");
                                break;
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("=   ");
                                break;
                            case -1:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("V   ");
                                break;
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
        private static void CompareHorizontally(int[,] result, int r)
        {
            for (int c = 1; c < result.GetLength(1) - 1; c += 2)
            {
                switch (result[r, c - 1].CompareTo(result[r, c + 1]))
                {
                    case 1:
                        if (c == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{result[r, c - 1]}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" > ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{result[r, c + 1]}");
                        }
                        else if (c < result.GetLength(1) - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" > ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{result[r, c + 1]}");
                        }

                        break;
                    case 0:
                        if (c == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{result[r, c - 1]}");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($" = ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{result[r, c + 1]}");
                        }
                        else if (c < result.GetLength(1) - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($" = ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{result[r, c + 1]}");
                        }
                        break;
                    case -1:
                        if (c == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{result[r, c - 1]}");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" < ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{result[r, c + 1]}");
                        }
                        else if (c < result.GetLength(1) - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" < ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{result[r, c + 1]}");
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine();
        }
        private static int[,] CreateMatrix(int rows, int columns)
        {
            int[,] result = new int[rows + (rows - 1), columns + (columns - 1)];
            for (int r = 0; r < result.GetLength(0); r++)
            {
                if (r % 2 == 0)
                {

                    for (int c = 0; c < result.GetLength(1); c++)
                    {
                        if (c % 2 != 0 && c > 0)
                        {
                            String.Join(" ", result[r, c]);
                        }
                        else
                        {
                            result[r, c] = Random.Shared.Next(1, 10);
                        }
                    }
                }
                else
                {
                    for (int c = 0; c < result.GetLength(1); c += 2)
                    {
                        String.Join(" ", result[r, c]);
                    }
                }
            }
            return result;
        }
        private static int GetArrayDimension(string text)
        {
            string input = string.Empty;
            int result;
            Console.Write($"{text}");
            input = Console.ReadLine();
            while (!Int32.TryParse(input, out result))
            {
                Console.WriteLine("Bitte nur ganze Zahlen eingeben!");
            }
            return result;
        }
        private static void PrintHeader()
        {
            Console.WriteLine("Matrix");
            Console.WriteLine("======");
        }
    }
}