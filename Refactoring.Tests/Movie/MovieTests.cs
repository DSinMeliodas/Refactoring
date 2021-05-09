using NUnit.Framework;

using System;

using TMovie = Refactoring.Movie;

namespace Refactoring.Tests.Movie
{
    internal class MovieTests
    {
        [Test]
        public void MoviePriceCodeTest(
            [ValueSource(typeof(MovieTestSourceFactory), nameof(MovieTestSourceFactory.MovieWithPriceCodeFactory))] Tuple<TMovie, int> moviePriceCodeTuple)
        {
            TMovie movie = moviePriceCodeTuple.Item1;
            int customerName = moviePriceCodeTuple.Item2;
            Assert.AreEqual(customerName, movie.PriceCode);
        }

        [Test]
        public void MovieTitleTest(
            [ValueSource(typeof(MovieTestSourceFactory), nameof(MovieTestSourceFactory.MovieWithTitleFactory))] Tuple<TMovie, string> movieTitleTuple)
        {
            TMovie movie = movieTitleTuple.Item1;
            string customerName = movieTitleTuple.Item2;
            Assert.AreEqual(customerName, movie.Title);
        }
    }
}