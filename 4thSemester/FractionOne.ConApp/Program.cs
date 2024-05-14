#nullable disable
namespace FractionOne.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction();     // Zähler:0, Nenner: 1
            Fraction b = new Fraction(6, 4); // Zähler:6, Nenner: 4
            Fraction c = new Fraction(5);    // Zähler:5, Nenner: 1
            Fraction d = new Fraction(b);    // Zähler:6, Nenner: 4
            Fraction e = new Fraction(3, 0); // Zähler:3, Nenner: 1, d.h. Nenner 0 ist nicht erlaubt

            Console.WriteLine($"A: {a}");
            Console.WriteLine($"B: {b}");
            Console.WriteLine($"C: {c}");
            Console.WriteLine($"D: {d}");
            Console.WriteLine($"E: {e}");
            Console.WriteLine();

            Console.WriteLine("Wert von B: " + b.Value()); // Liefert den Wert des Objektes als float zurück
                                          // (in unseren Fall 1,5)
            Console.WriteLine();
            Console.WriteLine("A: " + b.Add(3)); // ergibt für a den neuen Wert 18/4
            Console.WriteLine("C: " + c.Add(d)); // ergibt für c den neuen Wert 26/4

            Fraction f = b.Multiplier(c);
            Console.WriteLine($"F: {f}");
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();
        }
    }
}