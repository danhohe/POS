#nullable disable
namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            IList list = ListFactory.Create();

            list.Add(8);
            list.Add(9);
            list.Add(10);

            list[1] = 2;

            Console.WriteLine($"List[1]:  {list[1]}");

            foreach (var item in list)
            {
                Console.WriteLine($"Item: {item}");
            }
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}