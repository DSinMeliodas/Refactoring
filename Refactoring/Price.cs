namespace Refactoring
{
    internal abstract class Price
    {
        protected const double PriceMultiplier = 1.5;

        protected Price(int code)
        {
            Code = code;
        }

        public int Code { get; }

        public abstract double MeasuePriceFor(int daysRented);
    }
}