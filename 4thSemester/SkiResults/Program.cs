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
            PrintMenu();
            SkiRunner[] skiRunners = ReadFromCsvFile(run1);
            SkiRunner[] skiRunners2 = ReadFromCsvFile(run2);
            SkiRunner[] runnersResult = CreateResultTable(skiRunners, skiRunners2);
            GetMenuChoice();
        }

        private static void GetMenuChoice()
        {
            string input = string.Empty;
            int n;
            input = Console.ReadLine();
            Int32.TryParse(input, out n);
            switch (n)
            {
                case 1:
                    PrintResult();
                    break;
                case 2:
                    PrintDisqualifiedRunners();
                    break;
                case 3:
                    DeleteDisqualifiedRunners();
                    break;
                case 4:
                    SaveRunnersToCsv();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    Console.WriteLine("only the numbers shown in the menu are valid");
                    GetMenuChoice();
                    break;
            }
        }

        private static void SaveRunnersToCsv()
        {
            throw new NotImplementedException();
        }

        private static void DeleteDisqualifiedRunners()
        {
            throw new NotImplementedException();
        }

        private static void PrintDisqualifiedRunners()
        {
            throw new NotImplementedException();
        }

        private static void PrintResult()
        {
            throw new NotImplementedException();
        }

        private static SkiRunner[] CreateResultTable(SkiRunner[] skiRunners, SkiRunner[] skiRunners2)
        {
            SkiRunner[] result = new SkiRunner[skiRunners.Length + 2];
            for (int i = 0; i < skiRunners.Length; i++)
            {
                if (skiRunners[i].Name == skiRunners2[i].Name)
                {
                    result[i] = skiRunners[i];
                }
            }
            return result;
        }

        private static SkiRunner[] ReadFromCsvFile(string csv)
        {
            string[] lines = File.ReadAllLines(csv);
            SkiRunner[] result = new SkiRunner[lines.Length];

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
