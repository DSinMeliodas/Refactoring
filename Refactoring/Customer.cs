using System;
using System.Collections;
using System.Collections.Generic;

namespace Refactoring
{
    internal class Customer
    {
        private static readonly string StatementFormat = "Rental Record for {0}" + Environment.NewLine +
                                                         "\tTitle\t\tDays\tAmount" + Environment.NewLine +
                                                         "{1}" + Environment.NewLine +
                                                         "Amount owed is {2}" + Environment.NewLine +
                                                         "You earned {3} frequent renter points";

        private readonly List<Rental> m_Rentals = new List<Rental>();

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
            using var rentals = m_Rentals.GetEnumerator();
            string rentalsString = string.Empty;
            while (rentals.MoveNext())
            {
                double thisAmount = 0;
                Rental currentRental = (Rental) rentals.Current;
                //determine amounts for each line
                thisAmount = currentRental.Charge;
                // add frequent renter points
                frequentRenterPoints += currentRental.RenterPoints;
                //show figures for this rental
                rentalsString += "\t" + currentRental.Movie.Title + "\t" + "\t" + currentRental.DaysRented + "\t" + thisAmount + "\n";
                owedAmount += thisAmount;
            }
            //add footer lines
            return string.Format(StatementFormat, Name, rentalsString, owedAmount, frequentRenterPoints);
        }

    }
}
