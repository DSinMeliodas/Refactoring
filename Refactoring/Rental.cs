﻿namespace Refactoring
{
    internal class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public Movie Movie { get; }

        public int DaysRented { get; }

        public double Charge => Movie.MeasureChargeFor(DaysRented);
    }
}