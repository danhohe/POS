#nullable disable


namespace SkiResults
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
            PrintMenu();
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
