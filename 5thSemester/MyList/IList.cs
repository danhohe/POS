using System;
using System.Collections;

namespace MyList;

public interface IList : IEnumerable
{
    object this[int index] { get; set; }
    int Count { get; }
    void Add(object item);

    void Clear();

    void Remove(object item);
}
