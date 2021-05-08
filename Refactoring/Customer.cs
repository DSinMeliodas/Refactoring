using System.Collections;

namespace Refactoring
{
    internal class Customer
    {

        private string m_Name;
        private ArrayList m_Rentals = new ArrayList();

        public Customer(string newname)
        {
            m_Name = newname;
        }

        public void AddRental(Rental arg)
        {
            m_Rentals.Add(arg);
        }

        public string GetName()
        {
            return m_Name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            IEnumerator enum_rentals = m_Rentals.GetEnumerator();
            string result = "Rental Record for " + this.GetName() + "\n";
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
                if ((each.GetMovie().GetPriceCode() == Movie.NewRelease) && each.GetDaysRented() > 1)
                    frequentRenterPoints++;
                //show figures for this rental
                result += "\t" + each.GetMovie().GetTitle() + "\t" + "\t" + each.GetDaysRented() + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;
            }
            //add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        private double AmountFor(Rental each)
        {
            double thisAmount = 0;
            switch (each.GetMovie().GetPriceCode())
            {
                case Movie.Regular:
                    thisAmount += 2;
                    if (each.GetDaysRented() > 2)
                        thisAmount += (each.GetDaysRented() - 2) * 1.5;
                    break;
                case Movie.NewRelease:
                    thisAmount += each.GetDaysRented() * 3;
                    break;
                case Movie.Childrens:
                    thisAmount += 1.5;
                    if (each.GetDaysRented() > 3)
                        thisAmount += (each.GetDaysRented() - 3) * 1.5;
                    break;
            }
            return thisAmount;
        }

    }
}
