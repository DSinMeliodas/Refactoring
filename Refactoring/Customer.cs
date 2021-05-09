using System;
using System.Collections;
using System.Collections.Generic;

namespace Refactoring
{
    internal class Customer
    {
        public static readonly string StatementFormat = "Rental Record for {0}" + Environment.NewLine +
                                                         "\tTitle\t\tDays\tAmount" + Environment.NewLine +
                                                         "{1}" +
                                                         "Amount owed is {2}" + Environment.NewLine +
                                                         "You earned {3} frequent renter points";
        public static readonly string RentalFormat = "\t{0}" + Environment.NewLine;
        public static readonly string RentalHtmlFormat = "{0}<br>" + Environment.NewLine;

        private readonly List<Rental> m_Rentals = new List<Rental>();

        public static readonly string HtmlStatementFormat = "<h1>Rentals for <em>{0}</em></h1><p>" + Environment.NewLine +
                                                            "{1}" +
                                                            "<p>You owe <em>{2}</em></p>" + Environment.NewLine +
                                                            "On this rental you earned <em>{3}</em> frequent renter points</p>";

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
            double totalFee = 0;
            int totalRenterPoints = 0;
            string rentalsAsString = string.Empty;
            foreach (var rental in m_Rentals)
            {
                totalFee += rental.Charge;
                totalRenterPoints += rental.RenterPoints;
                rentalsAsString += string.Format(RentalFormat, rental);
            }
            return string.Format(StatementFormat, Name, rentalsAsString, totalFee, totalRenterPoints);
        }

        public string HtmlStatement()
        {

            double totalFee = 0;
            int totalRenterPoints = 0;
            string rentalsAsString = string.Empty;
            foreach (var rental in m_Rentals)
            {
                totalFee += rental.Charge;
                totalRenterPoints += rental.RenterPoints;
                rentalsAsString += string.Format(RentalHtmlFormat, rental.ToHtmlString());
            }
            return string.Format(HtmlStatementFormat, Name, rentalsAsString, totalFee, totalRenterPoints);
        }

        /// <summary>
        /// Needed for testing to clear input as <see cref="NUnit.Framework.ValueSourceAttribute"/> will combine factory created instances
        /// and thus there has to be a possibility to clear the current rentals after each test.
        /// </summary>
        internal void ClearRentals()
        {
            m_Rentals.Clear();
        }
    }
}
