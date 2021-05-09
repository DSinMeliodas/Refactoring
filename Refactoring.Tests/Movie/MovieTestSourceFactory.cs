using System;
using System.Collections.Generic;

using TMovie = Refactoring.Movie;

namespace Refactoring.Tests.Movie
{
    internal static class MovieTestSourceFactory
    {
        private const string MovieNameFormat = "Movie {0}";
        private const int MovieCount = 100;
        private const int SmallMovieCount = 10;

        private static readonly int[] MoviePriceCodes = { TMovie.Childrens, TMovie.NewRelease, TMovie.Regular };

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

        private static TMovie MovieBuilder(string title, int value) => new TMovie(title, MoviePriceCodes[(value * 7) % MoviePriceCodes.Length]);

        private static Tuple<TMovie, int> MoviePriceCodeTupleFactory(int value) => new Tuple<TMovie, int>(MovieBuilder(value), MoviePriceCodes[(value * 7) % MoviePriceCodes.Length]);

        private static Tuple<TMovie, string> MovieTitleTupleFactory(int value)
        {
            string title = string.Format(MovieNameFormat, value);
            return new Tuple<TMovie, string>(MovieBuilder(title, value), title);
        }
    }
}