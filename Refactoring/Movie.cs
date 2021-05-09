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

        public double CalculateChargeFor(int daysRented) => m_Price.CalculateChargeFor(daysRented);

        public int CalculateRenterPointsFor(int daysRented) => m_Price.CalculateRenterPointsFor(daysRented);
    }
}