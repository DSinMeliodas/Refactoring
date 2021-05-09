using System;

namespace Refactoring
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Movie Store");
            Movie movie1 = new NewReleaseMovie("movie1");
            Movie movie2 = new ChildrensMovie("movie2");
            Rental rentalMovie1 = new Rental(movie1, 10);
            Rental rentalMovie2 = new Rental(movie2, 5);
            Customer joe = new Customer("joe");
            joe.AddRental(rentalMovie1); 
            joe.AddRental(rentalMovie2);
            Console.WriteLine("Let's get the Statement");
            Console.WriteLine(joe.Statement());
        }
    }
}
