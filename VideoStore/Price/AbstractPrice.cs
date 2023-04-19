namespace VideoStore.Price;

public abstract class AbstractPrice
{
    public abstract int GetPriceCode();

    public abstract double GetCharge(int daysRented);

    public virtual int GetFrequentRenterPoints(int daysRented)
    {
        return 1;
    }
}