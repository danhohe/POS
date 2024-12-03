using System;
using System.Text;

namespace FleetManager.Logic;

public class Fleet
{
    List<Vehicle> _vehicleList = new();

    public IReadOnlyList<Vehicle> Vehicles
    {
        get
        {
            return _vehicleList;
        }
    }

    public int MaxFleetWeight { get; }
    public int PassengerVehicleCount
    {
        get
        {
            return GetTotalPassengerCount();
        }
    }

    public Fleet(int maxFleetWeight)
    {
        MaxFleetWeight = maxFleetWeight;
    }

    public double GetFleetWeight()
    {
        double result = 0;
        foreach (Vehicle vehicle in Vehicles)
        {
            result += vehicle.GetTotalWeight();
        }
        return result;
    }
    public Vehicle GetMostProfitableVehicle()
    {
        Vehicle result = null;
        if (_vehicleList != null)
        {
            _vehicleList.Sort((b, a) => a.GetRevenue().CompareTo(b.GetRevenue()));
            result = _vehicleList[0];
        }
        return result;
    }
    public int GetTotalPassengerCount()
    {
        int result = 0;
        foreach(PassengerVehicle vehicle in Vehicles)
        {
            result += vehicle.PassengerCount;
        }
        return result;
    }
    public bool AddVehicle(Vehicle newVehicle)
    {
        bool result = false;
        if(GetFleetWeight() + newVehicle.GetTotalWeight() <= MaxFleetWeight)
        {
            _vehicleList.Add(newVehicle);
            _vehicleList.Sort((b, a) => a.GetTotalWeight().CompareTo(b.GetTotalWeight()));
            result = true;
        }
        return result;
    }
    public bool AddPassengersToVehicle(string vehicleID, int additionalPassengers)
    {
        PassengerVehicle? tmp = null;
        bool result = false;
        foreach(PassengerVehicle vehicle in Vehicles)
        {
            if(vehicle.VehicleID == vehicleID)
            {
                tmp = vehicle;
            }
        }
        if(tmp != null && tmp!.PassengerCount + additionalPassengers <= 50)
        {
            tmp.PassengerCount += additionalPassengers;
            result = true;
        }
        return result;
    }
    public IReadOnlyList<Vehicle> GetByRevenue()
    {
        List<Vehicle> result = _vehicleList;
       result.Sort((a, b) => a.GetRevenue().CompareTo(b.GetRevenue()));
        return result;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach(Vehicle vehicle in _vehicleList)
        {
            sb.Append("VehicleID: " + vehicle.VehicleID + " TotalWeight: " + vehicle.GetTotalWeight() + " Revenue: " + vehicle.GetRevenue());
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
