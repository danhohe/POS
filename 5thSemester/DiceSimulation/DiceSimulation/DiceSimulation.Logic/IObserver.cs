using System;

namespace DiceSimulation.Logic;

public interface IObserver
{
    void Update(Object sender, EventArgs e);
}