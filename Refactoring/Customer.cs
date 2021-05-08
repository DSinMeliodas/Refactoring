using System.Collections;

class Customer
{

    private string m_Name;
    private ArrayList m_Rentals = new ArrayList();

    public Customer(string newname)
    {
        m_Name = newname;
    }

    public void addRental(Rental arg)
    {
        m_Rentals.Add(arg);
    }

    public string getName()
    {
        return m_Name;
    }

    public string statement()
    {
        double totalAmount = 0;
        int frequentRenterPoints = 0;
        IEnumerator enum_rentals = m_Rentals.GetEnumerator();
        string result = "Rental Record for " + this.getName() + "\n";
        result += "\t" + "Title" + "\t" + "\t" + "Days" + "\t" + "Amount" + "\n";

        while (enum_rentals.MoveNext())
        {
            double thisAmount = 0;
            Rental each = (Rental) enum_rentals.Current;
            //determine amounts for each line
            thisAmount = amountFor(each);
            // add frequent renter points
            frequentRenterPoints++;
            // add bonus for a two day new release rental
            if ((each.getMovie().getPriceCode() == Movie.NewRelease) && each.getDaysRented() > 1)
                frequentRenterPoints++;
            //show figures for this rental
            result += "\t" + each.getMovie().getTitle() + "\t" + "\t" + each.getDaysRented() + "\t" + thisAmount + "\n";
            totalAmount += thisAmount;
        }
        //add footer lines
        result += "Amount owed is " + totalAmount + "\n";
        result += "You earned " + frequentRenterPoints + " frequent renter points";
        return result;
    }

    private double amountFor(Rental each)
    {
        double thisAmount = 0;
        switch (each.getMovie().getPriceCode())
        {
        case Movie.Regular:
            thisAmount += 2;
            if (each.getDaysRented() > 2)
                thisAmount += (each.getDaysRented() - 2) * 1.5;
            break;
        case Movie.NewRelease:
            thisAmount += each.getDaysRented() * 3;
            break;
        case Movie.Childrens:
            thisAmount += 1.5;
            if (each.getDaysRented() > 3)
                thisAmount += (each.getDaysRented() - 3) * 1.5;
            break;
        }
        return thisAmount;
    }

}
