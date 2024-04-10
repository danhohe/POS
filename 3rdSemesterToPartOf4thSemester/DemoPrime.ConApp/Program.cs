namespace DemoPrime.ConApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            // EIngabe (E)
            string input;
            int n = 0;
            int divider = 3;
            
            //Eingabe(E)
            Console.WriteLine("Geben sie eine Zahl ein"); 
            input = Console.ReadLine();
            n = Convert.ToInt32(input); 

            bool isPrime = n == 2 || (n > 2 && n % 2 != 0);

            // Verarbeitung (V)
            while (isPrime && divider <= n / 2)
            {
                if (n % divider == 0)
                {
                    isPrime = false;
                }
                divider += 2;
            }

            //Ausgabe (A)
            Console.WriteLine($"{n} ist {(isPrime ? "eine" : "keine")} Primzahl");
        }
    }
}