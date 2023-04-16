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

            foreach (var aRental in _rentals)
            {
                var thisAmount = aRental.GetCharge();

                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((aRental.GetMovie().GetPriceCode() == Movie.NEW_RELEASE)
                    &&
                    aRental.GetDaysRented() > 1) frequentRenterPoints++;
                //show figures for this rental
                result += "\t" + aRental.GetMovie().GetTitle() + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;
            }

            //add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }
    }
}
