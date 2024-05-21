namespace DemoSortFraction.ConApp;

public class NominatorComparer : IComparer<Fraction>
{
    public int Compare(Fraction? x, Fraction? y)
    {
        if (x == null || y == null)
        {
            throw new ArgumentNullException(nameof(Fraction));
        }
        return x.Nominator.CompareTo(y.Nominator);
    }
}
