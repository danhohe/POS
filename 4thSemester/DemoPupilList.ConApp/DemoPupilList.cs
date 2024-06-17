using System.Text;

namespace DemoPupilList.ConApp;

public class DemoPupilList
{
    private class Node
    {
        public required DemoPupil Pupil { get; set; }
        public Node? Next { get; set; }
    }

    private Node? _head;


    public DemoPupil this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            int counter = 0;
            DemoPupil? result = null;
            Node? run = _head;
            while (counter < index && run != null)
            {
                counter++;
                run = run.Next;
            }
            result = run!.Pupil;
            return result!;
        }
    }
    public int Count
    {
        get
        {
            int result = 0;
            Node? run = _head;

            while (run != null)
            {
                result++;
                run = run.Next;
            }
            return result;
        }
    }
    public void Append(DemoPupil pupil)
    {
        // Fall A: Liste ist leer -> _head == new Node(...)
        if (_head == null)
        {
            _head = new() { Pupil = pupil, Next = null };
        }
        // Fall B: Liste ist nicht leer -> letztes Element
        else
        {
            Node? run = _head;
            while (run.Next != null)
            {
                run = run.Next;
            }
            run.Next = new() { Pupil = pupil, Next = null };
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        Node? run = _head;
        
        sb.Append("[ ");

        while (run != null)
        {
            if (sb.Length > 2)
                sb.Append(", ");
            sb.Append(run.Pupil!.ToString());
            run = run.Next;
        }

        sb.Append(" ]");
        return sb.ToString();
    }


}
