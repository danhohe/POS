using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.XPath;

namespace Zoo.ConApp;

public class Set<T>
{

    #region embedded class
    private class Node
    {
        public Animal Animal { get; set; }
        public Node Next { get; set; }

        public Node(Animal animal, Node next)
        {
            Animal = animal;
            Next = next;
        }
    }
    #endregion embedded class

    #region fields
    private Node? _first = null;
    #endregion fields

    public int Count
    {
        get
        {
            int result = 0;
            if (_first != null)
            {
                Node run = _first;
                while (run != null)
                {
                    result++;
                    run = run.Next;
                }
            }
            return result;
        }
    }
    public void Add(Animal animal)
    {
        if (_first == null)
        {
            _first = new Node(animal, _first!);
        }
        else
        {
            Node run = _first;
            while (run.Next != null)
            {
                run = run.Next;
            }
            run.Next = new Node(animal, null!);
        }
    }

    public static bool IsAnimalInSet(Set<T> animalSet, Animal animal)
    {
        bool result = false;
        Node? run = animalSet._first;
        while (run != null && result != true)
        {
            if (run.Animal.Name() == animal.Name())
            {
                result = true;
            }
            run = run.Next;
        }
        return result;
    }


    public static Set<T> operator +(Set<T> first, Set<T> second)
    {
        Set<T> result = first;
        Node run = second._first!;
        while (run != null)
        {
            if(!IsAnimalInSet(first, run.Animal))
            {
                result.Add(run.Animal);
            }
            run = run.Next;
        }
        return result;
    }

    public static Set<T> operator -(Set<T> first, Set<T> second)
    {
        Set<T> result = new Set<T>();
        Node? run = first._first!;
        while (run != null)
        {
            if (!IsAnimalInSet(second, run.Animal))
            {
                result.Add(run.Animal);
            }
            run = run.Next;
        }
        return result;
    }

    public static Set<T> operator *(Set<T> first, Set<T> second)
    {
        Set<T> result = new Set<T>();
        Node run = first._first!;
        while (run != null)
        {
            Node runSecond = second._first!;
            while (runSecond != null)
            {
                if (runSecond.Animal.Name() == run.Animal.Name())
                {
                    result.Add(run.Animal);
                }
                runSecond = runSecond.Next;
            }
            run = run.Next;
        }
        return result;
    }

    public override string ToString()
    {
        Node? run = _first!;
        StringBuilder sb = new StringBuilder();
        while (run != null)
        {
            sb.Append($"{run.Animal.ToString()}\n");
            run = run.Next;
        }
        return sb.ToString();
    }
}
