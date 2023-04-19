using FluentAssertions;

namespace VideoStore.Tests;

public class CustomerHtmlStatementTests
{
    [Test]
    public void CustomerWithNoRentals()
    {
        var customer = new Customer("Customer1");
        customer.Should().NotBeNull();

        var actualStatement = customer.HtmlStatement();
        var expectedStatement = "<h1>Rentals for <b>Customer1</b></h1><p>\n" +
                                "<p>You owe <b>0</b></p>\n" +
                                "On this rental you earned <b>0</b> frequent renter points</p>";
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

        var actualStatement = customer.HtmlStatement();
        var expectedStatement = "<h1>Rentals for <b>Customer1</b></h1><p>\n" +
                                "The Godfather: 2<br/>\n" +
                                "Titanic: 2<br/>\n" +
                                "<p>You owe <b>4</b></p>\n" +
                                "On this rental you earned <b>2</b> frequent renter points</p>";
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

        var actualStatement = customer.HtmlStatement();
        var expectedStatement = "<h1>Rentals for <b>Customer1</b></h1><p>\n" +
                                "The Godfather: 5<br/>\n" +
                                "Titanic: 14<br/>\n" +
                                "<p>You owe <b>19</b></p>\n" +
                                "On this rental you earned <b>2</b> frequent renter points</p>";
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

        var actualStatement = customer.HtmlStatement();
        var expectedStatement = "<h1>Rentals for <b>Customer1</b></h1><p>\n" +
                                "M3gan: 30<br/>\n" +
                                "Mummies: 60<br/>\n" +
                                "Murder Mystery 2: 90<br/>\n" +
                                "<p>You owe <b>180</b></p>\n" +
                                "On this rental you earned <b>6</b> frequent renter points</p>";
        actualStatement.Should().Be(expectedStatement);
    }


    [Test]
    public void CustomerRentedChildrenMoviesForLessThan4days()
    {
        var movie1 = new Movie("Toy Story", Movie.CHILDREN);
        var movie2 = new Movie("The Lion King", Movie.CHILDREN);
        var movie3 = new Movie("Cinderella", Movie.CHILDREN);

        var rental1 = new Rental(movie1, 1);
        var rental2 = new Rental(movie2, 2);
        var rental3 = new Rental(movie3, 3);

        var customer = new Customer("Customer1");
        customer.AddRental(rental1);
        customer.AddRental(rental2);
        customer.AddRental(rental3);

        var actualStatement = customer.HtmlStatement();
        var expectedStatement = "<h1>Rentals for <b>Customer1</b></h1><p>\n" +
                                "Toy Story: 1.5<br/>\n" +
                                "The Lion King: 1.5<br/>\n" +
                                "Cinderella: 1.5<br/>\n" +
                                "<p>You owe <b>4.5</b></p>\n" +
                                "On this rental you earned <b>3</b> frequent renter points</p>";
        actualStatement.Should().Be(expectedStatement);
    }

    [Test]
    public void CustomerRentedChildrenMoviesForGreaterThan3days()
    {
        var movie1 = new Movie("Toy Story", Movie.CHILDREN);
        var movie2 = new Movie("The Lion King", Movie.CHILDREN);
        var movie3 = new Movie("Cinderella", Movie.CHILDREN);

        var rental1 = new Rental(movie1, 10);
        var rental2 = new Rental(movie2, 20);
        var rental3 = new Rental(movie3, 30);

        var customer = new Customer("Customer1");
        customer.AddRental(rental1);
        customer.AddRental(rental2);
        customer.AddRental(rental3);

        var actualStatement = customer.HtmlStatement();
        var expectedStatement = "<h1>Rentals for <b>Customer1</b></h1><p>\n" +
                                "Toy Story: 12<br/>\n" +
                                "The Lion King: 27<br/>\n" +
                                "Cinderella: 42<br/>\n" +
                                "<p>You owe <b>81</b></p>\n" +
                                "On this rental you earned <b>3</b> frequent renter points</p>";
        actualStatement.Should().Be(expectedStatement);
    }
}