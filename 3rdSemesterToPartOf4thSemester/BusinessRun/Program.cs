#nullable disable

using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Net.Mail;
using System.Runtime.Intrinsics.X86;
using System.Globalization;

namespace BusinessRun
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
            Runner[] runners = ReadFromCsvFile("BusinessRun.csv");
            SortRunners(ref runners);
            PrintRunnerList(runners);
            SortStartNumbers(ref runners);
            WriteToCsvFile(runners, "RUN-Start.csv");
        }
        private static void WriteToCsvFile(Runner[] runners, string csv)
        {
            string[] text = new string[runners.Length];
            for (int i = 0; i < runners.Length; i++)
            {
                text[i] = runners[i].StartNumber + ";" + runners[i].FullName + ";" + runners[i].YearOfBirth + ";" + runners[i].Nation + ";" + runners[i].Company + ";" + runners[i].Team + ";" + runners[i].Time;
            }
            File.WriteAllLines(csv, text);
            Console.WriteLine($"File: '{csv}' wurde erstellt.");
        }
        private static void SortStartNumbers(ref Runner[] runners)
        {
            int length = runners.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    bool swap = HasToBeSwapped(runners[j].StartNumber, runners[j + 1].StartNumber);
                    if (swap)
                    {
                        Swap(ref runners[j], ref runners[j + 1]);
                    }
                }
            }
        }
        private static bool HasToBeSwapped(string startNumber1, string startNumber2)
        {
            int length = 0;
            if (startNumber1.Length < startNumber2.Length)
            {
                length = startNumber2.Length;
                for(int i = 0; i < length; i++)
                {
                startNumber1 = "0" + startNumber1;
                }
            }
            else if (startNumber1.Length > startNumber2.Length)
            {
                length = startNumber1.Length;
                for(int i = 0; i < length; i++)
                {
                startNumber2 = "0" + startNumber2;
                }
            }
            else
            {
                length = startNumber1.Length;
            }
            char[] chars1 = startNumber1.ToCharArray();
            char[] chars2 = startNumber2.ToCharArray();
            bool result = false;
            bool noSwap = false;
            
            while (result == false && noSwap == false)
            {
                noSwap = false;
                for (int idx = 0; idx < length && result == false && noSwap == false; idx++)
                {
                    if (chars1[idx] > chars2[idx])
                    {
                        result = true;
                    }
                    else if(chars1[idx] < chars2[idx])
                    {
                        noSwap = true;
                    }
                }
            }
            return result;
        }
        private static void PrintRunnerList(Runner[] runners)
        {
            double time = 0, count = 0;
            Console.WriteLine($"{"Nr",5} {"Name",-30} {"JG",-6} {"Nation",-5} {"Team",-20} {"Zeit[sec]",20}");
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine($"{runners[i].StartNumber} {runners[i].FullName,-30} {runners[i].YearOfBirth,-9} {runners[i].Nation} {runners[i].Team,-31} {runners[i].TimeInSeconds}");
            }
            for (int i = 0; i < runners.Length; i++)
            {
                time += runners[i].TimeInSeconds;
                count++;
            }
            double result = time / count;
            Console.WriteLine($"Durchschnittliche Laufzeit[sek]: {result:f2}");
            Console.WriteLine();
        }
        private static void SortRunners(ref Runner[] runners)
        {
            int length = runners.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (runners[j].TimeInSeconds > runners[j + 1].TimeInSeconds)
                    {
                        Swap(ref runners[j], ref runners[j + 1]);
                    }
                }
            }
        }
        private static void Swap(ref Runner runner1, ref Runner runner2)
        {
            Runner helper = runner1;
            runner1 = runner2;
            runner2 = helper;
        }
        private static Runner[] ReadFromCsvFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            Runner[] result = new Runner[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = CreateRunnerFromCsv(lines[i]);
            }
            return result;
        }
        private static Runner CreateRunnerFromCsv(string csv)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            Runner result = new Runner();
            string[] data = csv.Split(';');
            result.StartNumber = data[0];
            result.FullName = data[1];
            result.YearOfBirth = data[2];
            result.Nation = data[3];
            result.Company = data[4];
            result.Team = data[5];
            result.Time = data[6];
            result.TimeInSeconds = Runner.ConvertToSeconds(data[6]);
            return result;
        }
        private static void PrintHeader()
        {
            Console.WriteLine("********************************************************");
            Console.WriteLine("* Business-Run - Die zuverlässige Software für Läufer  *");
            Console.WriteLine("* von Daniel Hohender                                  *");
            Console.WriteLine("********************************************************");
            Console.WriteLine();
        }
    }
}