using System;

namespace DemoGenericWithConstraints;

public static class Helper
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T tmp = a;

        a = b;
        b = tmp;
    }

    public static void Sort<T>(ref T a, ref T b) where T : IComparable<T>
    {
        if(a.CompareTo(b) > 0)
        {
            Swap(ref a, ref b);
        }
    }
}