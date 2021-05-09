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
                thisAmount = AmountFor(currentRental);
                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((currentRental.Movie.PriceCode == NewReleaseMovie.Code) && currentRental.DaysRented > 1)
                    frequentRenterPoints++;
                //show figures for this rental
                rentalsString += "\t" + currentRental.Movie.Title + "\t" + "\t" + currentRental.DaysRented + "\t" + thisAmount + "\n";
                owedAmount += thisAmount;
            }
            //add footer lines
            return string.Format(StatementFormat, Name, rentalsString, owedAmount, frequentRenterPoints);
        }

        private double AmountFor(Rental aRental)
        {
            double thisAmount = 0;
            switch (aRental.Movie.PriceCode)
            {
            case RegularMovie.Code:
                thisAmount += 2;
                if (aRental.DaysRented > 2)
                    thisAmount += (aRental.DaysRented - 2) * 1.5;
                break;
            case NewReleaseMovie.Code:
                thisAmount += aRental.DaysRented * 3;
                break;
            case ChildrensMovie.Code:
                thisAmount += 1.5;
                if (aRental.DaysRented > 3)
                    thisAmount += (aRental.DaysRented - 3) * 1.5;
                break;
            }
            return thisAmount;
        }

    }
}
