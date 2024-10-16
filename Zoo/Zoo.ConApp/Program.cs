namespace Zoo.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zoo");
            Console.WriteLine();

            Fish goldfisch = new Fish("Goldfisch");
            Fish zander = new Fish("Zander");
            Fish piranha = new Fish("Piranha");
            Bird canary = new Bird("Kanari");
            Bird chicken = new Bird("Huhn");
            Bird hawk = new Bird("Falke");
            Bird kiwi = new Bird("Kiwi");
            Bird eagle = new Bird("Adler");
            Mammal human = new Mammal("Mensch");
            Mammal dog = new Mammal("Hund");
            Mammal cat = new Mammal("Katze");
            Mammal lion = new Mammal("Löwe");
            Mammal horse = new Mammal("Pferd");
            Mammal rabbit = new Mammal("Hase");
            Mammal cow = new Mammal("Kuh");

            Set<Animal> pets = new Set<Animal>();
            pets.Add(goldfisch);
            pets.Add(canary);
            pets.Add(dog);
            pets.Add(cat);
            pets.Add(rabbit);
            Console.WriteLine("{0} Haustiere", pets.Count);
            Console.WriteLine(pets.ToString());

            Set<Animal> farmedAnimals = new Set<Animal>();
            farmedAnimals.Add(cow);
            farmedAnimals.Add(horse);
            farmedAnimals.Add(zander);
            farmedAnimals.Add(rabbit);
            farmedAnimals.Add(chicken);
            Console.WriteLine("{0} Nutztiere", farmedAnimals.Count);
            Console.WriteLine(farmedAnimals.ToString());

            Set<Animal> farmedPets = pets * farmedAnimals;
            Console.WriteLine("{0} Nutztiere zugleich Haustiere", farmedPets.Count);
            Console.WriteLine(farmedPets.ToString());

            Set<Animal> companionAnimals = pets + farmedAnimals;
            Console.WriteLine("{0} zahme Tiere", companionAnimals.Count);
            Console.WriteLine(companionAnimals.ToString());
            
            Set<Animal> uneatableAnimals = pets - farmedAnimals;
            Console.WriteLine("{0} nicht essbare Haustiere", uneatableAnimals.Count);
            Console.WriteLine(uneatableAnimals.ToString());

            //Spezialistenaufgabe: Zum Testen folgende Zeilen aktiv setzen.
            Bird penguin = new Bird("Pinguin",true);
            Console.WriteLine("Spezialistenaufgabe:");
            Console.WriteLine(penguin.ToString());

            Console.ReadLine();
        }
    }
}
