using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsK.LINQTutorial.Tests
{
    public static class StringArray
    {
        public static void Test()
        {
            // Data source
            string[] names = { "Ruben", "Rafael", "Natcel", "Edwin", "Carlos" };

            // LINQ Query 
            var query = from name in names
                        where name.Contains('a')
                        select name;

            // Lambda
            //var query = names.Where(x=>x.Contains('a')).ToList();

            // Query execution
            foreach (var name in query)
                Console.Write(name + Environment.NewLine);
        }
    }
}
