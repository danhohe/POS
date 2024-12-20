using System;

namespace DemoConstructor;

public abstract class Person
{

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set;}

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
