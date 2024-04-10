#nullable disable
namespace DemoArray2Dimension.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = @"/Users/danielhoheneder/Desktop/Schule/TestCsvFiles/matrix.csv";
            Console.WriteLine("DemoMatrix");
            int[,] matrix = ReadMatrixFromFile(filePath);
            PrintMatrix(matrix);
            
                        int[,] m = CreateRandomMatrix(5, 7);
                        Console.WriteLine("Unsortiert");
                        PrintMatrix(m);
                        Console.WriteLine("Sortiert");
                        SortMatrix(m);
                        PrintMatrix(m);

                        WriteToCsvFile(@"/Users/danielhoheneder/Desktop/Schule/POS/DemoArray2Dimension.ConApp/matrix.csv", m);
            

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        public static int[,] CreateRandomMatrix(int rows, int columns)
        {
            int[,] result = new int[rows, columns];

            for (int r = 0; r < result.GetLength(0); r++)
            {
                for (int c = 0; c < result.GetLength(1); c++)
                {
                    result[r, c] = Random.Shared.Next(0, 101);
                }
            }
            return result;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write($"{matrix[r, c],4}");
                }
                Console.WriteLine();

            }
            Console.WriteLine();
        }

        public static void SortMatrix(int[,] matrix)
        {
            int idx = 0;
            int[] array = new int[matrix.Length];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    array[idx] = matrix[r, c];
                    idx++;
                }
            }
            Array.Sort(array);
            idx = 0;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = array[idx];
                    idx++;
                }
            }
        }

        public static void WriteToCsvFile(string filepath, int[,] matrix)
        {
            string[] lines = new string[matrix.GetLength(0)];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                lines[r] = string.Empty;

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (c == 0)
                    {
                        lines[r] += $"{matrix[r, c]}";
                    }
                    else
                    {
                        lines[r] += $";{matrix[r, c]}";
                    }
                }
            }
            File.WriteAllLines(filepath, lines);
        }

        public static int[,] ReadMatrixFromFile(string filepath)
        {
            int[,] matrix = null;
            string[] lines = File.ReadAllLines(filepath);

            for (int r = 0; r < lines.Length; r++)
            {
                string[] values = lines[r].Split(';');
                if (matrix == null)
                {
                    matrix = new int[lines.Length, values.Length];
                }
                for (int c = 0; c < values.Length; c++)
                {
                    matrix[r, c] = Convert.ToInt32(values[c]);
                }
            }
            return matrix;
        }

    }
}