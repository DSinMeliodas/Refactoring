namespace Refactoring
{
    internal class RegularPrice : Price
    {
        public const int PriceCode = 0;
        public const double BasePrice = 2.0; 

        public RegularPrice() 
            : base(PriceCode)
        {
        }

        public override double MeasuePriceFor(int daysRented)
        {
            return daysRented <= 2
                ? BasePrice
                : (daysRented - 2) * PriceMultiplier;
        }
    }
}