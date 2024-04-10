#nullable disable
using System.Data.Common;
using System.IO;
using System;
using System.Diagnostics;

namespace GameOfLife
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The maximum number of rows in the game grid.
        /// </summary>
        const int MAX_ROWS = 20;
        /// <summary>
        /// The maximum number of columns in the game grid.
        /// </summary>
        const int MAX_COLS = 79;

        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            int[,] field = new int[0, 0];
            int occupancy;

            Console.Clear();
            Console.WriteLine("GameOfLife");
            Console.WriteLine("==========");
            Console.WriteLine();
            Console.WriteLine("1...Erstellen eines zufälligen Feldes (79 * 20 Zellen)");
            Console.WriteLine("2...Erstellen eines Blinkers (Blinker.csv)");
            Console.WriteLine("3...Erstellen eines Blinkers II (Blinker2.csv)");
            Console.WriteLine("4...Erstellen eines Bipols (Bipol.csv)");

            Console.WriteLine();
            Console.Write("Wählen Sie eine Option: ");
            input = Console.ReadLine();

            if (input == "1")
            {
                do
                {
                    Console.Write($"Wieviele Zellen sollen lebendig sein <Max: {MAX_ROWS * MAX_COLS}> ? ");
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out occupancy) || occupancy < 0 || occupancy > MAX_ROWS * MAX_COLS);

                field = CreateRandomField(MAX_ROWS, MAX_COLS, occupancy);
            }
            else if (input == "2")
            {
                field = ReadFieldFromCsvFile("Blinker.csv");
            }
            else if (input == "3")
            {
                field = ReadFieldFromCsvFile("Blinker2.csv");
            }
            else if (input == "4")
            {
                field = ReadFieldFromCsvFile("Bipol.csv");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe!");
            }

            Simulate(field, 5000, 500);
        }

        /// <summary>
        /// Simulates the Game of Life by iterating through the given field for a specified number of iterations.
        /// </summary>
        /// <param name="field">The initial field configuration.</param>
        /// <param name="iterations">The number of iterations to simulate.</param>
        /// <param name="delay">The delay (in milliseconds) between each iteration.</param>
        public static void Simulate(int[,] field, int iterations, int delay)
        {
            Stopwatch sw = new Stopwatch();

            PrintField(field);

            Thread.Sleep(delay);
            for (int i = 0; i < iterations && SumCellValues(field) > 0; i++)
            {
             //   Console.Clear();
                sw.Start();
                field = CreateNextGeneration(field);
                PrintField(field);
                sw.Stop();
                Console.WriteLine((sw.ElapsedMilliseconds) / 1000);

                Thread.Sleep(delay);
            }
        }

        /// <summary>
        /// Calculates the sum of all cell values in a given field.
        /// </summary>
        /// <param name="field">The 2D array representing the field.</param>
        /// <returns>The sum of all cell values.</returns>
        public static int SumCellValues(int[,] field)
        {
            int result = 0;
            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    if (field[r, c] == 1)
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Creates the next generation of the game field based on the current field.
        /// </summary>
        /// <param name="currentField">The current game field represented as a 2D array.</param>
        /// <returns>The next generation of the game field as a 2D array.</returns>
        private static int[,] CreateNextGeneration(int[,] currentField)
        {
            int rows = currentField.GetLength(0);
            int cols = currentField.GetLength(1);
            int[,] result = new int[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int liveNeighbors = CountLivingNeighbors(currentField, r, c);
                    if (currentField[r, c] == 1)
                    {
                        if (liveNeighbors < 2 || liveNeighbors > 3)
                        {
                            result[r, c] = 0;
                        }
                        else
                        {
                            result[r, c] = 1;
                        }
                    }
                    else
                    {
                        if (liveNeighbors == 3)
                        {
                            result[r, c] = 1;
                        }
                        else
                        {
                            result[r, c] = 0;
                        }
                    }
                }
            }
            return result;
        }

        private static int CountLivingNeighbors(int[,] currentField, int r, int c)
        {
            int liveNeighbors = 0;
            int rows = currentField.GetLength(0);
            int cols = currentField.GetLength(1);
            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    if (dc != 0 || dr != 0)
                    {
                        int neighborRow = r + dr;
                        int neighborCol = c + dc;
                        if (neighborRow >= 0 && neighborRow < rows &&
                            neighborCol >= 0 && neighborCol < cols &&
                            currentField[neighborRow, neighborCol] == 1)
                        {
                            liveNeighbors++;
                        }
                    }
                }
            }
            return liveNeighbors;
        }

        /// <summary>
        /// Prints the given field to the console.
        /// </summary>
        /// <param name="field">The field to be printed.</param>
        public static void PrintField(int[,] field)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    char sign = field[r, c] == 0 ? ' ' : '*';

                    Console.Write($" {sign} ");
                }
                Console.WriteLine();
            }
        }

        #region Fields
        /// <summary>
        /// Creates a random field with the specified number of rows, columns, and occupancy.
        /// </summary>
        /// <param name="rows">The number of rows in the field.</param>
        /// <param name="cols">The number of columns in the field.</param>
        /// <param name="occupancy">The desired occupancy of the field (number of cells with value 1).</param>
        /// <returns>A 2D array representing the random field.</returns>
        public static int[,] CreateRandomField(int rows, int cols, int occupancy)
        {
            int[,] field = new int[rows, cols];
            Random random = new Random();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    field[r, c] = 0;
                }
            }
            int count = 0;
            while (count < occupancy)
            {
                int r = random.Next(rows);
                int c = random.Next(cols);
                if (field[r, c] == 0)
                {
                    field[r, c] = 1;
                    count++;
                }
            }
            return field;
        }

        /// <summary>
        /// Reads a field from a CSV file and returns it as a 2D integer array.
        /// </summary>
        /// <param name="filePath">The path to the CSV file.</param>
        /// <returns>A 2D integer array representing the field read from the CSV file.</returns>
        public static int[,] ReadFieldFromCsvFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int rows = lines.Length;
            int cols = lines[0].Split(';').Length;
            int[,] field = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                string[] values = lines[r].Split(';');
                for (int c = 0; c < cols; c++)
                {
                    field[r, c] = int.Parse(values[c]);
                }
            }

            return field;
        }
        #endregion Fields
    }
}