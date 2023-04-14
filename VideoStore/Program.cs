namespace VideoStore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var movie1 = new Movie("Toy Story", Movie.CHILDRENS);
            var movie2 = new Movie("The Lion King", Movie.CHILDRENS);
            var movie3 = new Movie("Cinderella", Movie.CHILDRENS);

            var movie4 = new Movie("The Godfather", Movie.REGULAR);
            var movie5 = new Movie("Titanic", Movie.REGULAR);
            var movie6 = new Movie("Inception", Movie.REGULAR);

            var movie7 = new Movie("M3gan", Movie.NEW_RELEASE);
            var movie8 = new Movie("Mummies", Movie.NEW_RELEASE);
            var movie9 = new Movie("Murder Mystery 2", Movie.NEW_RELEASE);

            var rental1 = new Rental(movie1, 1);
            var rental2 = new Rental(movie2, 2);
            var rental3 = new Rental(movie3, 3);

            var rental4 = new Rental(movie4, 4);
            var rental5 = new Rental(movie5, 5);
            var rental6 = new Rental(movie6, 6);

            var rental7 = new Rental(movie7, 7);
            var rental8 = new Rental(movie8, 8);
            var rental9 = new Rental(movie9, 9);

            var customer1 = new Customer("Customer1");
            customer1.AddRental(rental1);
            customer1.AddRental(rental4);
            customer1.AddRental(rental7);

            var customer2 = new Customer("Customer2");
            customer2.AddRental(rental2);
            customer2.AddRental(rental5);
            customer2.AddRental(rental8);

            var customer3 = new Customer("Customer3");
            customer3.AddRental(rental3);
            customer3.AddRental(rental6);
            customer3.AddRental(rental9);

            var customers = new List<Customer>
            {
                customer1, customer2, customer3
            };

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Statement());
                Console.WriteLine();
            }
        }
    }
}