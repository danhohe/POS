#nullable disable

namespace VocabTrainer;

public class Word
{
    #region fields
    private string _germanWord;
    private string _englishWord;
    private int _hits;
    private int _fails;
    #endregion fields

    #region properties
    public string GermanWord
    {
        get{return _germanWord;}
        set{_germanWord = value;}
    }
    public string EnglishWord
    {
        get{return _englishWord;}
        set{_englishWord = value;}
    }
    public int Hits
    {
        get{return _hits;}
        set{_hits = value;}
    }
    public int Fails
    {
        get{return _fails;}
        set{_fails = value;}
    }
    #endregion properties
}
