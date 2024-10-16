using System;
using System.Dynamic;

namespace DemoConstructor;

public class Employee : Person
{

    public string Number { get; private set; }
    public Employee(string firstName, string lastName, string number) : base(firstName, lastName)
    {
        Number = number;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {Number}";
    }
}
