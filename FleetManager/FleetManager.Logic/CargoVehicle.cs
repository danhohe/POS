using System;
using System.Text;

namespace FleetManager.Logic;

public class CargoVehicle : Vehicle
{
    private double _cargoWeight = 0;
    private double _ratePerTon = 0;
    public double CargoWeight
    {
        get
        {
            return _cargoWeight;
        }
        set
        {
            _cargoWeight = value;
        }
    }
    public CargoVehicle(string vehicleID, double baseWeight, double cargoWeight, double ratePerTon)
        : base(vehicleID, baseWeight)
    {
        if (cargoWeight <= 20)
        {
            _cargoWeight = cargoWeight;
        }
        else
        {
            _cargoWeight = 20;
        }
        _ratePerTon = ratePerTon;
    }

    public override double GetRevenue()
    {
        return CargoWeight * _ratePerTon;
    }

    public override double GetTotalWeight()
    {
        return BaseWeight + (CargoWeight * 1000);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("VehicleID: " + VehicleID + " TotalWeight: " + GetTotalWeight() + " Revenue: " + GetRevenue());
        return sb.ToString();
    }
}
