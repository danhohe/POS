#nullable disable




using PlantUML.Logic;

namespace UpnCalculator.ConApp
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
            GetUserInput();
        }

        private static void GetUserInput()
        {
            Console.Write("Geben sie zu berechnenden Term ein: ");
            string input = Console.ReadLine();
            Console.WriteLine($"{input} = " + ParseLine(input));
        }

        private static double ParseLine(string input)
        {
            NumberStack<double> stack = new NumberStack<double>();
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 0)
            {
                double a, b;
                for (int i = 0; i < parts.Length; i++)
                {
                    if (parts[i] == "+")
                    {
                        b = stack.Pop();
                        a = stack.Pop();
                        ObjectDiagram.Generate(stack);
                        stack.Push(a + b);
                        ObjectDiagram.Generate(stack);
                    }
                    else if (parts[i] == "-")
                    {
                        b = stack.Pop();
                        a = stack.Pop();
                        ObjectDiagram.Generate(stack);
                        stack.Push(a - b);
                        ObjectDiagram.Generate(stack);
                    }
                    else if (parts[i] == "*")
                    {
                        b = stack.Pop();
                        a = stack.Pop();
                        ObjectDiagram.Generate(stack);

                        stack.Push(a * b);
                        ObjectDiagram.Generate(stack);
                    }
                    else if (parts[i] == "/")
                    {
                        b = stack.Pop();
                        a = stack.Pop();
                        ObjectDiagram.Generate(stack);

                        stack.Push(a / b);
                        ObjectDiagram.Generate(stack);
                    }
                    else if (double.TryParse(parts[i], out double operand))
                    {
                        stack.Push(operand);
                        ObjectDiagram.Generate(stack);
                    }
                }
            }
            ObjectDiagram.Generate(stack);
            return stack.Pop();
        }

        private static void PrintHeader()
        {
            Console.WriteLine("UPN-Calculator");
            Console.WriteLine("Made by dHoheneder");
            Console.WriteLine("******************");
        }
    }
}