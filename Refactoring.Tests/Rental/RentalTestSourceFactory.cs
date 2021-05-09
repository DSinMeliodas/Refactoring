using System;
using System.Collections.Generic;
using System.Linq;

using Refactoring.Tests.Movie;

using TMovie = Refactoring.Movie;
using TRental = Refactoring.Rental;

namespace Refactoring.Tests.Rental
{
    internal static class RentalTestSourceFactory
    {
        public delegate TRental RentalBuilder(TMovie movie);

        private static readonly int[] RentedDaysList = { 1, 3, 5, 7, 9, 11, 13 };

        public static IEnumerable<Tuple<TRental, TMovie>> RentalWithMovieFactory()
        {
            return RentedDaysList.Select(RentalMovieTupleFactory);
        }

        public static IEnumerable<Tuple<TRental, int>> RentalWithDaysRentedFactory()
        {
            return RentedDaysList.Select(RentalDaysRentedTupleFactory);
        }

        public static IEnumerable<RentalBuilder> RentalBuilderFactory() => RentedDaysList.Select(RentalBuilderFactory);

        private static RentalBuilder RentalBuilderFactory(int daysRented) => m => new TRental(m, daysRented);

        private static Tuple<TRental, TMovie> RentalMovieTupleFactory(int daysRented)
        {
            TMovie movie = MovieTestSourceFactory.MovieBuilder(daysRented);
            return new Tuple<TRental, TMovie>(RentalBuilderFactory(daysRented).Invoke(movie), movie);
        }

        private static Tuple<TRental, int> RentalDaysRentedTupleFactory(int daysRented)
        {
            TMovie movie = MovieTestSourceFactory.MovieBuilder(daysRented);
            return new Tuple<TRental, int>(RentalBuilderFactory(daysRented).Invoke(movie), daysRented);
        }
    }
}