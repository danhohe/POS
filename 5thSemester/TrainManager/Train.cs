using System;

namespace TrainManager;

public class Train
{
    private readonly List<Carriage> _carriageList = new List<Carriage>();
    private readonly double _maxTrainWeight;
    private readonly int _countOfPassengerCars;

    public Train(double maxTrainWeight)
    {
        _maxTrainWeight = maxTrainWeight;
    }

    public double GetTrainWeight()
    {
        double result = 0;

        return result;
    }

    public Carriage GetMostProfitableCarriage()
    {
        Carriage result = null;

        return result;
    }

    public int GetAmountOfPassengersInTrain()
    {
        int result = 0;

        return result;
    }

    public bool AddCarriage(Carriage newCar)
    {
        bool result = false;

        return result;
    }

    public bool AddPassengerToCar(int carriageNumber, int newPassengers)
    {
        bool result = false;

        return result;
    }
}
