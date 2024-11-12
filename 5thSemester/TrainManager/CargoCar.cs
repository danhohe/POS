using System;

namespace TrainManager;

public class CargoCar : Carriage
{
    private double _cargoWeight = 0;
    private double _pricePerTon = 0;

    public CargoCar(double emptyWeight, int carriageNumber, double cargoWeight, double pricePerTon)
        :base(emptyWeight, carriageNumber)
    {
        _cargoWeight = cargoWeight;
        _pricePerTon = pricePerTon;
    }

    public double GetProfit()
    {
        double result = 0;

        return result;
    }

    public double GetFullWeight()
    {
        double result = 0;

        return result;
    }
}
