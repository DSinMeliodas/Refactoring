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
            double owedAmount = 0;
            int frequentRenterPoints = 0;
            IEnumerator rentals = m_Rentals.GetEnumerator();
            string statement = "Rental Record for " + Name + "\n";
            statement += "\t" + "Title" + "\t" + "\t" + "Days" + "\t" + "Amount" + "\n";

            while (rentals.MoveNext())
            {
                double thisAmount = 0;
                Rental currentRental = (Rental) rentals.Current;
                //determine amounts for each line
                thisAmount = AmountFor(currentRental);
                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((currentRental.Movie.PriceCode == Movie.NewRelease) && currentRental.DaysRented > 1)
                    frequentRenterPoints++;
                //show figures for this rental
                statement += "\t" + currentRental.Movie.Title + "\t" + "\t" + currentRental.DaysRented + "\t" + thisAmount + "\n";
                owedAmount += thisAmount;
            }
            //add footer lines
            statement += "Amount owed is " + owedAmount + "\n";
            statement += "You earned " + frequentRenterPoints + " frequent renter points";
            return statement;
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
