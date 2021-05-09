using NUnit.Framework;

using System;

using TMovie = Refactoring.Movie;
using TRental = Refactoring.Rental;

namespace Refactoring.Tests.Rental
{
    internal class RentalTests
    {

        [Test]
        public void RentalMoviesTest(
            [ValueSource(typeof(RentalTestSourceFactory), nameof(RentalTestSourceFactory.RentalWithMovieFactory))] Tuple<TRental, TMovie> rentalMovieTuple)
        {
            TRental rental = rentalMovieTuple.Item1;
            TMovie movie = rentalMovieTuple.Item2;
            Assert.AreEqual(movie, rental.Movie);
        }

        [Test]
        public void RentalDaysRentedTest(
            [ValueSource(typeof(RentalTestSourceFactory), nameof(RentalTestSourceFactory.RentalWithDaysRentedFactory))] Tuple<TRental, int> rentalDaysRentedTuple)
        {
            TRental rental = rentalDaysRentedTuple.Item1;
            int daysRented = rentalDaysRentedTuple.Item2;
            Assert.AreEqual(daysRented, rental.DaysRented);
        }
    }
}