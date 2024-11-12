using System;

namespace TrainManager;

public class PassengerCar : Carriage
{
    private int _numberOfPassengers;
    private double _pricePerTicket;

    public PassengerCar(double emptyWeight, int carriageNumber, int numberOfPassengers, double pricePerTicket)
        : base(emptyWeight, carriageNumber)
    {
        _numberOfPassengers = numberOfPassengers;
        _pricePerTicket = pricePerTicket;
    }
}
