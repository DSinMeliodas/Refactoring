using System.Collections;

class Customer
{

    private string name;
    private ArrayList rentals = new ArrayList();

    public Customer(string newname)
    {
        name = newname;
    }

    public void addRental(Rental arg)
    {
        rentals.Add(arg);
    }

    public string getName()
    {
        return name;
    }

    public string statement()
    {
        double totalAmount = 0;
        int frequentRenterPoints = 0;
        IEnumerator enum_rentals = rentals.GetEnumerator();
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
            if ((each.getMovie().getPriceCode() == Movie.NEW_RELEASE) && each.getDaysRented() > 1)
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
        case Movie.REGULAR:
            thisAmount += 2;
            if (each.getDaysRented() > 2)
                thisAmount += (each.getDaysRented() - 2) * 1.5;
            break;
        case Movie.NEW_RELEASE:
            thisAmount += each.getDaysRented() * 3;
            break;
        case Movie.CHILDRENS:
            thisAmount += 1.5;
            if (each.getDaysRented() > 3)
                thisAmount += (each.getDaysRented() - 3) * 1.5;
            break;
        }
        return thisAmount;
    }

}
