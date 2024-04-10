using System;
using System.IO;
using System.Text;
#nullable disable

namespace FileWizard
{
    /// <summary>
    /// FileWizard erledigt einige einfache Konvertieraufgaben
    /// auf beliebigen Textdateien
    /// </summary>
    class Program
    {
        static ConsoleColor defaultColor = ConsoleColor.Gray;
        const string LOGO_FILE = "logo.txt";
        static void Main(string[] args)
        {
            string logo = File.ReadAllText(LOGO_FILE, Encoding.Default);
            Console.WriteLine(logo);
            bool finished = false;
            do
            {
                string fileName = GetFileName();
                finished = PerformOperation(ref fileName);
            } while (!finished);

            Console.WriteLine("Vielen Dank, dass ich Dir helfen durfte!");
            System.Threading.Thread.Sleep(3000);
        }

        /// <summary>
        /// Erfragen eines Dateinamen vom Benutzer.
        /// Gibt dieser einen ungültigen Dateinamen ein
        /// (Datei existiert nicht), wird das Einlesen
        /// solange wiederholt, bis ein gültiger Dateiname
        /// eingelesen wurde.
        /// Verwende File.Exists
        /// </summary>
        /// <returns>Gültiger Dateiname (Datei existiert)</returns>
        private static string GetFileName()
        {
            string result = string.Empty;
            bool isExisting;
            do
            {
                Console.Write("Welche Datei soll ich öffnen? ");
                result = Console.ReadLine();
                isExisting = File.Exists(result);
                if (!isExisting)
                {
                    Console.WriteLine("Diese Datei existiert nicht!");
                }
            } while (!isExisting);
            return result;
        }

        /// <summary>
        /// Präsentiert eine Auswahl an Datei-Funktionen
        /// und führt die vom Benutzer gewählte Funktion
        /// aus.
        /// Der Dateiname muss als ref-Parameter übergeben
        /// werden, da er sich durch das Einlesen einer
        /// neuen Datei auch ändern kann.
        /// Wenn "Ende" ausgewählt wurde, wird true 
        /// zurückgegeben
        /// </summary>
        /// <param name="fileName">Dateiname als Referenz</param>
        /// <returns>finished</returns>
        private static bool PerformOperation(ref string fileName)
        {
            CreateBackup(fileName);
            bool result = true, isMenuChoiceRight = true;
            string input = string.Empty;
            do
            {
                result = true;
                isMenuChoiceRight = false;
                PrintHeader();
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        PrintFile(fileName);
                        break;
                    case "2":
                        AddLineNumbers(fileName);
                        break;
                    case "3":
                        ReverseLines(fileName);
                        break;
                    case "4":
                        ReplaceCharacters(fileName);
                        break;
                    case "5":
                        isMenuChoiceRight = true;
                        result = false;
                        break;
                    case "0":
                        isMenuChoiceRight = true;
                        result = true;
                        break;
                    default:
                        isMenuChoiceRight = false;
                        break;
                }
            } while (isMenuChoiceRight == false && result == true);
            return result;
        }

        private static void PrintHeader()
        {
            Console.WriteLine("(1) Datei am Bildschirm ausgeben");
            Console.WriteLine("(2) Zeilennummern hinzufügen");
            Console.WriteLine("(3) Zeilen reversieren");
            Console.WriteLine("(4) Zeichenkette ersetzen");
            Console.WriteLine("(5) Neue Datei einlesen");
            Console.WriteLine("(0) Ende");
        }

        /// <summary>
        /// Erstellen einer Sicherungskopie einer Datei.
        /// Es wird an den Dateinamen '.bak' angehängt.
        /// Gibt es schon eine Sicherung mit diesem Namen,
        /// wird '.bak1' angehängt (bzw. '.bak2', '.bak3', usw.)
        /// Verwende File.Exists und File.Copy
        /// </summary>
        /// <param name="fileName">Zu sichernde Datei</param>
        private static void CreateBackup(string fileName)
        {
            string backupFileName = fileName + ".bak";
            int count = 1;
            while (File.Exists(backupFileName))
            {
                backupFileName = $"{fileName}.bak{count}";
                count++;
            }
            File.Copy(fileName, backupFileName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Datei {backupFileName} wurde erstellt.");
            Console.ForegroundColor = defaultColor;
        }

        /// <summary>
        /// Alle Zeilen der Datei werden eingelesen und
        /// in umgekehrter Reihenfolge wieder auf die
        /// Datei geschrieben.
        /// Verwende File.ReadAllLines und File.WriteAllLines
        /// </summary>
        /// <param name="fileName"></param>
        private static void ReverseLines(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            Array.Reverse(lines);
            File.WriteAllLines(fileName, lines);
        }

        /// <summary>
        /// Alle Zeilen der Datei werden eingelesen und
        /// mit einer Zeilennummer versehen wieder auf die
        /// gleiche Datei geschrieben.
        /// Verwende File.ReadAllLines und File.WriteAllLines
        /// </summary>
        /// <param name="fileName"></param>
        private static void AddLineNumbers(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = $"{i + 1}: {lines[i]}";
            }
            File.WriteAllLines(fileName, lines);
        }

        /// <summary>
        /// Der Inhalt der Datei wird in eine string-Variable gelesen.
        /// Der Benutzer wird gefragt, welche Zeichenkette er durch
        /// welche andere Zeichenkette ersetzen will.
        /// Die Ersetzung wird in der string-Variable durchgeführt
        /// und das Ergebnis wieder auf die Datei geschrieben.
        /// Verwende File.ReadAllText und File.WriteAllText.
        /// </summary>
        /// <param name="fileName"></param>
        private static void ReplaceCharacters(string fileName)
        {
            Console.Write("Welche(s) Zeichen soll(en) ersetzt werden? ");
            string searchText = Console.ReadLine();
            Console.Write("Wodurch? ");
            string replaceText = Console.ReadLine();

            string content = File.ReadAllText(fileName);
            content = content.Replace(searchText, replaceText);
            File.WriteAllText(fileName, content);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Alle '{searchText}' in {fileName} wurden durch '{replaceText}' eresetzt!");
            Console.ForegroundColor = defaultColor;
        }

        /// <summary>
        /// Ausgabe der Textdatei auf die Konsole
        /// Verwende ReadAllText
        /// </summary>
        /// <param name="fileName"></param>
        private static void PrintFile(string fileName)
        {
            string text = File.ReadAllText(fileName, Encoding.Default);
            Console.WriteLine("------- Ausgabe Start -------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("------- Ausgabe  Ende -------");
        }
    }
}