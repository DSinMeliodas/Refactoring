using System;
using System.Collections.Generic;

using TMovie = Refactoring.Movie;

namespace Refactoring.Tests.Movie
{
    internal static class MovieTestSourceFactory
    {
        public delegate TMovie MovieFactory(string title);

        private const string MovieNameFormat = "Movie {0}";
        private const int MovieCount = 10000;
        private const int SmallMovieCount = 1000;

        private static readonly int[] MoviePriceCodes = { RegularPrice.PriceCode, ChildrensPrice.PriceCode, NewReleasePrice.PriceCode };

        private static readonly Dictionary<int, MovieFactory> MovieFactoriesByPriceCode = new Dictionary<int, MovieFactory>
        {
            {RegularPrice.PriceCode, RegularMovieFactory}, {ChildrensPrice.PriceCode, ChildrensMovieFactory}, {NewReleasePrice.PriceCode, NewReleaseMovieFactory}
        };

        public static IEnumerable<Tuple<TMovie, int>> MovieWithPriceCodeFactory()
        {
            Tuple<TMovie, int>[] tuples = new Tuple<TMovie, int>[MovieCount];
            for (int i = 0; i < MovieCount; i++)
            {
                tuples[i] = MoviePriceCodeTupleFactory(i);
            }

            return tuples;
        }

        public static IEnumerable<Tuple<TMovie, string>> MovieWithTitleFactory()
        {
            Tuple<TMovie, string>[] tuples = new Tuple<TMovie, string>[MovieCount];
            for (int i = 0; i < MovieCount; i++)
            {
                tuples[i] = MovieTitleTupleFactory(i);
            }

            return tuples;
        }

        public static IEnumerable<TMovie[]> MoviesFactory()
        {
            TMovie[][] movies = new TMovie[SmallMovieCount][];
            for (int i = 0; i < SmallMovieCount;)
            {
                ++i;
                TMovie[] temp = new TMovie[SmallMovieCount];
                for (int j = 0; j < SmallMovieCount;)
                {
                    temp[j] = MovieBuilder(i * ++j);
                }
                movies[i - 1] = temp;
            }
            return movies;
        }

        public static TMovie MovieBuilder(int value) => MovieBuilder(string.Format(MovieNameFormat, value), value);

        private static TMovie MovieBuilder(string title, int value)
        {
            int priceCode = MoviePriceCodes[(value * 7) % MoviePriceCodes.Length];
            return MovieFactoriesByPriceCode[priceCode].Invoke(title);
        }

        private static Tuple<TMovie, int> MoviePriceCodeTupleFactory(int value) => new Tuple<TMovie, int>(MovieBuilder(value), MoviePriceCodes[(value * 7) % MoviePriceCodes.Length]);

        private static Tuple<TMovie, string> MovieTitleTupleFactory(int value)
        {
            string title = string.Format(MovieNameFormat, value);
            return new Tuple<TMovie, string>(MovieBuilder(title, value), title);
        }

        private static RegularMovie RegularMovieFactory(string title) => new RegularMovie(title);

        private static ChildrensMovie ChildrensMovieFactory(string title) => new ChildrensMovie(title);

        private static NewReleaseMovie NewReleaseMovieFactory(string title) => new NewReleaseMovie(title);
    }
}