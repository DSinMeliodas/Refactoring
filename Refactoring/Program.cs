using System;

namespace Refactoring
{
    internal class Program
    {
        static void Main()
        {
            string result;
            Console.WriteLine("Welcome to the Movie Store");
            Movie m1 = new Movie("movie1", 1);
            Movie m2 = new Movie("movie2", 2);
            Rental r1 = new Rental(m1, 10);
            Rental r2 = new Rental(m2, 5);
            Customer c1 = new Customer("joe");
            c1.AddRental(r1); c1.AddRental(r2);
            Console.WriteLine("Let's get the Statement");
            result = c1.Statement();
            Console.WriteLine(result);
        }
    }
}
