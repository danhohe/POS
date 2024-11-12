#nullable disable
namespace DemoExceptions.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
            Method_A();

            Console.WriteLine("Hello, World");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //optional
            }
            



            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }

        static void Method_A()
        {
            ThrowAnException("Aufruf einer Methode ohne Handling");
        }

        static void ThrowAnException(string text)
        {
            throw new MyException(10, text);
        }
    }
}
