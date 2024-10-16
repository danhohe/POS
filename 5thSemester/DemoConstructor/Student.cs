using System;

namespace DemoConstructor;

public class Student : Person
{

    public string MatNumber { get; private set; }
    public Student(string firstName, string lastName, string matNumber) : base(firstName, lastName)
    {
        MatNumber = matNumber;
    }

    public override string ToString()
    {
        return $"{base.ToString()} {MatNumber}";
    }
}
