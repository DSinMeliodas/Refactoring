using System.Collections;

namespace Refactoring
{
    internal class Customer
    {
        private readonly ArrayList m_Rentals = new ArrayList();

        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void AddRental(Rental aRental)
        {
            m_Rentals.Add(aRental);
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            IEnumerator enum_rentals = m_Rentals.GetEnumerator();
            string result = "Rental Record for " + Name + "\n";
            result += "\t" + "Title" + "\t" + "\t" + "Days" + "\t" + "Amount" + "\n";

            while (enum_rentals.MoveNext())
            {
                double thisAmount = 0;
                Rental each = (Rental) enum_rentals.Current;
                //determine amounts for each line
                thisAmount = AmountFor(each);
                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.Movie.PriceCode == Movie.NewRelease) && each.DaysRented > 1)
                    frequentRenterPoints++;
                //show figures for this rental
                result += "\t" + each.Movie.Title + "\t" + "\t" + each.DaysRented + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;
            }
            //add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        private double AmountFor(Rental aRental)
        {
            double thisAmount = 0;
            switch (aRental.Movie.PriceCode)
            {
                case Movie.Regular:
                    thisAmount += 2;
                    if (aRental.DaysRented > 2)
                        thisAmount += (aRental.DaysRented - 2) * 1.5;
                    break;
                case Movie.NewRelease:
                    thisAmount += aRental.DaysRented * 3;
                    break;
                case Movie.Childrens:
                    thisAmount += 1.5;
                    if (aRental.DaysRented > 3)
                        thisAmount += (aRental.DaysRented - 3) * 1.5;
                    break;
            }
            return thisAmount;
        }

    }
}
