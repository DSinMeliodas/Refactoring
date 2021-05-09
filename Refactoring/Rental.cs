namespace Refactoring
{
    internal class Rental
    {
        public const string Format = "{0}\t\t{1}\t{2}";
        public const string HtmlFormat = "{0}: {1} {2}";

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public Movie Movie { get; }

        public int DaysRented { get; }

        public double Charge => Movie.CalculateChargeFor(DaysRented);

        public int RenterPoints => Movie.CalculateRenterPointsFor(DaysRented);

        public override string ToString() => ToString(Format);

        public string ToHtmlString() => ToString(HtmlFormat);

        private string ToString(string format) => string.Format(format, Movie.Title, DaysRented, Charge);
    }
}