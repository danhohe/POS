#nullable disable
namespace SkiResults
{
    class Program
    {
        const string run1 = "results_run1.csv";
        const string run2 = "results_run2.csv";
        static void Main(string[] args)
        {
            RunApp();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
        private static void RunApp()
        {
            SkiRunner[] skiRunners = ReadFromCsvFile(run1);
            SkiRunner[] skiRunners2 = ReadFromCsvFile(run2);
            SkiRunner[] runnersResult = CreateResultTable(skiRunners, skiRunners2);
            GetMenuChoice(ref runnersResult);
        }
        private static void GetMenuChoice(ref SkiRunner[] runnersResult)
        {
            string input = string.Empty;
            int n;
            bool exit = false;
            int count = 0;
            for (int i = 0; i < runnersResult.Length; i++)
            {
                if (runnersResult[i].Rank != 999)
                {
                    count++;
                }
            }
            SkiRunner[] runnersModified = new SkiRunner[count];
            do
            {
                Console.Clear();
                PrintMenu();
                input = Console.ReadLine();
                Int32.TryParse(input, out n);
                switch (n)
                {
                    case 1:
                        PrintResult(runnersResult);
                        Console.WriteLine("press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 2:
                        PrintDisqualifiedRunners(runnersResult);
                        Console.WriteLine("press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 3:
                        runnersModified = DeleteDisqualifiedRunners(runnersResult);
                        Console.WriteLine("press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 4:
                        SaveRunnersToCsv(runnersModified);
                        Console.WriteLine("press any key to continue...");
                        Console.ReadKey();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        Console.WriteLine("only the numbers shown in the menu are valid");
                        Thread.Sleep(1500);
                        break;
                }
            } while (n != 0 || !exit);
        }
        private static void SaveRunnersToCsv(SkiRunner[] runners)
        {
            string input;
            string[] lines = new string[runners.Length];
            Console.Write("Dateiname: ");
            input = Console.ReadLine();
            for (int i = 0; i < runners.Length; i++)
            {
                lines[i] = $"{runners[i].Rank};{runners[i].Name};{runners[i].Nation};{runners[i].TimeDg1};{runners[i].TimeDg2};{runners[i].FullTime:f2}";
            }
            File.WriteAllLines(input, lines);
        }
        private static SkiRunner[] DeleteDisqualifiedRunners(SkiRunner[] runners)
        {
            int count = 0;
            for (int i = 0; i < runners.Length; i++)
            {
                if (runners[i].Rank != 999)
                {
                    count++;
                }
            }
            SkiRunner[] result = new SkiRunner[count];
            for (int i = 0; i < runners.Length; i++)
            {
                if (runners[i].Rank != 999)
                {
                    result[i] = runners[i];
                }
            }
            return result;
        }
        private static void PrintDisqualifiedRunners(SkiRunner[] runners)
        {
            for (int i = 0; i < runners.Length; i++)
            {
                if (runners[i].Rank == 999)
                {
                    Console.WriteLine($"{runners[i].Rank} {runners[i].Name} {runners[i].Nation} {runners[i].TimeDg1:f2} {runners[i].TimeDg2:f2} {runners[i].FullTime:f2}");
                }
            }
        }
        private static void PrintResult(SkiRunner[] runnersResult)
        {
            for (int i = 0; i < runnersResult.Length; i++)
            {
                Console.WriteLine($"{runnersResult[i].Rank} {runnersResult[i].Name} {runnersResult[i].Nation} {runnersResult[i].TimeDg1:f2} {runnersResult[i].TimeDg2:f2} {runnersResult[i].FullTime:f2}");
            }
        }
        private static SkiRunner[] CreateResultTable(SkiRunner[] skiRunners, SkiRunner[] skiRunners2)
        {
            SkiRunner[] result = skiRunners;
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < skiRunners2.Length; j++)
                {
                    if (result[i].Name.Contains(skiRunners2[j].Name))
                    {
                        result[i].TimeDg2 = skiRunners2[j].TimeDg2;
                        result[i].FullTime = SkiRunner.GetFullTime(result[i].TimeDg1, result[i].TimeDg2);
                    }
                }
                if (result[i].TimeDg2 == 0)
                {
                    result[i].Rank = 999;
                }
            }
            SortAndRank(ref result);
            return result;
        }
        private static void SortAndRank(ref SkiRunner[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length - i; j++)
                {
                    if (result[i].FullTime > result[i + j].FullTime)
                    {
                        Swap(ref result[i], ref result[i + j]);
                    }
                }
            }
            int count = 0;
            double helper = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].Rank == 999)
                {
                    count++;
                }
                if (result[i].Rank != 999)
                {
                    result[i].Rank = i + 1 - count;
                }
                if (result[i].FullTime == helper && result[i].FullTime != 0)
                {
                    result[i].Rank = result[i - 1].Rank;
                }
                helper = result[i].FullTime;
            }
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length - i; j++)
                {
                    if (result[i].Rank > result[i + j].Rank)
                    {
                        Swap(ref result[i], ref result[i + j]);
                    }
                }
            }
        }
        private static void Swap(ref SkiRunner skiRunner1, ref SkiRunner skiRunner2)
        {
            SkiRunner helper = skiRunner2;
            skiRunner2 = skiRunner1;
            skiRunner1 = helper;
        }
        private static SkiRunner AddRunner(SkiRunner skiRunner, SkiRunner skiRunner2)
        {
            SkiRunner result = new SkiRunner();
            result.Nation = skiRunner.Nation;
            result.Name = skiRunner.Name;
            result.TimeDg1 = skiRunner.TimeDg1;
            result.TimeDg2 = skiRunner2.TimeDg2;
            result.FullTime = SkiRunner.GetFullTime(skiRunner.TimeDg1, skiRunner2.TimeDg2);
            return result;
        }
        private static SkiRunner[] ReadFromCsvFile(string csv)
        {
            string[] lines = File.ReadAllLines(csv);
            SkiRunner[] result = new SkiRunner[lines.Length - 1];
            for (int i = 1; i < lines.Length; i++)
            {
                result[i - 1] = CreateNewRunner(lines[i]);
            }
            return result;
        }
        private static SkiRunner CreateNewRunner(string csv)
        {
            string[] data = csv.Split(';');
            SkiRunner result = new SkiRunner();
            result.Nation = data[0];
            result.Name = data[1];
            if (data[3] == "1")
            {
                result.TimeDg1 = SkiRunner.CalculateDgTime(data[2]);
            }
            else if (data[3] == "2")
            {
                result.TimeDg2 = SkiRunner.CalculateDgTime(data[2]);
            }
            return result;
        }
        private static void PrintMenu()
        {
            Console.WriteLine("1) Rangliste ausgeben");
            Console.WriteLine("2) Diqualifizierte Läufer ausgeben");
            Console.WriteLine("3) Disqualifizierte Läufer löschen");
            Console.WriteLine("4) Ergebnis speichern");
            Console.WriteLine("0) Programmende");
        }
    }
}