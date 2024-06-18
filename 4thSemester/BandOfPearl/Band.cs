namespace BandOfPearl;

public class Band
{
    private class Node
    {
        public required Pearl Pearl { get; set; }
        public Node? Next { get; set; }
    }

    #region fields
    private Node? _head;
    #endregion fields


    #region methods
    public void AddPearl(Pearl? newPearl)
    {
        if (_head == null)
        {
            _head = new() { Pearl = newPearl!, Next = null };
        }
        else
        {
            Node? run = _head;
            while (run != null)
            {
                run.Next = run;
            }
            run!.Next = new() { Pearl = newPearl!, Next = null };
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
    public Pearl GetPearlAtPosition(int position)
    {
        Pearl result = null!;
        int i = 0;
        Node? run = _head;
        while (i < position && position < Count)
        {
            run = run!.Next;
        }
        result = run!.Pearl;
        return result;
    }
    public int GetNumberOfColoredPearls(string color)
    {
        int result = 0;
        Node? run = _head;
        while (run != null)
        {
            Pearl helper = run!.Pearl;
            if (helper.Color == color)
            {
                result++;
            }
        }
        return result;
    }
    #endregion methods
}
