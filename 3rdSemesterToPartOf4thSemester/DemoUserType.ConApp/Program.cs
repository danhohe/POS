#nullable disable

using System.Globalization;
using System.Security.Cryptography;
using System.Xml.XPath;

namespace DemoUserType.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Demo User Types");

            Student[] students = ReadStudentsFromCsv("students.csv");

            PrintStudents(students);

            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        private static void PrintStudents(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                Student student = students[i];
                Console.WriteLine($"{students[i].Fullname, -20} {student.Birthday.ToString("dd.MM.yyyy"),-20}");
            }
        }

        private static Student[] ReadStudentsFromCsv(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            Student[] result = new Student[lines.Length - 1];

            Console.WriteLine($"{nameof(ReadStudentsFromCsv)}");
            for (int i = 1; i < lines.Length; i++)
            {
                result[i - 1] = CreateStudentsFromCsv(lines[i]);
            }
            return result;
        }

        private static Student CreateStudentsFromCsv(string csv)
        {
            Student result = new Student();
            CultureInfo provider = CultureInfo.InvariantCulture;
            string[] data = csv.Split(';');

            if (data.Length > 0)
            {
                result.FirstName = data[0];
            }
            if (data.Length > 1)
            {
                result.LastName = data[1];
            }
            if (data.Length > 2)
            {
                result.Birthday = DateTime.ParseExact(data[2], "dd.MM.yyyy", provider);
            }
            return result;
        }
    }
}
