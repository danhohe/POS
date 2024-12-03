using System;

namespace DiceSimulation.Logic;

public abstract class Observable
{
    private List<Dice> _dices = new List<Dice>();

    public void AddObserver(Dice dice)
    {
        lock (this)
        {
            if(_dices.Contains(dice) == false)
            {
                _dices.Add(dice);
            }
        }
    }
}
