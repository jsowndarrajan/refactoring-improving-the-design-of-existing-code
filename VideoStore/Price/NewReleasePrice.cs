namespace VideoStore.Price;

public class NewReleasePrice : AbstractPrice
{
    public override int GetPriceCode()
    {
        return Movie.NEW_RELEASE;
    }

    public override double GetCharge(int daysRented)
    {
       return daysRented * 3;
    }
}