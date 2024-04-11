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
            TestVocabulary(ref words);
            SortVocabulary(ref words);
            PrintVocabulary(ref words);
            WriteToCsvFile(words, "VocabTestResults.csv");
        }

        private static void SortVocabulary(ref Word[] words)
        {
            for(int i = 0; i < words.Length; i++)
            {
                for(int j = 0; j < words.Length - i - 1; j++)
                {
                    if(words[j].Fails > words[j + 1].Fails)
                    {
                        Swap(words[j], words[j + 1]);
                    }
                }
            }
        }

        private static void Swap(Word word1, Word word2)
        {
            Word helper = word1;
            word1 = word2;
            word1 = helper;
        }

        private static void WriteToCsvFile(Word[] words, string csv)
        {
            string[] text = new string[words.Length];
            for(int i = 0; i < words.Length; i++)
            {
                text[i] = words[i].GermanWord + ";" + words[i].EnglishWord + ";" + words[i].Fails + ";" + words[i].Hits;
            }

            File.WriteAllLines(csv, text);
        }

        private static void PrintVocabulary(ref Word[] words)
        {
            Console.WriteLine("Ergebnis des Vokabeltests");
            Console.WriteLine("=========================");
            Console.WriteLine($"{"deutsch"}{"englisch"}{"falsch"}{"richtig"}");
            Console.WriteLine($"{"-------"}{"--------"}{"------"}{"-------"}");
            for(int i = 0; i < words.Length; i++)
            {
                Console.WriteLine($"{words[i].GermanWord}{words[i].EnglishWord}{words[i].Fails}{words[i].Hits}");
            }
        }

        private static void TestVocabulary(ref Word[] words)
        {
            string input;
            bool exitLoop = false;
            Random random = new Random();
            do
            {
            int randomWord = random.Next(0, words.Length - 1);
            Console.WriteLine("Beenden mit Eingabetaste");
            Console.Write($"{words[randomWord].GermanWord}: ");
            input = Console.ReadLine();
            if(string.IsNullOrEmpty(input))
            {
                exitLoop = true;
            }
            else if(input == words[randomWord].EnglishWord)
            {
                Console.WriteLine("Richtig!");
                words[randomWord].Hits += 1;
            }
            else if (input != words[randomWord].EnglishWord)
            {
                Console.WriteLine("Leider falsch!");
                words[randomWord].Fails += 1;
            }

            }while (exitLoop == false);
        }

        private static Word[] ReadFromCsvFile(string csv)
        {
            string[] lines = File.ReadAllLines(csv);
            Word[] result = new Word[lines.Length - 1];

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
            result.Fails = 0;
            result.Hits = 0;
            return result;
        }

        private static void PrintHeader()
        {
            Console.WriteLine("==========VOKABELTRAINER==========");
            Console.WriteLine();
        }
    }
}