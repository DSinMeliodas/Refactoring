namespace Refactoring
{
    internal abstract class Movie
    {
        private readonly Price m_Price;

        protected Movie(string title, Price price)
        {
            Title = title;
            m_Price = price;
        }

        public string Title { get; }

        public int PriceCode => m_Price.Code;

        public double MeasureChargeFor(int daysRented) => m_Price.MeasuePriceFor(daysRented);
    }
}