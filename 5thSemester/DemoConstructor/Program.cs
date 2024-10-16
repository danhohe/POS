namespace DemoConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Employee("Gerhard", "Gehrer", "4711");
            Person p2 = new Student("Daniel", "Hoheneder", "ad220300");
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());

            Student? s1 = null;

            if(p2 is Student)
            {
                s1 = (Student)p2;
            }

            Student? s2 = p2 as Student;

            Employee? e1 = null;

            List<Person> list = new();

            list.Add(p1);
            list.Add(p2);
            list.Add(s1);
            list.Add(e1);

            foreach(Person p in list)
            {
                Console.WriteLine(p);
            }



            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}
