using System;

namespace Zoo.ConApp;

public class Bird : Animal
{
    private bool _cantFly;
    public Bird(string name) 
        : base(name)
    {
    }
     public Bird(string name, bool canFly) 
        : base(name)
    {
        _cantFly = canFly;
    }

     public override string ToString()
    {
        return _cantFly ? base.ToString() + ", ich bin zwar ein Vogel kann aber nicht fliegen" : base.ToString() + ", ich kann große Strecken fliegen";
    }
}
