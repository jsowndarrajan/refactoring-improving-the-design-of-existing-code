namespace VideoStore.Price;

public class ChildrenPrice : AbstractPrice
{
    public override int GetPriceCode()
    {
        return Movie.CHILDREN;
    }

    public override double GetCharge(int daysRented)
    {
        var result = 1.5;
        if (daysRented > 3)
            result += (daysRented - 3) * 1.5;
        return result;
    }
}