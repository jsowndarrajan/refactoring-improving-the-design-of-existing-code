namespace VideoStore
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private string _title;
        private int _priceCode;

        public Movie(string title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public int GetPriceCode()
        {
            return _priceCode;
        }

        public void SetPriceCode(int arg)
        {
            _priceCode = arg;
        }

        public string GetTitle()
        {
            return _title;
        }

        public double GetCharge(int daysRented)
        {
            double result = 0;
            switch (GetPriceCode())
            {
                case Movie.REGULAR:
                    result += 2;
                    if (daysRented > 2)
                        result += (daysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += daysRented * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5;
                    break;
            }
            return result;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            if (GetPriceCode() == Movie.NEW_RELEASE
                &&
                daysRented > 1) return 2;
            return 1;
        }
    }
}
