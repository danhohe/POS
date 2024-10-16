using System;

namespace Zoo.ConApp;

public class Animal
{
    #region fields
    private string _name;
    #endregion fields

    #region constructors
    public Animal(string name)
    {
        _name = name;
    }
    #endregion constructors



    #region methods
    public override string ToString()
    {
        return $"Name: {_name}";
    }

    public string Name()
    {
        return _name;
    }
    #endregion methods

}
