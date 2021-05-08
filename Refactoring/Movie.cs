namespace Refactoring
{
    internal class Movie
    {

        public const int Childrens = 2;
        public const int Regular = 0;
        public const int NewRelease = 1;

        public Movie(string newtitle, int newpriceCode)
        {
            Title = newtitle;
            PriceCode = newpriceCode;
        }

        public string Title { get; }

        public int PriceCode { get; set; }
    }
}