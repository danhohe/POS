#nullable disable
using System.Diagnostics;

namespace SortAlgorithm.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = CreateRandomArray(20);

            PrintArray(array);
            BubbleSort(array);
            PrintArray("BubbleSort:", array);


            Stopwatch sw = new Stopwatch();
            int[] parray1 = CreateRandomArray(100_000);
            int[] parray2 = (int[])parray1.Clone();

            sw.Start();
            BubbleSort(parray1);
            sw.Stop();
            Console.WriteLine($"Zeit[ms]: {sw.ElapsedMilliseconds}");

            // Weitere Zeitmessung
            sw.Restart();
            Array.Sort(parray2);
            sw.Stop();
            Console.WriteLine($"Zeit[ms]: {sw.ElapsedMilliseconds}");


            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
        private static void PrintArray(string title, int[] array)
        {
            Console.WriteLine($"{title}");
            PrintArray(array);
        }

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0)
                {
                    Console.Write(" ");
                }
                Console.Write(array[i]);
            }
            Console.WriteLine();
        }

        private static int[] CreateRandomArray(int size)
        {
            return CreateRandomArray(size, 0, size);
        }

        private static int[] CreateRandomArray(int size, int min, int max)
        {
            int[] result = new int[size];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Random.Shared.Next(min, max);
            }

            return result;
        }

        private static void BubbleSort(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                }
            }
        }
    }
}
