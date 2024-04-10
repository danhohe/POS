#nullable disable

namespace BinaryAdder
{
    class Program
    {
        static void Main(string[] args)
        {
            string x, y, z;

            Console.WriteLine("Binäraddierer");
            Console.WriteLine("=============");


            AddZeros(out x, out y);

            z = AddBinary(x, y);


            Console.WriteLine($"{x} + {y} = {z}");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        private static string AddBinary(string x, string y)
        {
            string z = string.Empty;
            int carry = 0, counter = 0;

            for (int i = x.Length - 1; i >= 0; i--)
            {
                int a = x[i] - '0';
                int b = y[i] - '0';
                int sum = a + b + carry;
                carry = sum / 2;
                z = (sum % 2) + z;
                counter++;
                if (counter % 8 == 0)
                {
                    z = ' ' + z;
                }
            }

            if (carry > 0)
            {
                z = carry + ' ' + z;
            }

            return z;
        }

        private static void AddZeros(out string x, out string y)
        {
            x = ReadBinaryNumber(1);
            y = ReadBinaryNumber(2);

            if (x.Length > y.Length)
            {
                x = '0' + x;
                for (int i = 0; i < x.Length; i++)
                {
                    y = '0' + y;
                }
            }
            else if (y.Length > x.Length)
            {
                y = '0' + y;
                for (int i = 0; i < y.Length; i++)
                {
                    x = '0' + x;
                }
            }
            else
            {
                x = '0' + x;
                y = '0' + y;
            }

        }

        private static string ReadBinaryNumber(int i)
        {
            string result;
            bool isBinary = true;
            do
            {
                Console.Write($"Dualzahl {i} eingeben: ");
                result = Console.ReadLine();
                isBinary = IsBinary(result);
                if (!isBinary)
                {
                    Console.WriteLine("Nur 1 und 0 ist in Binärzahlen erlaubt!");
                }
            } while (!isBinary);

            return result;
        }
        public static bool IsBinary(string number)
        {
            bool result = true;

            for (int i = 0; i < number.Length && result; i++)
            {
                result = number[i] == '0' || number[i] == '1';
            }

            return result;
        }
    }
}