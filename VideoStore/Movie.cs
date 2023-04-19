using VideoStore.Price;

namespace VideoStore;

public class Movie
{
    public const int CHILDREN = 2;
    public const int REGULAR = 0;
    public const int NEW_RELEASE = 1;

    private string _title;
    private AbstractPrice _price;

    public Movie(string title, int priceCode)
    {
        _title = title;
        SetPriceCode(priceCode);
    }

    public AbstractPrice Price
    {
        set { _price = value; }
        get { return _price; }
    }

    public int GetPriceCode()
    {
        return _price.GetPriceCode();
    }

    public void SetPriceCode(int arg)
    {
        switch (arg)
        {
            case REGULAR:
                _price = new RegularPrice();
                break;
            case NEW_RELEASE:
                _price = new NewReleasePrice();
                break;
            case CHILDREN:
                _price = new ChildrenPrice();
                break;
            default:
                throw new ArgumentException("Incorrect Price code");
        }
    }

    public double GetCharge(int daysRented)
    {
        return _price.GetCharge(daysRented);
    }

    public string GetTitle()
    {
        return _title;
    }

    public int GetFrequentRenterPoints(int daysRented)
    {
        if (GetPriceCode() == Movie.NEW_RELEASE
            &&
            daysRented > 1) return 2;
        return 1;
    }
}