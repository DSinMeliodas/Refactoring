using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using Refactoring.Tests.Movie;
using Refactoring.Tests.Rental;

using TCustomer = Refactoring.Customer;
using TMovie = Refactoring.Movie;
using TRental = Refactoring.Rental;

namespace Refactoring.Tests.Customer
{
    internal class CustomerTests
    {
        private const string RentalStatementFormat = "\t{0}\t\t{1}\t{2}";
        private const string RentalHtmlStatementFormat = "{0}\t{1}\t{2}";

        private TCustomer m_Current;

        [TearDown]
        public void ClearCustomer()
        {
            m_Current.ClearRentals();
        }

        [Test]
        public void CustomerStatementTest(
            [ValueSource(typeof(CustomerTestSourceFactory), nameof(CustomerTestSourceFactory.CustomerFactory))] TCustomer customer,
            [ValueSource(typeof(MovieTestSourceFactory), nameof(MovieTestSourceFactory.MoviesFactory))] TMovie[] movies,
            [ValueSource(typeof(RentalTestSourceFactory), nameof(RentalTestSourceFactory.RentalBuildersFactory))] RentalTestSourceFactory.RentalBuilder builder)
        {
            m_Current = customer;
            var rentals = movies.Select(builder.Invoke).ToList();
            foreach (var rental in rentals)
            {
                customer.AddRental(rental);
            }
            string actual = customer.Statement();
            string expected = Statement(customer, rentals);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CustomerHtmlStatementTest(
            [ValueSource(typeof(CustomerTestSourceFactory), nameof(CustomerTestSourceFactory.CustomerFactory))] TCustomer customer,
            [ValueSource(typeof(MovieTestSourceFactory), nameof(MovieTestSourceFactory.MoviesFactory))] TMovie[] movies,
            [ValueSource(typeof(RentalTestSourceFactory), nameof(RentalTestSourceFactory.RentalBuildersFactory))] RentalTestSourceFactory.RentalBuilder builder)
        {
            m_Current = customer;
            var rentals = movies.Select(builder.Invoke).ToList();
            foreach (var rental in rentals)
            {
                customer.AddRental(rental);
            }
            string actual = customer.Statement();
            string expected = HtmlStatement(customer, rentals);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CustomerNameTest(
            [ValueSource(typeof(CustomerTestSourceFactory), nameof(CustomerTestSourceFactory.CustomerWithNameFactory))] Tuple<TCustomer, string> customerNameTuple)
        {
            TCustomer customer = customerNameTuple.Item1;
            string customerName = customerNameTuple.Item2;
            Assert.AreEqual(customerName, customer.Name);
        }

        private static string Statement(TCustomer customer, List<TRental> rentals)
        {
            string rentalsStatement = rentals.Aggregate(string.Empty, RentalAppendFormatter(RentalStatementFormat));
            return string.Format(TCustomer.StatementFormat, customer.Name, rentalsStatement, rentals.Sum(r=>r.Charge), rentals.Sum(r=>r.RenterPoints));
        }

        private static string HtmlStatement(TCustomer customer, List<TRental> rentals)
        {
            string rentalsStatement = rentals.Aggregate(string.Empty, RentalAppendFormatter(RentalHtmlStatementFormat));
            return $"<h1>Rentals for <em>{customer.Name}</em></h1><p>{Environment.NewLine}" +
                   $"{rentalsStatement}" +
                   $"<p>You owe <em>{rentals.Sum(r => r.Charge)}</em></p>{Environment.NewLine}" +
                   $"On this rental you earned <em>{rentals.Sum(r => r.RenterPoints)}</em> frequent renter points</p>";
        }

        private static Func<string, TRental, string> RentalAppendFormatter(string format)
        {
            return (statement, rental) => statement + string.Format(format, rental.Movie.Title, rental.DaysRented, rental.Charge) + Environment.NewLine;
        }
    }
}