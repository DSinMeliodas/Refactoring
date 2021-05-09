namespace Refactoring
{
    internal class NewReleasePrice : Price
    {
        public const int PriceCode = 1;

        public NewReleasePrice()
            : base(PriceCode)
        {
        }

        public override double CalculateChargeFor(int daysRented) => daysRented * 2 * PriceMultiplier;

        public override int CalculateRenterPointsFor(int daysRented)
        {
            int renterPoints = base.CalculateRenterPointsFor(daysRented);
            if (daysRented == 1)
            {
                return renterPoints;
            }
            return renterPoints + 1;
        }
    }
}