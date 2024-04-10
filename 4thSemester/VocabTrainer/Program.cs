#nullable disable





namespace VocabTrainer
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
            PrintHeader();
            Word[] words = ReadFromCsvFile("vocabulary.csv");
            TestVocabulary(words);
        }

        private static void TestVocabulary(Word[] words)
        {
            throw new NotImplementedException();
        }

        private static Word[] ReadFromCsvFile(string csv)
        {
            string[] lines = File.ReadAllLines(csv);
            Word[] result = new Word[lines.Length];

            for(int i = 1; i < lines.Length; i++)
            {
                result[i - 1] = CreateWordPair(lines[i]);
            }
            return result;
        }

        private static Word CreateWordPair(string text)
        {
            string[] data = text.Split(';');
            Word result = new Word();
            result.GermanWord = data[0];
            result.EnglishWord = data[1];
            return result;
        }

        private static void PrintHeader()
        {
            Console.WriteLine("==========VOKABELTRAINER==========");
            Console.WriteLine();
        }
    }
}