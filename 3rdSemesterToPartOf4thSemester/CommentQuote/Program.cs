#nullable disable
//Testkommentar

using System.ComponentModel.Design;
using System.IO.Enumeration;

namespace CommentQuote
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeader();
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        private static void PrintHeader()
        {
            string fileName = string.Empty;
            Console.WriteLine("Kommentarquote für c#-Datei");
            Console.WriteLine("===========================");
            fileName = GetFileNameWithoutSuffix(0);
            CheckIfFileExists(ref fileName);
            string text = File.ReadAllText(fileName);
            int charsCounted = CountChars(text);
            int commentsCounted = CountComments(text);
            double commentPercentage = (double)commentsCounted / charsCounted * 100;
            Console.WriteLine($"Von {charsCounted} Zeichen waren {commentsCounted} Kommentar, das ergibt {commentPercentage:F2}% Kommentarquote");
        }

        private static int CountComments(string text)
        {
            int result = 0;
            bool inBlockComment = false;
            bool inLineComment = false;
            bool inXmlComment = false;

            for (int i = 0; i < text.Length; i++)
            {
                if (inBlockComment)
                {
                    if (text[i] == '*' && i < text.Length - 1 && text[i + 1] == '/')
                    {
                        inBlockComment = false;
                        i++; 
                    }
                    result++;
                }
                else if (inLineComment)
                {
                    if (text[i] == '\n')
                    {
                        inLineComment = false;
                    }
                    result++;
                }
                else if (inXmlComment)
                {
                    if (text[i] == '\n')
                    {
                        inXmlComment = false;
                    }
                    result++;
                }
                else
                {
                    if (text[i] == '/' && i < text.Length - 1 && text[i + 1] == '/')
                    {
                        inLineComment = true;
                        result += 2; 
                        i++; 
                    }
                    else if (text[i] == '/' && i < text.Length - 1 && text[i + 1] == '*')
                    {
                        inBlockComment = true;
                        result += 2; 
                        i++; 
                    }
                    else if (text[i] == '/' && i < text.Length - 1 && text[i + 1] == '/')
                    {
                        inXmlComment = true;
                        result += 3; 
                        i += 2; 
                    }
                }
            }

            return result;
        }





        private static int CountChars(string text)
        {
            int result = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetterOrDigit(text[i]))
                {
                    result++;
                }
            }
            return result;
        }

        private static void CheckIfFileExists(ref string fileName)
        {
            bool result = true;
            do
            {
                result = File.Exists(fileName);
                if (!result)
                {
                    fileName = GetFileNameWithoutSuffix(1);
                }
            } while (result == false);
        }

        private static string GetFileNameWithoutSuffix(int n)
        {
            string result = string.Empty;
            if (n == 0)
            {
                Console.Write("Dateiname ohne Endung: ");
            }
            else
            {
                Console.Write(@"Dateiname ohne Endung <im Anwendungsverzeichnis \bin\debug>: ");
            }
            result = Console.ReadLine() + ".cs";
            return result;
        }
    }
}