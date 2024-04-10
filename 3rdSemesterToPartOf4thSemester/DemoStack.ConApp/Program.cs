#nullable disable
namespace DemoStack.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            Console.WriteLine("Stack-Push 1..10");
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i + 1);
                Console.WriteLine($"{i + 1}");
            }

            Console.WriteLine("Stack-Pop...");
            while(stack.IsEmpty == false)
            {
                Console.WriteLine($"{stack.Pop()}");
            }
            
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}