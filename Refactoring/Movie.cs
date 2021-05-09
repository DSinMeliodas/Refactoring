namespace Refactoring
{
    internal abstract class Movie
    {
        protected Movie(string title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public string Title { get; }

        public int PriceCode { get; }


    }
}