namespace Refactoring
{
    internal class NewReleasePrice : Price
    {
        public const int PriceCode = 1;

        public NewReleasePrice() 
            : base(PriceCode)
        {
        }

        public override double MeasuePriceFor(int daysRented) => daysRented * 2 * PriceMultiplier;
    }
}