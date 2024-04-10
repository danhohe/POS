using System.IO;
using System.Runtime.Loader;
using System.Text;
using System.Xml.XPath;
#nullable disable
namespace LottoChecker
{
    class Program
    {
        static string FileName = "LottoTipps.csv";
        static string CorrectFileName = @"/Users/danielhoheneder/Desktop/Schule/POS/LottoChecker/ValidLottoTips.csv";
        static string IncorrectFileName = @"/Users/danielhoheneder/Desktop/Schule/POS/LottoChecker/InvalidLottoTips.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("LottoChecker");
            Console.WriteLine("============");

            LottoTipp[] tipps = ReadTippsFromFile(FileName);
            LottoTipp[] correctTips = GetCorrectTips(tipps);
            LottoTipp[] incorrectTips = GetIncorrectTips(tipps);
            string[] arrayCorrect = ConvertToCsvString(correctTips);
            string[] arrayIncorrect = ConvertToCsvString(incorrectTips);
            File.WriteAllLines(CorrectFileName, arrayCorrect);
            File.WriteAllLines(IncorrectFileName, arrayIncorrect);

            Console.WriteLine("Incorrect Tips:");
            PrintTips(incorrectTips);

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
        private static string[] ConvertToCsvString(LottoTipp[] tips)
        {
            string[] result = new string[tips.Length];
            for (int i = 0; i < tips.Length; i++)
            {
                result[i] = $"{tips[i].Id};{tips[i].Numbers[0]};{tips[i].Numbers[1]};{tips[i].Numbers[2]};{tips[i].Numbers[3]};{tips[i].Numbers[4]};{tips[i].Numbers[5]}"; 
            }
            return result;
        }
        private static void PrintTips(LottoTipp[] tips)
        {
            for (int i = 0; i < tips.Length; i++)
            {
                Console.WriteLine($"{tips[i].Id}{tips[i].Numbers[0],3}{tips[i].Numbers[1],3}{tips[i].Numbers[2],3}{tips[i].Numbers[3],3}{tips[i].Numbers[4],3}{tips[i].Numbers[5],3}");
            }
        }
        private static LottoTipp[] GetIncorrectTips(LottoTipp[] tipps)
        {
            List<LottoTipp> result = new List<LottoTipp>();

            for (int i = 0; i < tipps.Length; i++)
            {
                if (!IsTipValid(tipps[i]))
                {
                    result.Add(tipps[i]);
                }
            }
            return result.ToArray();
        }
        private static LottoTipp[] GetCorrectTips(LottoTipp[] tipps)
        {
            List<LottoTipp> result = new List<LottoTipp>();

            for (int i = 0; i < tipps.Length; i++)
            {
                if (IsTipValid(tipps[i]))
                {
                    result.Add(tipps[i]);
                }
            }
            return result.ToArray();
        }
        private static LottoTipp[] ReadTippsFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            LottoTipp[] tipp = new LottoTipp[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                LottoTipp tip = new LottoTipp();
                string[] parts = lines[i].Split(';');
                tip.Id = parts[0];
                tip.Numbers[0] = int.Parse(parts[1]);
                tip.Numbers[1] = int.Parse(parts[2]);
                tip.Numbers[2] = int.Parse(parts[3]);
                tip.Numbers[3] = int.Parse(parts[4]);
                tip.Numbers[4] = int.Parse(parts[5]);
                tip.Numbers[5] = int.Parse(parts[6]);

                tipp[i] = tip;
            }

            return tipp;
        }
        static bool IsTipValid(LottoTipp tipp)
        {
            bool result = true;

            for (int i = 0; i < tipp.Numbers.Length && result; i++)
            {
                if (tipp.Numbers[i] < 1
                    || tipp.Numbers[i] > 45
                    || CountNumberInTip(tipp.Numbers[i], tipp) != 1)
                {
                    result = false;
                }
            }
            return result;
        }
        static int CountNumberInTip(int number, LottoTipp tipp)
        {
            int result = 0;

            for (int i = 0; i < tipp.Numbers.Length; i++)
            {
                if (tipp.Numbers[i] == number)
                {
                    result++;
                }
            }
            return result;
        }
    }
}