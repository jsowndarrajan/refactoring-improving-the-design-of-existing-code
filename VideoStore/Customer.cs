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
            var result = "Rental Record for " + GetName() + "\n";

            foreach (var aRental in _rentals)
            {
                //show figures for this rental
                result += "\t" + aRental.GetMovie().GetTitle() + "\t" + aRental.GetCharge() + "\n";
            }

            //add footer lines
            result += "Amount owed is " + GetTotalCharge() + "\n";
            result += "You earned " + GetTotalFrequentRenterPoints() + " frequent renter points";
            return result;
        }

        private double GetTotalCharge()
        {
            double result = 0;
            foreach (var aRental in _rentals)
            {
                result += aRental.GetCharge();
            }
            return result;
        }

        private double GetTotalFrequentRenterPoints()
        {
            double result = 0;
            foreach (var aRental in _rentals)
            {
                result += aRental.GetFrequentRenterPoints();
            }
            return result;
        }
    }
}
