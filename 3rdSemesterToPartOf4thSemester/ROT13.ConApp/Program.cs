#nullable disable
using System.Security.Cryptography;

namespace ROT13.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, encrypt, decrypt;
            Console.Write("Geben sie eine Zeichenfolge ein: ");
            input = Console.ReadLine();

            encrypt = CryptText(input);

            Console.WriteLine($"Der Text ist: {encrypt}");

            decrypt = CryptText(encrypt);
            Console.WriteLine($"Der Text ist: {decrypt}");

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        static string CryptText(string text)
        {
            string result = string.Empty;
            
            for (int i = 0; i < text.Length; i++)
            {
                char chr = char.ToUpper(text[i]);
                if (chr >= 'A' && chr <= 'M')
                {
                    result += Convert.ToChar(text[i] + 13).ToString();
                }
                else if (chr >= 'N' && chr <= 'Z')
                {
                    result += Convert.ToChar(text[i] - 13).ToString();
                }
                else
                {
                    result += Convert.ToChar(text[i]).ToString();
                }
            }
            
            return result;
        }
    }
}