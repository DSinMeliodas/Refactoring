namespace Refactoring
{
    internal class Rental
    {
        public Rental(Movie newmovie, int newdaysRented)
        {
            Movie = newmovie;
            DaysRented = newdaysRented;
        }

        public Movie Movie { get; }

        public int DaysRented { get; }
    }
}