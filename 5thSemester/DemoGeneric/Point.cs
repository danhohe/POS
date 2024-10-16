using System;
#nullable disable

namespace DemoGeneric;

internal class Point<T>
{
    public T X { get; set; }
    public T Y { get; set; }
}
