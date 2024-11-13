using System;
using WorldClock;

namespace WorldClock.ConApp;

public class ConsoleClock : Logic.IObserver
{
    private int _offset = 0;
    private string _text;
    private ConsoleColor _consoleColor = ConsoleColor.Green;

    public ConsoleClock(int offset, string text, ConsoleColor forgroundColor)
    {
        _offset = offset;
        _text = text;
        _consoleColor = forgroundColor;
    }

    public void Update(object sender, EventArgs e)
    {
        if (e is Logic.DateTimeArgs args)
        {
            ConsoleColor saveColor = Console.ForegroundColor;

            Console.ForegroundColor = _consoleColor;

            Console.WriteLine($"{_text}: {args.Time.AddHours(_offset)}");

            Console.ForegroundColor = saveColor;
        }
    }
}
