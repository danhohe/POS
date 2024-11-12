using System;

namespace TrainManager;

public abstract class Carriage
{
    private readonly double _emptyWeight = 0;
    private readonly int _carriageNumber = 0;

    public Carriage(double emptyWeight, int carriageNumber)
    {
        _emptyWeight = emptyWeight;
        _carriageNumber = IsCarriageNumberValid(carriageNumber) ? carriageNumber : 1;
    }

    public bool IsCarriageNumberValid(int carriageNumber)
    {
        bool result = false;
        string numberString = carriageNumber.ToString();
        if (carriageNumber == 8)
        {
            int[] numbers = new int[8];

            int[].TryParse

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(numberString[i].ToString());
            }
            for (int i = 0; i < numbers.Length; i++)
            {

            }
        }

        return result;
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
