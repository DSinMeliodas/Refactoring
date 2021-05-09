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

        public abstract double CalculateChargeFor(int daysRented);

        public virtual int CalculateRenterPointsFor(int daysRented) => 1;
    }
}