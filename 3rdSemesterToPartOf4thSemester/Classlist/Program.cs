#nullable disable
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Classlist
{
    class Program
    {
        public static int idx = 0;
        public static Pupil[] pupils = new Pupil[40];
        static void Main(string[] args)
        {
            pupils = ReadPupilFromCsv("1CHIF.csv");
            PrintMenu();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
        private static Pupil[] ReadPupilFromCsv(string filePath)
        {
            int i;
            string[] lines = File.ReadAllLines(filePath);
            Pupil[] result = new Pupil[40];
            for (i = 1; i < lines.Length; i++)
            {
                result[i - 1] = CreatePupilFromCsv(lines[i]);
            }
            idx = lines.Length - 1;
            return result;
        }
        private static Pupil CreatePupilFromCsv(string csv)
        {
            Pupil result = new Pupil();
            string[] data = csv.Split(';');

            if (data.Length > 0)
            {
                result.CatalogNumber = data[0];
            }
            if (data.Length > 1)
            {
                result.FirstName = data[1];
            }
            if (data.Length > 2)
            {
                result.LastName = data[2];
            }
            if (data.Length > 3)
            {
                result.ZipCode = data[3];
            }
            return result;
        }
        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Neuen Schüler anlegen");
            Console.WriteLine("2) Schülerliste nach Katalog Nr. sortieren");
            Console.WriteLine("3) Schülerliste nach Nachnamen sortieren");
            Console.WriteLine("4) Schülerliste ausgeben");
            Console.WriteLine("5) Schüler nach Nachnamen suchen");
            Console.WriteLine("6) Wohnortaufschlüsselung");
            Console.WriteLine("7) Schülerliste speichern");
            Console.WriteLine("0) Ende");
            GetMenuChoice();
        }
        private static void GetMenuChoice()
        {
            int n;
            Int32.TryParse(Console.ReadLine(), out n);
            switch (n)
            {
                case 1:
                    InsertNewStudent(ref idx, ref pupils);
                    break;
                case 2:
                    SortCatalogNumber();
                    break;
                case 3:
                    SortLastName();
                    break;
                case 4:
                    PrintStudentList();
                    break;
                case 5:
                    SearchLastName();
                    break;
                case 6:
                    PrintResidenceList();
                    break;
                case 7:
                    SaveToCsvFile(ref pupils);
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Falsche eingabe!");
                    Console.WriteLine("Bitte einen Menüpunkt wählen");
                    PrintMenu();
                    break;
            }
        }
        private static void InsertNewStudent(ref int idx, ref Pupil[] pupils)
        {
            string input;
            Console.Clear();
            if (idx <= 39)
            {
                Console.WriteLine("Bitte den neuen Schüler mit folgenden Format anlegen");
                Console.WriteLine("Katalognummer;Vorname;Nachname;PLZ");
                input = Console.ReadLine();
                pupils[idx] = CreatePupilFromCsv(input);
                idx++;
            }
            else
            {
                Console.Write("Maximale Schüleranzahl von 40 erreicht!");
                Thread.Sleep(1500);
            }
            PrintMenu();
        }
        private static void SortCatalogNumber()
        {
            Console.Clear();
            bool swapped;
            int i = 0;
            do
            {
                swapped = false;
                for (int j = 0; j < idx - 1 - i; j++)
                {
                    if (Convert.ToInt32(pupils[j].CatalogNumber) > Convert.ToInt32(pupils[j + 1].CatalogNumber))
                    {
                        Swap(ref pupils[j], ref pupils[j + 1]);
                        swapped = true;
                    }
                }
                i++;
            } while (swapped);
            Console.WriteLine("Nach Katalognummern sortiert!");
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
            PrintMenu();
        }

        private static void Swap(ref Pupil a, ref Pupil b)
        {
            Pupil helper = a;
            a = b;
            b = helper;
        }

        private static void SortLastName()
        {
            Console.Clear();
           bool swapped;
            int i = 0;
            do
            {
                swapped = false;
                for (int j = 0; j < idx - 1 - i; j++)
                {
                    if (pupils[j].LastName.CompareTo(pupils[j + 1].LastName) > 0)
                    {
                        Swap(ref pupils[j], ref pupils[j + 1]);
                        swapped = true;
                    }
                }
                i++;
            } while (swapped);
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
            PrintMenu();
        }
        private static void PrintStudentList()
        {
            Console.Clear();
            Console.WriteLine("Kat.Nr      Vorname      Nachname      Postleitzahl");
            Console.WriteLine("===================================================");
            for (int i = 0; i < idx; i++)
            {
                Console.WriteLine($"{pupils[i].CatalogNumber,-2} {pupils[i].FirstName,15} {pupils[i].LastName,14} {pupils[i].ZipCode,14}");
            }
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
            PrintMenu();
        }
        private static void SearchLastName()
        {
            Console.Clear();
            string input = string.Empty;
            int count = 0;
            Console.Write("Nach welchem Nachnamen soll gesucht werden? --> ");
            input = Console.ReadLine();
            for (int i = 0; i < idx; i++)
            {
                if (input == pupils[i].LastName)
                {
                    Console.WriteLine($"{pupils[i].CatalogNumber} {pupils[i].FirstName} {pupils[i].LastName} {pupils[i].ZipCode}");
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Keinen Schüler mit diesem Namen gefunden!");
            }
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
            PrintMenu();
        }
        private static void PrintResidenceList()
        {
            throw new NotImplementedException();
        }
        private static void SaveToCsvFile(ref Pupil[] pupils)
        {
            Console.Clear();
            string[] text = new string[pupils.Length];
            for (int i = 0; i < idx; i++)
            {
                text[i] = pupils[i].CatalogNumber.ToString() + ";" + pupils[i].FirstName.ToString() + ";" + pupils[i].LastName.ToString() + ";" + pupils[i].ZipCode.ToString();
            }
            File.WriteAllLines("1CHIF_Copy.csv", text);
            Console.WriteLine("File saved => 1CHIF_Copy.csv!");
            Thread.Sleep(1500);
            PrintMenu();
        }
    }
}