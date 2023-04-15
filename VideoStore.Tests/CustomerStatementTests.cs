using FluentAssertions;

namespace VideoStore.Tests
{
    public class CustomerStatementTests
    {
        [Test]
        public void CustomerWithNoRentals()
        {
            var customer = new Customer("Customer1");
            customer.Should().NotBeNull();

            var actualStatement = customer.Statement();
            var expectedStatement = "Rental Record for Customer1\n" +
                                    "Amount owed is 0\n" +
                                    "You earned 0 frequent renter points";
            actualStatement.Should().Be(expectedStatement);
        }

        [Test]
        public void CustomerRentedRegularMoviesForLessThan3days()
        {
            var movie1 = new Movie("The Godfather", Movie.REGULAR);
            var movie2 = new Movie("Titanic", Movie.REGULAR);

            var rental1 = new Rental(movie1, 1);
            var rental2 = new Rental(movie2, 2);

            var customer = new Customer("Customer1");
            customer.AddRental(rental1);
            customer.AddRental(rental2);

            var actualStatement = customer.Statement();
            var expectedStatement = "Rental Record for Customer1\n" +
                                    "\tThe Godfather\t2\n" +
                                    "\tTitanic\t2\n" +
                                    "Amount owed is 4\n" +
                                    "You earned 2 frequent renter points";
            actualStatement.Should().Be(expectedStatement);
        }

        [Test]
        public void CustomerRentedRegularMoviesForGreaterThan2days()
        {
            var movie1 = new Movie("The Godfather", Movie.REGULAR);
            var movie2 = new Movie("Titanic", Movie.REGULAR);

            var rental1 = new Rental(movie1, 4);
            var rental2 = new Rental(movie2, 10);

            var customer = new Customer("Customer1");
            customer.AddRental(rental1);
            customer.AddRental(rental2);

            var actualStatement = customer.Statement();
            var expectedStatement = "Rental Record for Customer1\n" +
                                    "\tThe Godfather\t5\n" +
                                    "\tTitanic\t14\n" +
                                    "Amount owed is 19\n" +
                                    "You earned 2 frequent renter points";
            actualStatement.Should().Be(expectedStatement);
        }

        [Test]
        public void CustomerRentedNewReleaseMovies()
        {
            var movie1 = new Movie("M3gan", Movie.NEW_RELEASE);
            var movie2 = new Movie("Mummies", Movie.NEW_RELEASE);
            var movie3 = new Movie("Murder Mystery 2", Movie.NEW_RELEASE);

            var rental1 = new Rental(movie1, 10);
            var rental2 = new Rental(movie2, 20);
            var rental3 = new Rental(movie3, 30);

            var customer = new Customer("Customer1");
            customer.AddRental(rental1);
            customer.AddRental(rental2);
            customer.AddRental(rental3);

            var actualStatement = customer.Statement();
            var expectedStatement = "Rental Record for Customer1\n" +
                                    "\tM3gan\t30\n" +
                                    "\tMummies\t60\n" +
                                    "\tMurder Mystery 2\t90\n" +
                                    "Amount owed is 180\n" +
                                    "You earned 6 frequent renter points";
            actualStatement.Should().Be(expectedStatement);
        }


        [Test]
        public void CustomerRentedChildrenMoviesForLessThan4days()
        {
            var movie1 = new Movie("Toy Story", Movie.CHILDRENS);
            var movie2 = new Movie("The Lion King", Movie.CHILDRENS);
            var movie3 = new Movie("Cinderella", Movie.CHILDRENS);

            var rental1 = new Rental(movie1, 1);
            var rental2 = new Rental(movie2, 2);
            var rental3 = new Rental(movie3, 3);

            var customer = new Customer("Customer1");
            customer.AddRental(rental1);
            customer.AddRental(rental2);
            customer.AddRental(rental3);

            var actualStatement = customer.Statement();
            var expectedStatement = "Rental Record for Customer1\n" +
                                    "\tToy Story\t1.5\n" +
                                    "\tThe Lion King\t1.5\n" +
                                    "\tCinderella\t1.5\n" +
                                    "Amount owed is 4.5\n" +
                                    "You earned 3 frequent renter points";
            actualStatement.Should().Be(expectedStatement);
        }

        [Test]
        public void CustomerRentedChildrenMoviesForGreaterThan3days()
        {
            var movie1 = new Movie("Toy Story", Movie.CHILDRENS);
            var movie2 = new Movie("The Lion King", Movie.CHILDRENS);
            var movie3 = new Movie("Cinderella", Movie.CHILDRENS);

            var rental1 = new Rental(movie1, 10);
            var rental2 = new Rental(movie2, 20);
            var rental3 = new Rental(movie3, 30);

            var customer = new Customer("Customer1");
            customer.AddRental(rental1);
            customer.AddRental(rental2);
            customer.AddRental(rental3);

            var actualStatement = customer.Statement();
            var expectedStatement = "Rental Record for Customer1\n" +
                                    "\tToy Story\t12\n" +
                                    "\tThe Lion King\t27\n" +
                                    "\tCinderella\t42\n" +
                                    "Amount owed is 81\n" +
                                    "You earned 3 frequent renter points";
            actualStatement.Should().Be(expectedStatement);
        }
    }
}