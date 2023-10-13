using DsK.LINQTutorial.Helpers;
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
            "LINQ".StartSection();
            var LINQ = from name in names
                        where name.Contains('a')
                        select name;
            foreach (var name in LINQ)
                Console.Write(name + Environment.NewLine);
            "LINQ".EndSection();


            "Lambda".StartSection();
            var Lambda = names.Where(x=>x.Contains('a')).ToList();
            foreach (var name in Lambda)
                Console.Write(name + Environment.NewLine);
            "Lambda".EndSection();
        }
    }
}
