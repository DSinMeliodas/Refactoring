using System;
using System.Collections.Generic;

using TCustomer = Refactoring.Customer;

namespace Refactoring.Tests.Customer
{
    internal static class CustomerTestSourceFactory
    {
        private const string Joe = "Joe";
        private const string Andrew = "Andrew";
        private const string Foo = "Foo";
        private const string Bar = "Bar";
        private const string Futurum = "Futurum";
        private const string DLord = "DLord";
        private const string DSinMeliodas = "DSinMeliodas";
        private const string Nobody = "Nobody";

        public static IEnumerable<TCustomer> CustomerFactory()
        {
            return new[]
            {
                new TCustomer(Joe), new TCustomer(Andrew),
                new TCustomer(Foo), new TCustomer(Bar),
                new TCustomer(Futurum), new TCustomer(DLord),
                new TCustomer(DSinMeliodas), new TCustomer(Nobody)
            };
        }

        public static IEnumerable<Tuple<TCustomer, string>> CustomerWithNameFactory()
        {
            return new[]
            {
                CustomerNameTupleFactory(Joe),
                CustomerNameTupleFactory(Andrew),
                CustomerNameTupleFactory(Foo),
                CustomerNameTupleFactory(Bar),
                CustomerNameTupleFactory(Futurum),
                CustomerNameTupleFactory(DLord),
                CustomerNameTupleFactory(DSinMeliodas),
                CustomerNameTupleFactory(Nobody)
            };
        }

        private static Tuple<TCustomer, string> CustomerNameTupleFactory(string name) => new Tuple<TCustomer, string>(new TCustomer(name), name);
    }
}