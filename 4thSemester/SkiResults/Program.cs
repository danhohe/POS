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
            CreateResultTable(ref skiRunners);
        }

        private static void CreateResultTable(ref SkiRunner[] skiRunners)
        {
            throw new NotImplementedException();
        }

        private static SkiRunner[] ReadFromCsvFile(string csv)
        {
            string[] lines = File.ReadAllLines(csv);
            SkiRunner[] result = new SkiRunner[lines.Length];

            for(int i = 0; i < lines.Length; i++)
            {
                result[i] = CreateNewRunner(lines[i]);
            }
            return result;
        }

        private static SkiRunner CreateNewRunner(string csv)
        {
            string[] data = csv.Split(';');
            SkiRunner result = new SkiRunner();
            result.Nation = data[0];
            result.Name = data[1];
            result.TimeDG1 = SkiRunner.CalculateDgTime(data[2]);
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
