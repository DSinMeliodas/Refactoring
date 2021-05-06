public class Movie
{

    public const int CHILDRENS = 2;
    public const int REGULAR = 0;
    public const int NEW_RELEASE = 1;

    private string title;
    private int priceCode;

    public Movie(string newtitle, int newpriceCode)
    {
        title = newtitle;
        priceCode = newpriceCode;
    }

    public int getPriceCode()
    {
        return priceCode;
    }

    public void setPriceCode(int arg)
    {
        priceCode = arg;
    }

    public string getTitle()
    {
        return title;
    }
}