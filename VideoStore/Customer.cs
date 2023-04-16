namespace VideoStore
{
    public class Customer
    {
        private string _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string GetName()
        {
            return _name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            var frequentRenterPoints = 0;
            var result = "Rental Record for " + GetName() + "\n";

            foreach (var each in _rentals)
            {
                var thisAmount = AmountFor(each);

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.GetMovie().GetPriceCode() == Movie.NEW_RELEASE)
                    &&
                    each.GetDaysRented() > 1) frequentRenterPoints++;
                //show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;
            }

            //add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        private static double AmountFor(Rental aRental)
        {
            double result = 0;
            switch (aRental.GetMovie().GetPriceCode())
            {
                case Movie.REGULAR:
                    result += 2;
                    if (aRental.GetDaysRented() > 2)
                        result += (aRental.GetDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += aRental.GetDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5;
                    if (aRental.GetDaysRented() > 3)
                        result += (aRental.GetDaysRented() - 3) * 1.5;
                    break;
            }

            return result;
        }
    }
}
