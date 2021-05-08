class Rental
{

    private Movie m_Movie;
    private int m_DaysRented;

    public Rental(Movie newmovie, int newdaysRented)
    {
        m_Movie = newmovie;
        m_DaysRented = newdaysRented;
    }

    public int getDaysRented()
    {
        return m_DaysRented;
    }

    public Movie getMovie()
    {
        return m_Movie;
    }
}