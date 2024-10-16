using System;

namespace Zoo.ConApp;

public class Fish : Animal
{
    public Fish(string name) 
        : base(name)
    {
    }

    public override string ToString()
    {
        return base.ToString() + ", ich kann lange unter Wasser bleiben";
    }
}
