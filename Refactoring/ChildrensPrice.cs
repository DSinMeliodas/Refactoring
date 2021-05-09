namespace Refactoring
{
    internal class ChildrensPrice : Price
    {
        public const int PriceCode = 2;
        public const double BasePrice = 1.5;

        public ChildrensPrice() 
            : base(PriceCode)
        {
        }

        public override double MeasuePriceFor(int daysRented)
        {
            return daysRented <= 3 
                ? BasePrice 
                : (daysRented - 3) * PriceMultiplier;
        }
    }
}