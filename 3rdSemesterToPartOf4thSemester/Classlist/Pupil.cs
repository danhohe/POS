namespace Classlist;

public class Pupil
{
    #region fields
    private string _catalogNumber = string.Empty;
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _zipCode = string.Empty;
    #endregion fields

    #region properties
    public string CatalogNumber
    {
        get
        {
            return _catalogNumber;
        }
        set
        {
            _catalogNumber = value;
        }
    }
    public string FirstName
    {
        get
        {
            return _firstName;
        }
        set
        {
            _firstName = value;
        }
    }
    public string LastName
    {
        get
        {
            return _lastName;
        }
        set
        {
            _lastName = value;
        }
    }
    public string ZipCode
    {
        get
        {
            return _zipCode;
        }
        set
        {
            _zipCode = value;
        }
    }
    #endregion properties
}
