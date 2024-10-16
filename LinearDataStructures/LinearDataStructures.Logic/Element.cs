using System;
#nullable disable
namespace LinearDataStructures.Logic;

internal class Element<T>
{
    public Element (T data, Element<T> next)
    {
        Data = data;
        Next = next;
    }
    public T Data { get; set; }
    public Element<T> Next { get; set; }
}
