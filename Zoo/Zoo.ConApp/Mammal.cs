using System;

namespace Zoo.ConApp;

public class Mammal : Animal
{
    public Mammal(string name) 
        : base(name)
    {
    }

     public override string ToString()
    {
        return base.ToString() + ", ich wurde gesäugt";
    }
}
