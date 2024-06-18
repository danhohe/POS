using Microsoft.VisualBasic;

namespace BandOfPearl;

public class Pearl
{
    #region fields
    private string? _color;
    private double _weight;
    #endregion fields
    
    #region properties
    public string Color
    {
        get => _color!;
    }
    public double Weight
    {
        get => _weight;
    }
    #endregion properties

    #region constructor
    public Pearl(string? color, double weight)
    {
        if (color == null)
            _color = "Unknown";
        else if(color == "Red" || color == "Green" || color == "Blue")
            _color = color;
        
        if (weight < 0)
            _weight = 0;
        else
            _weight = weight;
    }
    #endregion constructor
}
