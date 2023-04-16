namespace VideoStore
{
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int GetDaysRented()
        {
            return _daysRented;
        }

        public Movie GetMovie()
        {
            return _movie;
        }

        public double GetCharge()
        {
            double result = 0;
            switch (GetMovie().GetPriceCode())
            {
                case Movie.REGULAR:
                    result += 2;
                    if (GetDaysRented() > 2)
                        result += (GetDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += GetDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (GetDaysRented() > 3)
                        result += (GetDaysRented() - 3) * 1.5;
                    break;
            }

            return result;
        }

        public int GetFrequentRenterPoints()
        {
            if (this.GetMovie().GetPriceCode() == Movie.NEW_RELEASE
                &&
                this.GetDaysRented() > 1) return 2;
            return 1;
        }
    }
}
