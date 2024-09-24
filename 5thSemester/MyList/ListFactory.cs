using System;

namespace MyList;

public class ListFactory
{
    public static IList Create()
    {
        return new LinkedList();
    }
}
