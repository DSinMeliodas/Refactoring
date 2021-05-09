namespace Refactoring
{
    internal class Rental
    {
        public const string StatementFormat = "{0}\t\t{1}\t{2}";

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public Movie Movie { get; }

        public int DaysRented { get; }

        public double Charge => Movie.CalculateChargeFor(DaysRented);

        public int RenterPoints => Movie.CalculateRenterPointsFor(DaysRented);

        public override string ToString()
        {
            return string.Format(StatementFormat, Movie.Title, DaysRented, Charge);
        }
    }
}