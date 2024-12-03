using System;
using System.Text;

namespace FleetManager.Logic;

public class PassengerVehicle : Vehicle
{
    private int _passengerCount = 0;
    private double _ticketPrice = 0;

    public int PassengerCount
    {
        get
        {
            return _passengerCount;
        }
        set
        {
            _passengerCount = value;
        }
    }
    public PassengerVehicle(string vehicleID, double baseWeight, int passengerCount, double ticketPrice)
        : base(vehicleID, baseWeight)
    {
        if (passengerCount <= 50)
        {
            _passengerCount = passengerCount;
        }
        else
        {
            _passengerCount = 50;
        }
        _ticketPrice = ticketPrice;
    }

    public PassengerVehicle(string vehicleID, double baseWeight, double ticketPrice)
        : base(vehicleID, baseWeight)
    {
        _passengerCount = 20;
        _ticketPrice = ticketPrice;
    }

    public override double GetRevenue()
    {
        return PassengerCount * _ticketPrice;
    }

    public override double GetTotalWeight()
    {
        return BaseWeight + (PassengerCount * 70);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("VehicleID: " + VehicleID + " TotalWeight: " + GetTotalWeight() + " Revenue: " + GetRevenue());
        return sb.ToString();
    }
}
